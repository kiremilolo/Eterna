using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eterna.Migrations
{
    public partial class UpdatedProductClientMtMRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientProductClient");

            migrationBuilder.DropTable(
                name: "ProductProductClient");

            migrationBuilder.CreateIndex(
                name: "IX_ProductClient_ClientId",
                table: "ProductClient",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductClient_Client_ClientId",
                table: "ProductClient",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductClient_Product_ProductId",
                table: "ProductClient",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductClient_Client_ClientId",
                table: "ProductClient");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductClient_Product_ProductId",
                table: "ProductClient");

            migrationBuilder.DropIndex(
                name: "IX_ProductClient_ClientId",
                table: "ProductClient");

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
                name: "IX_ProductProductClient_ProductClientProductId_ProductClientClientId",
                table: "ProductProductClient",
                columns: new[] { "ProductClientProductId", "ProductClientClientId" });
        }
    }
}
