using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shift.Server.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShiftCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShiftId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Admin = table.Column<bool>(type: "boolean", nullable: false),
                    CanTrain = table.Column<bool>(type: "boolean", nullable: false),
                    Verified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ShiftCategorySQLId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_ShiftCategories_ShiftCategorySQLId",
                        column: x => x.ShiftCategorySQLId,
                        principalTable: "ShiftCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MediaFilename = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    BaseMediaFilename = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    MaskMediaFilename = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Private = table.Column<bool>(type: "boolean", nullable: false),
                    Verified = table.Column<bool>(type: "boolean", nullable: false),
                    Views = table.Column<int>(type: "integer", nullable: false),
                    ShiftCategorySQLId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_ShiftCategories_ShiftCategorySQLId",
                        column: x => x.ShiftCategorySQLId,
                        principalTable: "ShiftCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shifts_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategorySQLShiftSQL",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShiftsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySQLShiftSQL", x => new { x.CategoriesId, x.ShiftsId });
                    table.ForeignKey(
                        name: "FK_CategorySQLShiftSQL_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySQLShiftSQL_Shifts_ShiftsId",
                        column: x => x.ShiftsId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ShiftCategorySQLId",
                table: "Categories",
                column: "ShiftCategorySQLId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorySQLShiftSQL_ShiftsId",
                table: "CategorySQLShiftSQL",
                column: "ShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_AuthorId",
                table: "Shifts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_ShiftCategorySQLId",
                table: "Shifts",
                column: "ShiftCategorySQLId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorySQLShiftSQL");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "ShiftCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
