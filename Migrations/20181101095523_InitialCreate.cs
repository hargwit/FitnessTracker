using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessTracker.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardioWorkouts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Activity = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DistanceKM = table.Column<decimal>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardioWorkouts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StrengthWorkouts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Activity = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    WeightKG = table.Column<decimal>(nullable: false),
                    NumReps = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrengthWorkouts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardioWorkouts");

            migrationBuilder.DropTable(
                name: "StrengthWorkouts");
        }
    }
}
