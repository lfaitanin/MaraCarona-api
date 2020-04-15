using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mara_Carona.Migrations
{
    public partial class Message : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //var existsMessage = migrationBuilder.Sql(@"SELECT EXISTS (
            //                       SELECT FROM information_schema.tables 
            //                       WHERE  table_name   = 'Message'
            //                       );");

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserFromId = table.Column<int>(nullable: true),
                    UserToId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_users_UserFromId",
                        column: x => x.UserFromId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_users_UserToId",
                        column: x => x.UserToId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            
            migrationBuilder.CreateIndex(
                name: "IX_Message_UserFromId",
                table: "Message",
                column: "UserFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserToId",
                table: "Message",
                column: "UserToId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fixture");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "usersType");

            migrationBuilder.DropTable(
                name: "club");
        }
    }
}
