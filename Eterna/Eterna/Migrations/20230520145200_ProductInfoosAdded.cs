using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eterna.Migrations
{
    public partial class ProductInfoosAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductClient",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductClient", x => new { x.ProductId, x.ClientId });
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreaatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientProductClient",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    ProductClientProductId = table.Column<int>(type: "int", nullable: false),
                    ProductClientClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProductClient", x => new { x.ClientsId, x.ProductClientProductId, x.ProductClientClientId });
                    table.ForeignKey(
                        name: "FK_ClientProductClient_Client_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientProductClient_ProductClient_ProductClientProductId_ProductClientClientId",
                        columns: x => new { x.ProductClientProductId, x.ProductClientClientId },
                        principalTable: "ProductClient",
                        principalColumns: new[] { "ProductId", "ClientId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductClient",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    ProductClientProductId = table.Column<int>(type: "int", nullable: false),
                    ProductClientClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductClient", x => new { x.ProductsId, x.ProductClientProductId, x.ProductClientClientId });
                    table.ForeignKey(
                        name: "FK_ProductProductClient_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductClient_ProductClient_ProductClientProductId_ProductClientClientId",
                        columns: x => new { x.ProductClientProductId, x.ProductClientClientId },
                        principalTable: "ProductClient",
                        principalColumns: new[] { "ProductId", "ClientId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientProductClient_ProductClientProductId_ProductClientClientId",
                table: "ClientProductClient",
                columns: new[] { "ProductClientProductId", "ProductClientClientId" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductClient_ProductClientProductId_ProductClientClientId",
                table: "ProductProductClient",
                columns: new[] { "ProductClientProductId", "ProductClientClientId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientProductClient");

            migrationBuilder.DropTable(
                name: "ProductProductClient");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductClient");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
