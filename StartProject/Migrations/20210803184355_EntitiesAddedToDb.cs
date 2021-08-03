using Microsoft.EntityFrameworkCore.Migrations;

namespace StartProject.Migrations
{
    public partial class EntitiesAddedToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreHouse",
                table: "StoreHouse");

            migrationBuilder.RenameTable(
                name: "StoreHouse",
                newName: "StoreHouses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreHouses",
                table: "StoreHouses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StoreHouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_StoreHouses_StoreHouseId",
                        column: x => x.StoreHouseId,
                        principalTable: "StoreHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PickupDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickupDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreHouseAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreHouseAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreHouseAvailabilities_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreHouseAvailabilities_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PickupProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    PickupDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickupProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PickupProducts_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PickupProducts_PickupDocuments_PickupDocumentId",
                        column: x => x.PickupDocumentId,
                        principalTable: "PickupDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PickupProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Address",
                table: "Locations",
                column: "Address",
                unique: true,
                filter: "[Address] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_StoreHouseId",
                table: "Locations",
                column: "StoreHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PickupProducts_LocationId",
                table: "PickupProducts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PickupProducts_PickupDocumentId",
                table: "PickupProducts",
                column: "PickupDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PickupProducts_ProductId",
                table: "PickupProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreHouseAvailabilities_LocationId",
                table: "StoreHouseAvailabilities",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreHouseAvailabilities_ProductId",
                table: "StoreHouseAvailabilities",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PickupProducts");

            migrationBuilder.DropTable(
                name: "StoreHouseAvailabilities");

            migrationBuilder.DropTable(
                name: "PickupDocuments");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreHouses",
                table: "StoreHouses");

            migrationBuilder.RenameTable(
                name: "StoreHouses",
                newName: "StoreHouse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreHouse",
                table: "StoreHouse",
                column: "Id");
        }
    }
}
