using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaPedidos.Migrations
{
    public partial class Bebida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bebida",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "Prato",
                table: "pedido");

            migrationBuilder.AddColumn<int>(
                name: "BebidaID",
                table: "pedido",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PratoId",
                table: "pedido",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bebida",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebida", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pedido_BebidaID",
                table: "pedido",
                column: "BebidaID");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_PratoId",
                table: "pedido",
                column: "PratoId");

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_Bebida_BebidaID",
                table: "pedido",
                column: "BebidaID",
                principalTable: "Bebida",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_prato_PratoId",
                table: "pedido",
                column: "PratoId",
                principalTable: "prato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedido_Bebida_BebidaID",
                table: "pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_pedido_prato_PratoId",
                table: "pedido");

            migrationBuilder.DropTable(
                name: "Bebida");

            migrationBuilder.DropIndex(
                name: "IX_pedido_BebidaID",
                table: "pedido");

            migrationBuilder.DropIndex(
                name: "IX_pedido_PratoId",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "BebidaID",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "PratoId",
                table: "pedido");

            migrationBuilder.AddColumn<string>(
                name: "Bebida",
                table: "pedido",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prato",
                table: "pedido",
                nullable: true);
        }
    }
}
