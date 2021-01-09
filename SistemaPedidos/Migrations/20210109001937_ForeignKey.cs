using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaPedidos.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedido_Bebida_BebidaID",
                table: "pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_pedido_prato_PratoId",
                table: "pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_prato",
                table: "prato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pedido",
                table: "pedido");

            migrationBuilder.RenameTable(
                name: "prato",
                newName: "Prato");

            migrationBuilder.RenameTable(
                name: "pedido",
                newName: "Pedido");

            migrationBuilder.RenameColumn(
                name: "BebidaID",
                table: "Pedido",
                newName: "BebidaId");

            migrationBuilder.RenameIndex(
                name: "IX_pedido_PratoId",
                table: "Pedido",
                newName: "IX_Pedido_PratoId");

            migrationBuilder.RenameIndex(
                name: "IX_pedido_BebidaID",
                table: "Pedido",
                newName: "IX_Pedido_BebidaId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Bebida",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "PratoId",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BebidaId",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prato",
                table: "Prato",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Bebida_BebidaId",
                table: "Pedido",
                column: "BebidaId",
                principalTable: "Bebida",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Prato_PratoId",
                table: "Pedido",
                column: "PratoId",
                principalTable: "Prato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Bebida_BebidaId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Prato_PratoId",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prato",
                table: "Prato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido");

            migrationBuilder.RenameTable(
                name: "Prato",
                newName: "prato");

            migrationBuilder.RenameTable(
                name: "Pedido",
                newName: "pedido");

            migrationBuilder.RenameColumn(
                name: "BebidaId",
                table: "pedido",
                newName: "BebidaID");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_PratoId",
                table: "pedido",
                newName: "IX_pedido_PratoId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_BebidaId",
                table: "pedido",
                newName: "IX_pedido_BebidaID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bebida",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "PratoId",
                table: "pedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BebidaID",
                table: "pedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_prato",
                table: "prato",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pedido",
                table: "pedido",
                column: "Id");

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
    }
}
