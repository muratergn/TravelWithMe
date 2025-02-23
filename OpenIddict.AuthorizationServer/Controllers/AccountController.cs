using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.AuthorizationServer.ViewsModels;
using System.Security.Claims;

namespace OpenIddict.AuthorizationServer.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            // 1) Login sayfasını görüntülemek için GET isteklerini karşılar
            //    - returnUrl, kullanıcının yönlendirileceği sayfayı tutar (örn. korumalı bir sayfa).
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM model)
        {
            // 2) Login formundan gelen veriyi POST ile işler
            //    - model, kullanıcı adı ve şifre gibi bilgileri içerir.

            if (ModelState.IsValid)
            {
                // 3) Kullanıcı adı/şifre doğrulamasını yap (Örnek: veritabanı, Identity, vb.)
                //    - Kodda örnek olarak şifre kontrolü vs. yok, ama gerçek projede koymak gerek.

                // 4) Doğrulama başarılı ise kullanıcıya ait Claim’ler oluşturulur.
                List<Claim> claims = new()
                {
                    // Kullanıcının adını "Name" claim olarak ekliyoruz.
                    new Claim(ClaimTypes.Name, model.Username)
                    // İsterseniz roller veya e-posta gibi başka claim'ler de ekleyebilirsiniz.
                };

                // 5) ClaimsIdentity ve ClaimsPrincipal oluşturma
                ClaimsIdentity identity = new(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme
                );
                ClaimsPrincipal principal = new(identity);

                // 6) Normalde burada cookie tabanlı oturumu başlatmak için SignInAsync gerekir.
                //    await HttpContext.SignInAsync(
                //        CookieAuthenticationDefaults.AuthenticationScheme,
                //        principal,
                //        new AuthenticationProperties { ... }
                //    );
                //    Kod örneğinde bu satır eksik görünüyor; pratikte bunu eklemelisin.

                // 7) returnUrl boş veya geçerli değilse anasayfaya yönlendir.
                //    Kodda "TempData["returnUrl"]" kontrolü yapılmış, genellikle GET'ten POST'a veriyi taşımak için kullanılır.
                if (!Url.IsLocalUrl(TempData["returnUrl"]?.ToString()))
                {
                    TempData["returnUrl"] = "/";
                }

                // 8) Son olarak kullanıcıyı yönlendir (örnekte Home/Index).
                return RedirectToAction("Index", "Home");
            }

            // 9) ModelState geçersizse (örneğin kullanıcı adı boş gelmişse),
            //    tekrar login sayfasını modelle birlikte döndür, hata mesajları görüntülensin.
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            // 10) Çıkış (logout) işlemi
            //     Cookie’yi silmek için SignOutAsync çağrılır.
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
