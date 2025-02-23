using OpenIddict.EntityFrameworkCore.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenIddict.AuthorizationServer.Model
{
    public class OpenIdApplication : OpenIddictEntityFrameworkCoreApplication<string, OpenIdAuthorization, OpenIdToken>
    {
        public OpenIdApplication() : base()
        {
            Id = System.Guid.NewGuid().ToString();
        }
    }
}
