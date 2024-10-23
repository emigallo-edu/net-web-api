using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_CUSTOMERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CUSTOMERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_PRODUCTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PRODUCTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_ORDERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ORDERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_ORDERS_T_CUSTOMERS_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "T_CUSTOMERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ORDER_ITEMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(name: "Order_Id", type: "int", nullable: false),
                    ProductId = table.Column<int>(name: "Product_Id", type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ORDER_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_ORDER_ITEMS_T_ORDERS_Order_Id",
                        column: x => x.OrderId,
                        principalTable: "T_ORDERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_ORDER_ITEMS_T_PRODUCTS_Product_Id",
                        column: x => x.ProductId,
                        principalTable: "T_PRODUCTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_ORDER_ITEMS_Order_Id",
                table: "T_ORDER_ITEMS",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_T_ORDER_ITEMS_Product_Id",
                table: "T_ORDER_ITEMS",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_T_ORDERS_CustomerId",
                table: "T_ORDERS",
                column: "CustomerId");

            migrationBuilder.Sql("INSERT INTO T_PRODUCTS(Description, Family) VALUES('Alfajor chocolate', 'Golosina')");
            migrationBuilder.Sql("INSERT INTO T_PRODUCTS(Description, Family) VALUES('Alfajor dulce de leche', 'Golosina')");
            migrationBuilder.Sql("INSERT INTO T_PRODUCTS(Description, Family) VALUES('Caramelo fruta', 'Golosina')");
            migrationBuilder.Sql("INSERT INTO T_PRODUCTS(Description, Family) VALUES('Jabón', 'Higiene personal')");
            migrationBuilder.Sql("INSERT INTO T_PRODUCTS(Description, Family) VALUES('Desodorante', 'Higiene personal')");
            migrationBuilder.Sql("INSERT INTO T_PRODUCTS(Description, Family) VALUES('Fideos cinta', 'Almacén')");
            migrationBuilder.Sql("INSERT INTO T_PRODUCTS(Description, Family) VALUES('Salsa de tomate', 'Almacén')");
            migrationBuilder.Sql("INSERT INTO T_CUSTOMERS(Name, Address, City) VALUES('7 Eleven', 'Doctor Esquerdo 85', 'Buenos Aires')");
            migrationBuilder.Sql("INSERT INTO T_CUSTOMERS(Name, Address, City) VALUES('DuniaTours', 'Diego de Leon 5', 'Neuquen')");
            migrationBuilder.Sql("INSERT INTO T_CUSTOMERS(Name, Address, City) VALUES('Focultur', 'Carrera de San Jerónimo 27', 'Santa Fe')");
            migrationBuilder.Sql("INSERT INTO T_ORDERS(Date, CustomerId, DeliveryDate) VALUES(GETDATE(), 1, GETDATE())");
            migrationBuilder.Sql("INSERT INTO T_ORDER_ITEMS(Order_Id, Product_Id, Amount) VALUES(2, 2, 100)");
            migrationBuilder.Sql("INSERT INTO T_ORDER_ITEMS(Order_Id, Product_Id, Amount) VALUES(2, 4, 183)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ORDER_ITEMS");

            migrationBuilder.DropTable(
                name: "T_ORDERS");

            migrationBuilder.DropTable(
                name: "T_PRODUCTS");

            migrationBuilder.DropTable(
                name: "T_CUSTOMERS");
        }
    }
}
