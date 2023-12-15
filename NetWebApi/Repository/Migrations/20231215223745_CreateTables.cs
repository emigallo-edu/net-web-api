using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Stadiums",
                schema: "dbo",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "TestingClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestingClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPartners = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StadiumName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StandingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_Stadiums_StadiumName",
                        column: x => x.StadiumName,
                        principalSchema: "dbo",
                        principalTable: "Stadiums",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalSchema: "dbo",
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matchs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocalClubId = table.Column<int>(type: "int", nullable: false),
                    VisitingClubId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matchs_Clubs_LocalClubId",
                        column: x => x.LocalClubId,
                        principalSchema: "dbo",
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchs_Clubs_VisitingClubId",
                        column: x => x.VisitingClubId,
                        principalSchema: "dbo",
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Standing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    TournamentId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Standing_StandingId",
                        column: x => x.StandingId,
                        principalTable: "Standing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_StadiumName",
                schema: "dbo",
                table: "Clubs",
                column: "StadiumName",
                unique: true,
                filter: "[StadiumName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_StandingId",
                schema: "dbo",
                table: "Clubs",
                column: "StandingId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_LocalClubId",
                schema: "dbo",
                table: "Matchs",
                column: "LocalClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_TournamentId",
                schema: "dbo",
                table: "Matchs",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_VisitingClubId",
                schema: "dbo",
                table: "Matchs",
                column: "VisitingClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ClubId",
                schema: "dbo",
                table: "Players",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Standing_TournamentId1",
                table: "Standing",
                column: "TournamentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_StandingId",
                schema: "dbo",
                table: "Tournaments",
                column: "StandingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Standing_StandingId",
                schema: "dbo",
                table: "Clubs",
                column: "StandingId",
                principalTable: "Standing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matchs_Tournaments_TournamentId",
                schema: "dbo",
                table: "Matchs",
                column: "TournamentId",
                principalSchema: "dbo",
                principalTable: "Tournaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Standing_Tournaments_TournamentId1",
                table: "Standing",
                column: "TournamentId1",
                principalSchema: "dbo",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Standing_StandingId",
                schema: "dbo",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "Matchs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TestingClasses");

            migrationBuilder.DropTable(
                name: "Clubs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Stadiums",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Standing");

            migrationBuilder.DropTable(
                name: "Tournaments",
                schema: "dbo");
        }
    }
}
