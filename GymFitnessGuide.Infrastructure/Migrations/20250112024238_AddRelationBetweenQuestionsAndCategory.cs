using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymFitnessGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenQuestionsAndCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Resource",
                table: "Recommendations",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TestQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Recommendations",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Recommendations",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_CategoryId",
                table: "TestQuestions",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Categories_CategoryId",
                table: "TestQuestions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Categories_CategoryId",
                table: "TestQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestions_CategoryId",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Recommendations");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Recommendations",
                newName: "Resource");
        }
    }
}
