using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularCoreApp.Migrations
{
    public partial class AddPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(maxLength: 255, nullable: false),
                    VehicleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                column: "MakeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                column: "MakeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                column: "MakeId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                column: "MakeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5,
                column: "MakeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 6,
                column: "MakeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 7,
                column: "MakeId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 8,
                column: "MakeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 9,
                column: "MakeId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 10,
                column: "MakeId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 11,
                column: "MakeId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 12,
                column: "MakeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 14,
                column: "MakeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 15,
                column: "MakeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 16,
                column: "MakeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 17,
                column: "MakeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 18,
                column: "MakeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 19,
                column: "MakeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 21,
                column: "MakeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 22,
                column: "MakeId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 23,
                column: "MakeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 24,
                column: "MakeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 25,
                column: "MakeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 26,
                column: "MakeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 27,
                column: "MakeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 28,
                column: "MakeId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 29,
                column: "MakeId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_VehicleId",
                table: "Photos",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                column: "MakeId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                column: "MakeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                column: "MakeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                column: "MakeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5,
                column: "MakeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 6,
                column: "MakeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 7,
                column: "MakeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 8,
                column: "MakeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 9,
                column: "MakeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 10,
                column: "MakeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 11,
                column: "MakeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 12,
                column: "MakeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 14,
                column: "MakeId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 15,
                column: "MakeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 16,
                column: "MakeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 17,
                column: "MakeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 18,
                column: "MakeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 19,
                column: "MakeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 21,
                column: "MakeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 22,
                column: "MakeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 23,
                column: "MakeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 24,
                column: "MakeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 25,
                column: "MakeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 26,
                column: "MakeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 27,
                column: "MakeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 28,
                column: "MakeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 29,
                column: "MakeId",
                value: 10);
        }
    }
}
