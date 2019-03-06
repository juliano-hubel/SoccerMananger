using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerManager.Infra.Migrations
{
    public partial class AlterStudentClassrooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update Classroom set StudentsClassroomsId = null;");
            migrationBuilder.Sql("update Student set StudentsClassroomsId = null;");
            migrationBuilder.Sql("delete StudentClassrooms;");

            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_Student_StudentId",
                table: "Classroom");

            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_StudentClassrooms_StudentsClassroomsId",
                table: "Classroom");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_StudentClassrooms_StudentsClassroomsId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClassrooms",
                table: "StudentClassrooms");

            migrationBuilder.DropIndex(
                name: "IX_Student_StudentsClassroomsId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Classroom_StudentId",
                table: "Classroom");

            migrationBuilder.DropIndex(
                name: "IX_Classroom_StudentsClassroomsId",
                table: "Classroom");

            migrationBuilder.DropColumn(
                name: "StudentsClassroomsId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Classroom");

            migrationBuilder.DropColumn(
                name: "StudentsClassroomsId",
                table: "Classroom");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "StudentClassrooms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClassroomId",
                table: "StudentClassrooms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClassrooms",
                table: "StudentClassrooms",
                columns: new[] { "StudentId", "ClassroomId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassrooms_ClassroomId",
                table: "StudentClassrooms",
                column: "ClassroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClassrooms_Classroom_ClassroomId",
                table: "StudentClassrooms",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClassrooms_Student_StudentId",
                table: "StudentClassrooms",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClassrooms_Classroom_ClassroomId",
                table: "StudentClassrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClassrooms_Student_StudentId",
                table: "StudentClassrooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClassrooms",
                table: "StudentClassrooms");

            migrationBuilder.DropIndex(
                name: "IX_StudentClassrooms_ClassroomId",
                table: "StudentClassrooms");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentClassrooms");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "StudentClassrooms");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentsClassroomsId",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Classroom",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentsClassroomsId",
                table: "Classroom",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClassrooms",
                table: "StudentClassrooms",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentsClassroomsId",
                table: "Student",
                column: "StudentsClassroomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_StudentId",
                table: "Classroom",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_StudentsClassroomsId",
                table: "Classroom",
                column: "StudentsClassroomsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classroom_Student_StudentId",
                table: "Classroom",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
