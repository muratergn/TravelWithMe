using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenIddict.AuthorizationServer.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OpenIdApplications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ApplicationType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClientId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClientSecret = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClientType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ConsentType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DisplayName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DisplayNames = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    JsonWebKeySet = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Permissions = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PostLogoutRedirectUris = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Properties = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RedirectUris = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Requirements = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Settings = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIdApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictApplications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ApplicationType = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    ClientId = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ClientSecret = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClientType = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    ConsentType = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    DisplayName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DisplayNames = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    JsonWebKeySet = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Permissions = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PostLogoutRedirectUris = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Properties = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RedirectUris = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Requirements = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Settings = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictScopes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ConcurrencyToken = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Descriptions = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DisplayName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DisplayNames = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Name = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    Properties = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Resources = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIdScopes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ConcurrencyToken = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Descriptions = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DisplayName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DisplayNames = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Properties = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Resources = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIdScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIdAuthorizations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ApplicationId = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Properties = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Scopes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Subject = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Type = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIdAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIdAuthorizations_OpenIdApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIdApplications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictAuthorizations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ApplicationId = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Properties = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Scopes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Status = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "NVARCHAR2(400)", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictAuthorizations_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenIdTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ConcurrencyToken = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    Payload = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    Properties = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    ReferenceId = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    Status = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    Subject = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    ApplicationId = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    AuthorizationId = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    RedemptionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Type = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIdTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIdTokens_OpenIdApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIdApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenIdTokens_OpenIdAuthorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "OpenIdAuthorizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ApplicationId = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    AuthorizationId = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Payload = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Properties = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RedemptionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ReferenceId = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "NVARCHAR2(400)", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "OpenIddictAuthorizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIdAuthorizations_ApplicationId",
                table: "OpenIdAuthorizations",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplications_ClientId",
                table: "OpenIddictApplications",
                column: "ClientId",
                unique: true,
                filter: "\"ClientId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type",
                table: "OpenIddictAuthorizations",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictScopes_Name",
                table: "OpenIddictScopes",
                column: "Name",
                unique: true,
                filter: "\"Name\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ApplicationId_Status_Subject_Type",
                table: "OpenIddictTokens",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_AuthorizationId",
                table: "OpenIddictTokens",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                table: "OpenIddictTokens",
                column: "ReferenceId",
                unique: true,
                filter: "\"ReferenceId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIdTokens_ApplicationId",
                table: "OpenIdTokens",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIdTokens_AuthorizationId",
                table: "OpenIdTokens",
                column: "AuthorizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpenIddictScopes");

            migrationBuilder.DropTable(
                name: "OpenIddictTokens");

            migrationBuilder.DropTable(
                name: "OpenIdScopes");

            migrationBuilder.DropTable(
                name: "OpenIdTokens");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations");

            migrationBuilder.DropTable(
                name: "OpenIdAuthorizations");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications");

            migrationBuilder.DropTable(
                name: "OpenIdApplications");
        }
    }
}
