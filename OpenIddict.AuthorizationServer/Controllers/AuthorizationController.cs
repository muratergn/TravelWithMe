using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;
using System.Security.Claims;

namespace OpenIddict.AuthorizationServer.Controllers
{
    public class AuthorizationController : Controller
    {
        readonly IOpenIddictApplicationManager _applicationManager;

        public AuthorizationController(IOpenIddictApplicationManager applicationManager)
        {
            _applicationManager = applicationManager;
        }

        // 1) Bu action'ın endpoint'ini "~/connect/token" olarak tanımlıyoruz.
        //    Yani OAuth2/OpenID Connect "token endpoint" isteği buraya gelecek.
        //    Exchange() metodu, client_credentials akışına gelen token isteklerini karşılamak üzere tasarlanmıştır.
        [HttpPost("~/connect/token")]
        public async Task<IActionResult> Exchange()
        {
            // 2) OpenIddict'in sağladığı bir extension metodu: HTTP isteğini (grant_type, client_id, vb.)
            //    OpenIddictServerRequest nesnesine dönüştürür.
            var request = HttpContext.GetOpenIddictServerRequest();

            // 3) Eğer istek "client_credentials" grant type ise buraya gireceğiz.
            //    IsClientCredentialsGrantType() -> grant_type=client_credentials olup olmadığını kontrol eder.
            //    Geçerli değilse null döner veya buraya girmez.
            if (request?.IsClientCredentialsGrantType() is not null)
            {
                // 4) OpenIddict, client_id/client_secret doğrulamasını otomatik yapar.
                //    Eğer client_id/secret yanlışsa, bu koda ulaşmadan hata döndürür.
                //    Doğruysa, "application" veritabanında bulunur.
                var application = await _applicationManager.FindByClientIdAsync(request.ClientId);
                if (application is null)
                    throw new InvalidOperationException("This clientId was not found");

                // 5) Token'a koyacağımız claim'leri temsil eden bir ClaimsIdentity oluşturuyoruz.
                //    OpenIddictServerAspNetCoreDefaults.AuthenticationScheme -> OpenIddict'e özel kimlik doğrulama şeması.
                var identity = new ClaimsIdentity(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

                // 6) Token'a claim'leri ekleyelim. Bazı claim'ler (örneğin 'sub') zorunlu olabilir.
                //    - Claims.Subject -> genellikle "sub" claim'i (kime ait olduğu).
                //    - Claims.Name -> client uygulamanın 'display name'i veya kimliği.
                //    - "ozel-claim" -> kendi özel bilgimizi ekliyoruz (ör. "ozel-claim-value").
                //    - "aud" (JwtRegisteredClaimNames.Aud) -> token'ın hedef aldığı (audience) servisi belirtir.
                identity.AddClaim(
                    Claims.Subject,
                    (await _applicationManager.GetClientIdAsync(application)
                     ?? throw new InvalidOperationException())
                );

                identity.AddClaim(
                    Claims.Name,
                    (await _applicationManager.GetDisplayNameAsync(application)
                     ?? throw new InvalidOperationException())
                );

                identity.AddClaim("ozel-claim", "ozel-claim-value");

                identity.AddClaim(JwtRegisteredClaimNames.Aud, "Example-OpenIddict");

                // 7) ClaimsIdentity'yi bir ClaimsPrincipal'a dönüştürüyoruz.
                var claimsPrincipal = new ClaimsPrincipal(identity);

                // 8) Token'a eklediğimiz her claim'in hangi token türlerinde (AccessToken, IdentityToken) yer alacağını belirtiyoruz.
                //     Burada foreach ile tüm claim'lere aynı destinasyonları veriyoruz.
                foreach (var claim in claimsPrincipal.Claims)
                    claim.SetDestinations(Destinations.AccessToken, Destinations.IdentityToken);

                // 9) Gelen istekte talep edilen scope'lar varsa, bunları principal'a ekliyoruz.
                //     Örneğin client "/connect/token?scope=read%20write" gibi bir istek yaparsa,
                //     token içinde "read" ve "write" scope'ları yer alabilir.
                claimsPrincipal.SetScopes(request.GetScopes());

                // 10) "SignIn" döndürmek, OpenIddict'e "Bu principal'a dayalı olarak token üret" demek.
                //     - Access Token (ve eğer akış gerektiriyorsa Identity Token) oluşturulur.
                //     - JSON olarak { "access_token": "...", "token_type": "Bearer", ... } şeklinde geri döner.
                return SignIn(claimsPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            // 11) Eğer grant_type "client_credentials" değilse, bu örnekte desteklemediğimiz için
            //     NotImplementedException fırlatıyoruz.
            throw new NotImplementedException("The specified grant type is not implemented.");
        }
    }


}
