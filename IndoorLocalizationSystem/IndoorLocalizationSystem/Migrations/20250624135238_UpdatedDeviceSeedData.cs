using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndoorLocalizationSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDeviceSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PositionX", "PositionY" },
                values: new object[] { 1.73f, 2.5f });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PositionX", "PositionY" },
                values: new object[] { 1.83f, 2.1f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PositionX", "PositionY" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PositionX", "PositionY" },
                values: new object[] { 0f, 0f });
        }
    }
}
