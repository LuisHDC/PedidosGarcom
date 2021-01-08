using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaPedidos.Migrations
{
    public partial class Prato2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_cardapio",
                table: "cardapio");

            migrationBuilder.RenameTable(
                name: "cardapio",
                newName: "prato");

            migrationBuilder.AddPrimaryKey(
                name: "PK_prato",
                table: "prato",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_prato",
                table: "prato");

            migrationBuilder.RenameTable(
                name: "prato",
                newName: "cardapio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cardapio",
                table: "cardapio",
                column: "Id");
        }
    }
}
