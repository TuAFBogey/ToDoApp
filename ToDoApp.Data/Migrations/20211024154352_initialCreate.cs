using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Data.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoLists",
                columns: table => new
                {
                    ToDoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToDoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoLists", x => x.ToDoId);
                });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoId", "DateTime", "IsComplete", "Period", "ToDoName" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), false, "Monthly", "Learn SQL" },
                    { 2, new DateTime(2021, 11, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), false, "Monthly", "Learn MVC" },
                    { 3, new DateTime(2021, 10, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), false, "Weekly", "Write Data Layer" },
                    { 4, new DateTime(2021, 10, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), true, "Weekly", "Develop the ToDoApp" },
                    { 5, new DateTime(2021, 10, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), true, "Daily", "Check the MailBox" },
                    { 6, new DateTime(2021, 10, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), true, "Daily", "Something" },
                    { 7, new DateTime(2021, 10, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), false, "Weekly", "BlaBla" },
                    { 8, new DateTime(2021, 11, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), true, "Monthly", "EtcEtc" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoLists");
        }
    }
}
