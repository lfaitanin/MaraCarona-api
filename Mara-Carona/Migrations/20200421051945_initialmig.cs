using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mara_Carona.Migrations
{
    public partial class initialmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable("RideUser");

            migrationBuilder.CreateTable(
                name: "RideUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RideId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    PassengerId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RideUser_users_DriverId",
                        column: x => x.DriverId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RideUser_users_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RideUser_Ride_RideId",
                        column: x => x.RideId,
                        principalTable: "Ride",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            
            
            migrationBuilder.CreateIndex(
                name: "IX_RideUser_DriverId",
                table: "RideUser",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RideUser_PassengerId",
                table: "RideUser",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_RideUser_RideId",
                table: "RideUser",
                column: "RideId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "RideUser");

            migrationBuilder.DropTable(
                name: "Ride");

            migrationBuilder.DropTable(
                name: "fixture");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "usersType");

            migrationBuilder.DropTable(
                name: "club");
        }
    }
}
