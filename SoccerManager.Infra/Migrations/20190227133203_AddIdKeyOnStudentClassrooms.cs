using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerManager.Infra.Migrations
{
    public partial class AddIdKeyOnStudentClassrooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_StudentClassrooms_Id",
                table: "StudentClassrooms",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_StudentClassrooms_Id",
                table: "StudentClassrooms");
        }
    }
}
