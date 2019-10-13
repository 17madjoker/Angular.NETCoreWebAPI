using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularCoreApp.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    MakeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(nullable: false),
                    IsRegistered = table.Column<bool>(nullable: false),
                    ContactName = table.Column<string>(maxLength: 255, nullable: false),
                    ContactEmail = table.Column<string>(maxLength: 255, nullable: false),
                    ContactPhone = table.Column<string>(maxLength: 255, nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesFeatures",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesFeatures", x => new { x.VehicleId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_VehiclesFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclesFeatures_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Feature1" },
                    { 9, "Feature9" },
                    { 8, "Feature8" },
                    { 7, "Feature7" },
                    { 6, "Feature6" },
                    { 10, "Feature10" },
                    { 4, "Feature4" },
                    { 3, "Feature3" },
                    { 2, "Feature2" },
                    { 5, "Feature5" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "AutoBrand9" },
                    { 1, "AutoBrand1" },
                    { 2, "AutoBrand2" },
                    { 3, "AutoBrand3" },
                    { 4, "AutoBrand4" },
                    { 5, "AutoBrand5" },
                    { 6, "AutoBrand6" },
                    { 7, "AutoBrand7" },
                    { 8, "AutoBrand8" },
                    { 10, "AutoBrand10" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "MakeId", "Name" },
                values: new object[,]
                {
                    { 4, 1, "AutoModel4" },
                    { 1, 10, "AutoModel1" },
                    { 14, 9, "AutoModel14" },
                    { 13, 9, "AutoModel13" },
                    { 12, 8, "AutoModel12" },
                    { 3, 8, "AutoModel3" },
                    { 2, 8, "AutoModel2" },
                    { 26, 7, "AutoModel26" },
                    { 25, 7, "AutoModel25" },
                    { 9, 7, "AutoModel9" },
                    { 20, 6, "AutoModel20" },
                    { 11, 6, "AutoModel11" },
                    { 5, 6, "AutoModel5" },
                    { 28, 5, "AutoModel28" },
                    { 21, 5, "AutoModel21" },
                    { 10, 5, "AutoModel10" },
                    { 8, 5, "AutoModel8" },
                    { 23, 3, "AutoModel23" },
                    { 22, 3, "AutoModel22" },
                    { 19, 3, "AutoModel19" },
                    { 18, 3, "AutoModel18" },
                    { 7, 3, "AutoModel7" },
                    { 6, 2, "AutoModel6" },
                    { 27, 1, "AutoModel27" },
                    { 24, 1, "AutoModel24" },
                    { 17, 1, "AutoModel17" },
                    { 16, 1, "AutoModel16" },
                    { 15, 1, "AutoModel15" },
                    { 29, 10, "AutoModel29" },
                    { 30, 10, "AutoModel30" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId",
                table: "Models",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesFeatures_FeatureId",
                table: "VehiclesFeatures",
                column: "FeatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiclesFeatures");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Makes");
        }
    }
}
