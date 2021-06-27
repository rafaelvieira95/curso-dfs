using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class addCompanyCnpjCorporateNameUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Companies_Cnpj",
                table: "Companies",
                column: "Cnpj");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Companies_CorporateName",
                table: "Companies",
                column: "CorporateName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Companies_Cnpj",
                table: "Companies");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Companies_CorporateName",
                table: "Companies");
        }
    }
}
