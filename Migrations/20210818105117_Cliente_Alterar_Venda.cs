using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiFastReport.Migrations
{
    public partial class Cliente_Alterar_Venda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendaItems_Clientes_ClienteId",
                table: "VendaItems");

            migrationBuilder.DropIndex(
                name: "IX_VendaItems_ClienteId",
                table: "VendaItems");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "VendaItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "VendaItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendaItems_ClienteId",
                table: "VendaItems",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendaItems_Clientes_ClienteId",
                table: "VendaItems",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
