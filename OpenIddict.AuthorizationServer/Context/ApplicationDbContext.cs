using Microsoft.EntityFrameworkCore;
using OpenIddict.AuthorizationServer.Model;
using System.Diagnostics.CodeAnalysis;

namespace OpenIddict.AuthorizationServer.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Burada bunlar olmamalı çünkü zaten bunlar olmasa da tablolar oluşuyor ve bunları ekleyince
        //Aynı tabloları iki kere oluşturmuş oluyoruz.
        public DbSet<OpenIdApplication> OpenIdApplications { get; set; }
        public DbSet<OpenIdAuthorization> OpenIdAuthorizations { get; set; }
        public DbSet<OpenIdScope> OpenIdScopes { get; set; }
        public DbSet<OpenIdToken> OpenIdTokens { get; set; }
    }

}
