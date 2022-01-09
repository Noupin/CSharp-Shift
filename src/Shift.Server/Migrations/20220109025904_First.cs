using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shift.Server.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InferenceWorkers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShiftId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeStarted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MediaFilename = table.Column<string>(type: "text", nullable: false),
                    BaseMediaFilename = table.Column<string>(type: "text", nullable: false),
                    WorkerStatus = table.Column<int>(type: "integer", nullable: false),
                    ClientStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InferenceWorkers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainWorkers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShiftId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeStarted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Training = table.Column<bool>(type: "boolean", nullable: false),
                    Inferencing = table.Column<bool>(type: "boolean", nullable: false),
                    ImagesUpdated = table.Column<bool>(type: "boolean", nullable: false),
                    ExhibitImages = table.Column<string>(type: "text", nullable: false),
                    WorkerStatus = table.Column<int>(type: "integer", nullable: false),
                    ClientStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainWorkers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FeryvUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Admin = table.Column<bool>(type: "boolean", nullable: false),
                    CanTrain = table.Column<bool>(type: "boolean", nullable: false),
                    Verified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    Views = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "ShiftCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShiftId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftCategories_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorySQLShiftSQL_ShiftsId",
                table: "CategorySQLShiftSQL",
                column: "ShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCategories_CategoryId",
                table: "ShiftCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCategories_ShiftId",
                table: "ShiftCategories",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_AuthorId",
                table: "Shifts",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorySQLShiftSQL");

            migrationBuilder.DropTable(
                name: "InferenceWorkers");

            migrationBuilder.DropTable(
                name: "ShiftCategories");

            migrationBuilder.DropTable(
                name: "TrainWorkers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
