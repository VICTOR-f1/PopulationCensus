using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PopulationСensus.Migrations
{
    /// <inheritdoc />
    public partial class main : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ZipCode = table.Column<int>(type: "integer", nullable: false),
                    ApartmentNumber = table.Column<short>(type: "smallint", nullable: false),
                    Street = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    State = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Gender = table.Column<bool>(type: "boolean", nullable: false),
                    NumberChildrenBorn = table.Column<byte>(type: "smallint", nullable: true),
                    YearBirthFirstChild = table.Column<short>(type: "smallint", nullable: true),
                    PlaceBirth = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    LivedOtherCountries = table.Column<bool>(type: "boolean", nullable: false),
                    WhereLiveBeforeArriving = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    YearArrival = table.Column<short>(type: "smallint", nullable: true),
                    SpeakRussian = table.Column<bool>(type: "boolean", nullable: false),
                    UseRussianInConversation = table.Column<bool>(type: "boolean", nullable: false),
                    NativeLanguage = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Citizenship = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    Nationality = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Education = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    HaveDegree = table.Column<bool>(type: "boolean", nullable: false),
                    CanReadAndWrite = table.Column<bool>(type: "boolean", nullable: false),
                    MaritalStatus = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Password = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Salt = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    UserAnswersId = table.Column<int>(type: "integer", nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserAnswer_UserAnswersId",
                        column: x => x.UserAnswersId,
                        principalTable: "UserAnswer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserAnswersId",
                table: "Users",
                column: "UserAnswersId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserAnswer");
        }
    }
}
