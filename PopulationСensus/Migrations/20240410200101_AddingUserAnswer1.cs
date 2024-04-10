using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PopulationСensus.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserAnswer1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserAnswer_UserAnswersId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserAnswersId",
                table: "Users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserAnswer_UserAnswersId",
                table: "Users",
                column: "UserAnswersId",
                principalTable: "UserAnswer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserAnswer_UserAnswersId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserAnswersId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserAnswer_UserAnswersId",
                table: "Users",
                column: "UserAnswersId",
                principalTable: "UserAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
