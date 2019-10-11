using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularCoreApp.Migrations
{
    public partial class InitialCreate : Migration
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
                    { 3, 1, "AutoModel3" },
                    { 24, 9, "AutoModel24" },
                    { 14, 9, "AutoModel14" },
                    { 12, 9, "AutoModel12" },
                    { 10, 9, "AutoModel10" },
                    { 5, 9, "AutoModel5" },
                    { 30, 8, "AutoModel30" },
                    { 21, 8, "AutoModel21" },
                    { 19, 8, "AutoModel19" },
                    { 16, 8, "AutoModel16" },
                    { 1, 8, "AutoModel1" },
                    { 29, 7, "AutoModel29" },
                    { 27, 7, "AutoModel27" },
                    { 6, 7, "AutoModel6" },
                    { 15, 6, "AutoModel15" },
                    { 13, 6, "AutoModel13" },
                    { 28, 5, "AutoModel28" },
                    { 7, 5, "AutoModel7" },
                    { 22, 4, "AutoModel22" },
                    { 20, 3, "AutoModel20" },
                    { 18, 3, "AutoModel18" },
                    { 9, 3, "AutoModel9" },
                    { 2, 3, "AutoModel2" },
                    { 25, 2, "AutoModel25" },
                    { 11, 2, "AutoModel11" },
                    { 8, 2, "AutoModel8" },
                    { 4, 2, "AutoModel4" },
                    { 23, 1, "AutoModel23" },
                    { 26, 9, "AutoModel26" },
                    { 17, 10, "AutoModel17" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId",
                table: "Models",
                column: "MakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Makes");
        }
    }
}
