using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaDbContext.Migrations
{
    public partial class Insert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address1", "Address2", "City", "Country", "District", "FirstName", "LastName", "Number", "Password", "State", "UserName", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Rua Massaharo Kanesaki", "Apto 23 Bloco 2", "Indaiatuba", "Brasil", "Jardim Sevilha", "João", "Silva", "260", "123", "São Paulo", "joao", "13339-575" },
                    { 2, "Rua João Batista Ferrari", null, "Indaiatuba", "Brasil", "Jardim Bom Princípio", "José", "Oliveira", "122", "321", "São Paulo", "jose", "13345-686" }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Flavor", "Price" },
                values: new object[,]
                {
                    { 1, "3 Queijos", 50.0 },
                    { 2, "Frango com requeijão", 59.99 },
                    { 3, "Mussarela", 42.5 },
                    { 4, "Calabresa", 42.5 },
                    { 5, "Pepperoni", 55.0 },
                    { 6, "Portuguesa", 45.0 },
                    { 7, "Veggie", 59.99 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "Date", "Total" },
                values: new object[] { 1, 1, new DateTime(2020, 8, 13, 2, 59, 6, 772, DateTimeKind.Local).AddTicks(9595), 50.0 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "Date", "Total" },
                values: new object[] { 2, 2, new DateTime(2020, 8, 14, 2, 59, 6, 774, DateTimeKind.Local).AddTicks(7060), 55.0 });

            migrationBuilder.InsertData(
                table: "OrderDeliveries",
                columns: new[] { "Id", "Address1", "Address2", "City", "Country", "District", "Number", "OrderId", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Rua Massaharo Kanesaki", "Apartamento 23 Bloco 2", "Indaiatuba", "Brasil", "Jardim Sevilha", "260", 1, "São Paulo", "13339-575" },
                    { 2, "Mário de Almeida", null, "Indaiatuba", "Brasil", "Vila Brizolla", "295", 2, "São Paulo", "13343-510" }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "PizzaId", "Quantity", "SplitPie", "Total" },
                values: new object[,]
                {
                    { 1, 1, null, 1, true, 50.0 },
                    { 2, 2, null, 1, false, 55.0 }
                });

            migrationBuilder.InsertData(
                table: "OrderItemSplits",
                columns: new[] { "Id", "OrderItemId", "PizzaId", "Price" },
                values: new object[] { 1, 1, 5, 27.5 });

            migrationBuilder.InsertData(
                table: "OrderItemSplits",
                columns: new[] { "Id", "OrderItemId", "PizzaId", "Price" },
                values: new object[] { 2, 1, 6, 22.5 });

            migrationBuilder.InsertData(
                table: "OrderItemSplits",
                columns: new[] { "Id", "OrderItemId", "PizzaId", "Price" },
                values: new object[] { 3, 2, 5, 55.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDeliveries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDeliveries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItemSplits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItemSplits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItemSplits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
