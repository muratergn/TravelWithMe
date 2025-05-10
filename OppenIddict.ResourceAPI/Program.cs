using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();          
builder.Services.AddEndpointsApiExplorer();  
builder.Services.AddSwaggerGen();           

// 1) Uygulamada kimlik doðrulama (Authentication) mekanizmasýný devreye alýyoruz.
//    Burada JWT Bearer (Json Web Token) kullanacaðýmýzý belirtiyoruz.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // 1.a) Authority: Token'larýn hangi otorite (Authorization Server) tarafýndan imzalandýðýný belirtir.
        //      Örneðin: "https://localhost:7182" gibi bir adres olabilir. 
        //      Bu adres, token doðrulamasýnda kullanýlýr.
        options.Authority = builder.Configuration["AuthenticationSettings:Authority"];

        // 1.b) Audience: Token içinde "aud" claim'ine karþýlýk gelen deðerdir.
        //      Yani bu API'nin kimliði. Token'ýn 'aud' claim'i bu deðerle eþleþmezse doðrulama baþarýsýz olur.
        options.Audience = builder.Configuration["AuthenticationSettings:Audience"];

        // 1.c) Geliþtirme/test ortamýnda metadata doðrulamasý (HTTPS vb.) esneklik olsun diye kapatýlmýþ.
        options.RequireHttpsMetadata = false;

        // 1.d) Token doðrulamasý baþarýlý olduktan hemen sonra çalýþacak bir event tanýmlýyoruz.
        //      Burada "scope" claim'ini parçalayarak birden fazla "scope" claim'i haline dönüþtürüyoruz.
        options.Events = new()
        {
            OnTokenValidated = async context =>
            {
                // Token doðrulandýktan sonra kimlik bilgilerini (ClaimsIdentity) alýyoruz.
                if (context.Principal?.Identity is ClaimsIdentity claimsIdentity)
                {
                    // Token'da "scope" isminde bir claim var mý? Örn. scope="read write"
                    Claim? scopeClaim = claimsIdentity.FindFirst("scope");
                    if (scopeClaim is not null)
                    {
                        // Tek bir claim içinde "read write" yazýyorsa, önce bu claim'i siliyoruz...
                        claimsIdentity.RemoveClaim(scopeClaim);

                        // ...sonra boþlukla ayrýlmýþ deðerleri tek tek yeni "scope" claim’leri olarak ekliyoruz.
                        // Böylece "read write" yerine iki ayrý claim oluþur: ("scope": "read"), ("scope": "write").
                        claimsIdentity.AddClaims(
                            scopeClaim.Value
                                      .Split(" ") // "read write" -> ["read", "write"]
                                      .Select(s => new Claim("scope", s))
                                      .ToList()
                        );
                    }
                }
                await Task.CompletedTask;
            }
        };
    });

// 2) Yetkilendirme (Authorization) ayarlarýný yapýyoruz. Policy bazlý yaklaþýmla "scope" veya
//    diðer claim'lere göre hangi endpoint'lere eriþilebileceðini tanýmlýyoruz.
builder.Services.AddAuthorization(options =>
{
    // APolicy -> Kullanýcýnýn token'ýnda "scope" adýnda bir claim olmalý ve deðeri "read" olmalý.
    options.AddPolicy("APolicy", policy => policy.RequireClaim("scope", "read"));

    // BPolicy -> "scope" deðeri "write" olan claim'e ihtiyaç duyar.
    options.AddPolicy("BPolicy", policy => policy.RequireClaim("scope", "write"));

    // CPolicy -> "scope" claim'i "read" veya "write" deðerlerinden birini içermeli.
    // RequireClaim'in string dizi parametresi, bu claim'in en az birine eþit olmasý gerektiði anlamýna gelir.
    options.AddPolicy("CPolicy", policy => policy.RequireClaim("scope", "read", "write"));

    // DPolicy -> "ozel-claim" adýndaki claim'in "ozel-claim-value" deðerine sahip olmasý gerekir.
    // Örneðin Authorization Server tarafýnda token oluþtururken "ozel-claim" eklemiþtik.
    options.AddPolicy("DPolicy", policy => policy.RequireClaim("ozel-claim", "ozel-claim-value"));
});

var app = builder.Build();

// 3) Geliþtirme ortamýndaysak Swagger arayüzünü aktif ediyoruz. 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 4) Sýrasýyla kimlik doðrulama (UseAuthentication) ve yetkilendirme (UseAuthorization) middleware'lerini aktif ediyoruz.
app.UseAuthentication();
app.UseAuthorization();

// 5) Controller'larý devreye alýyoruz. 
//    Buradaki controller/metotlarda [Authorize(Policy="APolicy")] gibi attributelerle koruma saðlayabilirsin.
app.MapControllers();

app.Run();
