using Microsoft.EntityFrameworkCore.Migrations;

namespace _10IyunTask.Migrations
{
    public partial class FirstMigis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sliders",
                table: "sliders");

            migrationBuilder.RenameTable(
                name: "sliders",
                newName: "Sliders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sliders",
                table: "Sliders",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sliders",
                table: "Sliders");

            migrationBuilder.RenameTable(
                name: "Sliders",
                newName: "sliders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sliders",
                table: "sliders",
                column: "Id");
        }
    }
}
