using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMO.Data.Migrations
{
    public partial class builddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoronaDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstVaccination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecondVaccination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThirdVaccination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FourhVaccination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProducerFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducerSecond = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducerThird = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducerFourth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSick = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRecover = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoronaDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pelephon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoronaDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalDetails_CoronaDetails_CoronaDetailsId",
                        column: x => x.CoronaDetailsId,
                        principalTable: "CoronaDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_CoronaDetailsId",
                table: "PersonalDetails",
                column: "CoronaDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalDetails");

            migrationBuilder.DropTable(
                name: "CoronaDetails");
        }
    }
}
