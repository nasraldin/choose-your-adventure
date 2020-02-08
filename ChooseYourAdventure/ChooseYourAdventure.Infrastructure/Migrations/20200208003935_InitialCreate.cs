using Microsoft.EntityFrameworkCore.Migrations;

namespace ChooseYourAdventure.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DecisionTree",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreeNodes = table.Column<string>(nullable: false),
                    SuggestedNotes = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true),
                    IsDone = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecisionTree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreeNodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreeNodes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreeNodes_TreeNodes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TreeNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreeNodes_CategoryId",
                table: "TreeNodes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeNodes_ParentId",
                table: "TreeNodes",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecisionTree");

            migrationBuilder.DropTable(
                name: "TreeNodes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
