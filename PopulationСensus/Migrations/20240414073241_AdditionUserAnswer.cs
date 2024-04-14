using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PopulationСensus.Migrations
{
    /// <inheritdoc />
    public partial class AdditionUserAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "YearBirthFirstChild",
                table: "UserAnswer",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<byte>(
                name: "NumberChildrenBorn",
                table: "UserAnswer",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AddColumn<bool>(
                name: "CanReadAndWrite",
                table: "UserAnswer",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Citizenship",
                table: "UserAnswer",
                type: "character varying(70)",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "UserAnswer",
                type: "character varying(70)",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HaveDegree",
                table: "UserAnswer",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LivedOtherCountries",
                table: "UserAnswer",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "UserAnswer",
                type: "character varying(70)",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NativeLanguage",
                table: "UserAnswer",
                type: "character varying(70)",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SpeakRussian",
                table: "UserAnswer",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UseRussianInConversation",
                table: "UserAnswer",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WhereLiveBeforeArriving",
                table: "UserAnswer",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "YearArrival",
                table: "UserAnswer",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanReadAndWrite",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "Citizenship",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "HaveDegree",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "LivedOtherCountries",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "NativeLanguage",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "SpeakRussian",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "UseRussianInConversation",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "WhereLiveBeforeArriving",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "YearArrival",
                table: "UserAnswer");

            migrationBuilder.AlterColumn<short>(
                name: "YearBirthFirstChild",
                table: "UserAnswer",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "NumberChildrenBorn",
                table: "UserAnswer",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "smallint",
                oldNullable: true);
        }
    }
}
