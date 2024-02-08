using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthwindWebMvc.Basic.RepositoryContext.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableCategoryDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryDetail",
                schema: "master",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    ColorValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateByUserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDetail", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_CategoryDetail_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "master",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryDetail",
                schema: "master");
        }
    }
}
