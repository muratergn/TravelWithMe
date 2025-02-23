using OpenIddict.EntityFrameworkCore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenIddict.AuthorizationServer.Model
{
    public class OpenIdToken : OpenIddictEntityFrameworkCoreToken<string, OpenIdApplication, OpenIdAuthorization>
    {
        public OpenIdToken() : base()
        {
            Id = System.Guid.NewGuid().ToString();
        }

        [StringLength(4000)]
        public override string? ConcurrencyToken { get; set; }

        [StringLength(4000)]
        public override string? Payload { get; set; }

        [StringLength(4000)]
        public override string? Properties { get; set; }

        [StringLength(4000)]
        public override string? ReferenceId { get; set; }

        [StringLength(4000)]
        public override string? Status { get; set; }

        [StringLength(4000)]
        public override string? Subject { get; set; }

    }
}
