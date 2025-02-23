using OpenIddict.EntityFrameworkCore.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenIddict.AuthorizationServer.Model
{
    public class OpenIdAuthorization : OpenIddictEntityFrameworkCoreAuthorization<string, OpenIdApplication, OpenIdToken>
    {
        public OpenIdAuthorization() : base()
        {
            Id = System.Guid.NewGuid().ToString();
        }

    }
}
