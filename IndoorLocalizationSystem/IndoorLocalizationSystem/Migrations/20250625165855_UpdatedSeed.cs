using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IndoorLocalizationSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Devices_DeviceId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DeviceId",
                table: "Students");

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[,]
                {
                    { 3, 0, "Room 202" },
                    { 4, 0, "Lab B" }
                });

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Alice's iPhone");

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MACAddress", "Name", "PositionX" },
                values: new object[] { "AA:BB:CC:DD:EE:02", "Bob's Galaxy", 1.8f });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "hashed1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "hashed2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "hashed3");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 4, "elena@university.edu", "hashed4", "Student", "elena" },
                    { 5, "miller@university.edu", "hashed5", "Professor", "miller" },
                    { 6, "smith@university.edu", "hashed6", "Professor", "smith" },
                    { 7, "brown@university.edu", "hashed6", "Student", "brown" },
                    { 8, "king@university.edu", "hashed6", "Student", "king" },
                    { 9, "stone@university.edu", "hashed6", "Student", "stone" }
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 2, "Prof. Miller", 5 },
                    { 3, "Dr. Smith", 6 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Attended", "ClassroomId", "DeviceId", "Name", "UserId" },
                values: new object[,]
                {
                    { 3, true, 3, 3, "Elena White", 4 },
                    { 4, true, 1, 4, "Liam Brown", 7 },
                    { 5, false, 2, 5, "Noah King", 8 },
                    { 6, true, 4, 6, "Emma Stone", 9 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "ClassroomId", "Name", "ProfessorId" },
                values: new object[,]
                {
                    { "3", 3, "Embedded Systems", 2 },
                    { "4", 4, "AI in Edge Devices", 3 }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "MACAddress", "Name", "PositionX", "PositionY", "StudentId" },
                values: new object[,]
                {
                    { 3, "AA:BB:CC:DD:EE:03", "Elena's Pixel", 2f, 3f, 3 },
                    { 4, "AA:BB:CC:DD:EE:04", "Liam's Tablet", 2.5f, 1.5f, 4 },
                    { 5, "AA:BB:CC:DD:EE:05", "Noah's Phone", 3.2f, 2.3f, 5 },
                    { 6, "AA:BB:CC:DD:EE:06", "Emma's Phone", 3f, 1f, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_StudentId",
                table: "Devices",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Students_StudentId",
                table: "Devices",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Students_StudentId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_StudentId",
                table: "Devices");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: 4);

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
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Alice's iphone");

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MACAddress", "Name", "PositionX" },
                values: new object[] { "AA:BF:CC:DD:EC:02", "Bob's iphone", 1.83f });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "hashedPassword123");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "hashedPassword1234");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "hashedPassword12345");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DeviceId",
                table: "Students",
                column: "DeviceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Devices_DeviceId",
                table: "Students",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
