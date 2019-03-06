using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerManager.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Neighborhood = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CellPhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BankName = table.Column<string>(nullable: false),
                    Agency = table.Column<string>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Health",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    BloodPressure = table.Column<string>(nullable: true),
                    Allergies = table.Column<string>(nullable: true),
                    Disabilities = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Health", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MaxAge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admnistrator",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name_FirstName = table.Column<string>(nullable: false),
                    Name_LastName = table.Column<string>(nullable: false),
                    Name_RG = table.Column<string>(nullable: false),
                    Name_CPF = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DateEntered = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    BankAccountId = table.Column<Guid>(nullable: true),
                    Earnings = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admnistrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admnistrator_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admnistrator_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name_FirstName = table.Column<string>(nullable: false),
                    Name_LastName = table.Column<string>(nullable: false),
                    Name_RG = table.Column<string>(nullable: true),
                    Name_CPF = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DateEntered = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    BankAccountId = table.Column<Guid>(nullable: true),
                    Earnings = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teacher_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    StudentCategoryId = table.Column<Guid>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_StudentCategory_StudentCategoryId",
                        column: x => x.StudentCategoryId,
                        principalTable: "StudentCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TeamId = table.Column<Guid>(nullable: true),
                    Adversary = table.Column<string>(nullable: false),
                    FotoSumula = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    PlayerNumber = table.Column<int>(nullable: false),
                    CardType = table.Column<int>(nullable: false),
                    MatchId = table.Column<Guid>(nullable: true),
                    MatchId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Card_Match_MatchId1",
                        column: x => x.MatchId1,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fault",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    PlayerNumber = table.Column<int>(nullable: false),
                    MatchId = table.Column<Guid>(nullable: true),
                    MatchId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fault", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fault_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fault_Match_MatchId1",
                        column: x => x.MatchId1,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PlayerNumber = table.Column<int>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    MatchId = table.Column<Guid>(nullable: true),
                    MatchId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goal_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Goal_Match_MatchId1",
                        column: x => x.MatchId1,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name_FirstName = table.Column<string>(nullable: false),
                    Name_LastName = table.Column<string>(nullable: false),
                    Name_RG = table.Column<string>(nullable: true),
                    Name_CPF = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DateEntered = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true),
                    Father_FirstName = table.Column<string>(nullable: false),
                    Father_LastName = table.Column<string>(nullable: false),
                    Father_RG = table.Column<string>(nullable: false),
                    Father_CPF = table.Column<string>(nullable: false),
                    Mother_FirstName = table.Column<string>(nullable: false),
                    Mother_LastName = table.Column<string>(nullable: false),
                    Mother_RG = table.Column<string>(nullable: false),
                    Mother_CPF = table.Column<string>(nullable: false),
                    Payment_Fee = table.Column<decimal>(nullable: false),
                    Payment_ExpirationDay = table.Column<int>(nullable: false),
                    HealthId = table.Column<Guid>(nullable: true),
                    ClassroomHistoryId = table.Column<Guid>(nullable: true),
                    ClassroomHistoryId1 = table.Column<Guid>(nullable: true),
                    ClassroomHistoryId2 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Health_HealthId",
                        column: x => x.HealthId,
                        principalTable: "Health",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classroom_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: true),
                    StudentId = table.Column<Guid>(nullable: true),
                    TeamId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamId1",
                        column: x => x.TeamId1,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassroomId = table.Column<Guid>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    TeacherId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassroomHistory_Classroom_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassroomHistory_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admnistrator_AddressId",
                table: "Admnistrator",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Admnistrator_BankAccountId",
                table: "Admnistrator",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_MatchId",
                table: "Card",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_MatchId1",
                table: "Card",
                column: "MatchId1");

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_StudentId",
                table: "Classroom",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomHistory_ClassroomId",
                table: "ClassroomHistory",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomHistory_TeacherId",
                table: "ClassroomHistory",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Fault_MatchId",
                table: "Fault",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Fault_MatchId1",
                table: "Fault",
                column: "MatchId1");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_MatchId",
                table: "Goal",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_MatchId1",
                table: "Goal",
                column: "MatchId1");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TeamId",
                table: "Match",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_StudentId",
                table: "Player",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId1",
                table: "Player",
                column: "TeamId1");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AddressId",
                table: "Student",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassroomHistoryId",
                table: "Student",
                column: "ClassroomHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassroomHistoryId1",
                table: "Student",
                column: "ClassroomHistoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassroomHistoryId2",
                table: "Student",
                column: "ClassroomHistoryId2");

            migrationBuilder.CreateIndex(
                name: "IX_Student_HealthId",
                table: "Student",
                column: "HealthId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_AddressId",
                table: "Teacher",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_BankAccountId",
                table: "Teacher",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_StudentCategoryId",
                table: "Team",
                column: "StudentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ClassroomHistory_ClassroomHistoryId",
                table: "Student",
                column: "ClassroomHistoryId",
                principalTable: "ClassroomHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ClassroomHistory_ClassroomHistoryId1",
                table: "Student",
                column: "ClassroomHistoryId1",
                principalTable: "ClassroomHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ClassroomHistory_ClassroomHistoryId2",
                table: "Student",
                column: "ClassroomHistoryId2",
                principalTable: "ClassroomHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Address_AddressId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Address_AddressId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_BankAccount_BankAccountId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_Student_StudentId",
                table: "Classroom");

            migrationBuilder.DropTable(
                name: "Admnistrator");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Fault");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "StudentCategory");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "ClassroomHistory");

            migrationBuilder.DropTable(
                name: "Health");

            migrationBuilder.DropTable(
                name: "Classroom");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
