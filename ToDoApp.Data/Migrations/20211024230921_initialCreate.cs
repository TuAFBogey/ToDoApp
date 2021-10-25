using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Data.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Daily")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "DateTime", "Name", "Period" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), "Learn SQL", "Monthly" },
                    { 2, new DateTime(2021, 11, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "Learn MVC", "Monthly" },
                    { 3, new DateTime(2021, 10, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), "Write Data Layer", "Weekly" }
                });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "DateTime", "IsComplete", "Name", "Period" },
                values: new object[,]
                {
                    { 4, new DateTime(2021, 10, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), true, "Develop the ToDoApp", "Weekly" },
                    { 5, new DateTime(2021, 10, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), true, "Check the MailBox", "Daily" },
                    { 6, new DateTime(2021, 10, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), true, "Something", "Daily" }
                });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "DateTime", "Name", "Period" },
                values: new object[] { 7, new DateTime(2021, 10, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "BlaBla", "Weekly" });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "DateTime", "IsComplete", "Name", "Period" },
                values: new object[] { 8, new DateTime(2021, 11, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), true, "EtcEtc", "Monthly" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");
        }
    }
}
