using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerManager.Infra.Migrations
{
    public partial class AddStudentsClassrooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StudentsClassroomsId",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentsClassroomsId",
                table: "Classroom",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentClassrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClassrooms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentsClassroomsId",
                table: "Student",
                column: "StudentsClassroomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_StudentsClassroomsId",
                table: "Classroom",
                column: "StudentsClassroomsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classroom_StudentClassrooms_StudentsClassroomsId",
                table: "Classroom",
                column: "StudentsClassroomsId",
                principalTable: "StudentClassrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_StudentClassrooms_StudentsClassroomsId",
                table: "Student",
                column: "StudentsClassroomsId",
                principalTable: "StudentClassrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_StudentClassrooms_StudentsClassroomsId",
                table: "Classroom");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_StudentClassrooms_StudentsClassroomsId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "StudentClassrooms");

            migrationBuilder.DropIndex(
                name: "IX_Student_StudentsClassroomsId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Classroom_StudentsClassroomsId",
                table: "Classroom");

            migrationBuilder.DropColumn(
                name: "StudentsClassroomsId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentsClassroomsId",
                table: "Classroom");
        }
    }
}
