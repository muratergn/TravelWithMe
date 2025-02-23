using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OpenIddict.AuthorizationServer.Context;
using OpenIddict.AuthorizationServer.Models;

var builder = WebApplication.CreateBuilder(args);

// 1) MVC yapýsýný aktif ediyoruz (Controller + View).
builder.Services.AddControllersWithViews();

// 2) Cookie tabanlý kimlik doðrulama ayarlarýný ekliyoruz.
//    - Varsayýlan þema "Cookies" olsun.
//    - Login path olarak "/account/login" belirlendi (kimlik doðrulamasý olmayan
//      kullanýcý korumalý bir alana gitmek istediðinde otomatik olarak bu path'e yönlendirilir).
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
        options.LoginPath = "/account/login"
    );

// 3) OpenIddict servisini DI Container'a ekliyoruz.
//    Bu yapý, OAuth 2.0 / OpenID Connect akýþlarýný yönetmemizi saðlar.
builder.Services.AddOpenIddict()

    // 3.a) OpenIddict Core (çekirdek) konfigürasyonu
    .AddCore(options =>
    {
        // Entity Framework Core kullanacaðýmýzý bildiriyoruz.
        // Veritabanýnda OpenIddict'e ait tablolarý EF Core ile oluþturmak/okumak için.
        options.UseEntityFrameworkCore()
               // Hangi DbContext sýnýfýný kullanacaðýmýzý belirtiyoruz.
               .UseDbContext<ApplicationDbContext>();
    })

    // 3.b) OpenIddict Server (sunucu) konfigürasyonu
    .AddServer(options =>
    {
        // Token talep edilecek endpoint (URL) belirliyoruz.
        // /connect/token endpoint'i üzerinden token isteyeceðiz.
        options.SetTokenEndpointUris("/connect/token");

        // Hangi akýþ (flow) türlerini destekleyeceðimizi belirtiyoruz.
        // Burada Client Credentials Flow etkinleþtirilmiþ. (Machine to Machine senaryolarý için)
        options.AllowClientCredentialsFlow();

        // Token'larýn imzalanmasý ve isteðe baðlý þifrelenmesi için gereken anahtarlarý ekliyoruz.
        // "Ephemeral" anahtarlar, uygulama her çalýþtýðýnda sýfýrdan üretilir (geliþtirme/demo amaçlý).
        options.AddEphemeralEncryptionKey()
               .AddEphemeralSigningKey()
               // Normalde token'lar ek güvenlik için þifreli üretilir.
               // DisableAccessTokenEncryption() ile bu þifrelemeyi kapatýyoruz ki
               // jwt.io gibi araçlarda token'ýn içeriðini rahatça görebileyim.
               .DisableAccessTokenEncryption();//Bunu silmeyi unutma çünkü jwt.io gibi bir çözümleyici tarafýndan açýp
               // token'ýn içeriðini görebilmemiz için bu iþlemi yapýyoruz.

        // OpenIddict'in ASP.NET Core ile entegrasyonunu saðlýyoruz.
        options.UseAspNetCore()
               // Token endpoint'ine gelen isteklerin OpenIddict tarafýndan iþlenmesini (passthrough) etkinleþtirir.
               .EnableTokenEndpointPassthrough();

        // Hangi "scope" (yetki alanlarý) desteklenecekse burada tanýmlýyoruz.
        // Ýstemci bu scope'larý talep edebilir (örn. "read", "write").
        options.RegisterScopes("read", "write");
    });

// 4) Uygulamada kullanýlacak DbContext'i yapýlandýrýyoruz.
//    Burada "ApplicationDbContext" SQL Server'ý kullanacak þekilde ayarlanýyor.
//    OpenIddict tablolarýnýn da bu DbContext içinde yer alacaðýný UseOpenIddict() ile belirtiyoruz.


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // "OracleConnectionString" adýndaki connection string'i kullanarak EF Core'u Oracle'a yönlendiriyoruz.
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnectionString"));

    // OpenIddict'in ihtiyaç duyduðu Entity/tablolarý bu context içinde kaydediyoruz.
    options.UseOpenIddict();
});

// 5) Uygulamayý inþa ediyoruz (Builder pattern).
var app = builder.Build();

// 6) Geliþtirme ortamýnda deðilsek, hata yakalama ve HSTS ayarlarýný etkinleþtiriyoruz.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 7) HTTP -> HTTPS yönlendirmesini, statik dosya servislerini ve routing'i etkinleþtiriyoruz.
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// 8) Kimlik doðrulama ve yetkilendirme middleware'lerini devreye alýyoruz.
//    Böylece [Authorize] attribute'larý çalýþabilir ve Cookie Authentication devreye girer.
app.UseAuthentication();
app.UseAuthorization();

// 9) MVC için varsayýlan route'u tanýmlýyoruz.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 10) Uygulamayý baþlatýyoruz.
app.Run();
