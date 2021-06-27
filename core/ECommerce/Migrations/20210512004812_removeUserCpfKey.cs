using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class removeUserCpfKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Users_UserCpf",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_UserCpf",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "UserCpf",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Purchases",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Cpf",
                table: "Users",
                column: "Cpf");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Users_UserId",
                table: "Purchases",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Users_UserId",
                table: "Purchases");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Cpf",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Purchases");

            migrationBuilder.AddColumn<string>(
                name: "UserCpf",
                table: "Purchases",
                type: "character varying(11)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserCpf",
                table: "Purchases",
                column: "UserCpf");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Users_UserCpf",
                table: "Purchases",
                column: "UserCpf",
                principalTable: "Users",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
