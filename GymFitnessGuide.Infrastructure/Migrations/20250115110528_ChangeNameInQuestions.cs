using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymFitnessGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameInQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsBinary",
                table: "TestQuestions",
                newName: "IsOpen");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Recommendations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsOpen",
                table: "TestQuestions",
                newName: "IsBinary");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Recommendations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
