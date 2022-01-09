using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shift.Server.Migrations.Feryv
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeryvUserSQL",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Username = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    MediaFilename = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Verified = table.Column<bool>(type: "boolean", nullable: false),
                    Admin = table.Column<bool>(type: "boolean", nullable: false),
                    Confirmed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeryvUserSQL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LicenseSQL",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FeryvUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FeryvUserSQLId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseSQL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseSQL_FeryvUserSQL_FeryvUserSQLId",
                        column: x => x.FeryvUserSQLId,
                        principalTable: "FeryvUserSQL",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicenseSQL_FeryvUserSQLId",
                table: "LicenseSQL",
                column: "FeryvUserSQLId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenseSQL");

            migrationBuilder.DropTable(
                name: "FeryvUserSQL");
        }
    }
}
