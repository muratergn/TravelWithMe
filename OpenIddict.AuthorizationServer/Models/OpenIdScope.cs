using OpenIddict.EntityFrameworkCore.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenIddict.AuthorizationServer.Model
{
    public class OpenIdScope : OpenIddictEntityFrameworkCoreScope<string>
    {
        public OpenIdScope() : base()
        {
            Id = System.Guid.NewGuid().ToString();
        }
    }
}
