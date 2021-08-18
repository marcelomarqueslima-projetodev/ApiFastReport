using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiFastReport.Migrations
{
    public partial class Seeds_Input_Dados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "CreateAt", "Descricao", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 18, 12, 7, 19, 219, DateTimeKind.Utc).AddTicks(8839), "Combustivel", null },
                    { 2, new DateTime(2021, 8, 18, 12, 7, 19, 219, DateTimeKind.Utc).AddTicks(8851), "Lubrificantes", null },
                    { 3, new DateTime(2021, 8, 18, 12, 7, 19, 219, DateTimeKind.Utc).AddTicks(8856), "Diversos", null }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CreateAt", "Email", "Nome", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(5279), "sofia@mail.com", "Sofia Marli Porto", null },
                    { 2, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(5286), "raimunda@mail.com", "Raimunda Isis Olivia Vieira", null },
                    { 3, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(5289), "oliver@mail.com", "Oliver Arthur da Mota", null }
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "CreateAt", "Email", "Foto", "Nome", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 8, 18, 12, 7, 19, 217, DateTimeKind.Utc).AddTicks(9336), "postocidade@mail.com", "", "Posto de Gasolina Cidade", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Nome", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(3693), "fernandosilva@mail.com", "Fernando Silva", null },
                    { 2, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(3701), "marcos@mail.com", "Marcos", null },
                    { 3, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(3704), "ellena@mail.com", "Ellena", null },
                    { 4, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(3707), "Rafaela@mail.com", "Rafaela", null },
                    { 5, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(3709), "heloisa@mail.com", "Heloisa", null },
                    { 6, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(3712), "manuella@mail.com", "Manuella", null },
                    { 7, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(3714), "luan@mail.com", "Luan", null }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "CreateAt", "Descricao", "Ean", "Preco", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(1369), "Gasolina Aditivada", "9789563530701", 5.50m, null },
                    { 2, 1, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(1827), "Gasolina Comum", "9789563530702", 5.10m, null },
                    { 3, 1, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(1832), "Alcool Comum", "9789563530703", 4.00m, null },
                    { 4, 1, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(1835), "Alcool Aditivado", "9789563530704", 4.15m, null },
                    { 5, 1, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(1837), "Diesel", "9789563530705", 3.98m, null },
                    { 6, 2, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(1840), "Óleo Lubrificante Motor 20w", "9789563530710", 20.00m, null },
                    { 7, 2, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(1843), "Óleo Lubrificante Motor 40w", "9789563530711", 21.00m, null },
                    { 8, 3, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(1846), "Água sem Gás", "9789563530720", 2.00m, null },
                    { 9, 3, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(1849), "Água com Gás", "9789563530721", 2.10m, null }
                });

            migrationBuilder.InsertData(
                table: "Vendas",
                columns: new[] { "Id", "ClienteId", "CreateAt", "DataVenda", "TotalVenda", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, 1, new DateTime(2021, 8, 20, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(7587), new DateTime(2021, 8, 20, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(7447), 200.00m, null },
                    { 1, 2, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(6931), new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(6452), 100.00m, null },
                    { 2, 3, new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(7443), new DateTime(2021, 8, 18, 12, 7, 19, 220, DateTimeKind.Utc).AddTicks(7439), 75.00m, null }
                });

            migrationBuilder.InsertData(
                table: "VendaItems",
                columns: new[] { "Id", "CreateAt", "ProdutoId", "Quantidade", "TotalProduto", "UpdatedAt", "ValorProduto", "VendaId" },
                values: new object[,]
                {
                    { 4, new DateTime(2021, 8, 18, 12, 7, 20, 61, DateTimeKind.Utc).AddTicks(2854), 5, 50.24m, 200.00m, null, 3.98m, 3 },
                    { 1, new DateTime(2021, 8, 18, 12, 7, 20, 42, DateTimeKind.Utc).AddTicks(8779), 2, 18.18m, 100.00m, null, 5.50m, 1 },
                    { 2, new DateTime(2021, 8, 18, 12, 7, 20, 61, DateTimeKind.Utc).AddTicks(1654), 1, 9.80m, 50.00m, null, 5.10m, 2 },
                    { 3, new DateTime(2021, 8, 18, 12, 7, 20, 61, DateTimeKind.Utc).AddTicks(2506), 9, 12m, 25.00m, null, 2.10m, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VendaItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VendaItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VendaItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VendaItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Vendas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vendas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vendas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
