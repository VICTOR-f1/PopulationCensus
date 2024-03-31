using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PopulationСensus.Migrations
{
    /// <inheritdoc />
    public partial class addResidenАddressaddtomodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residents_ResidenАddress_ResidenАddressId",
                table: "Residents");

            migrationBuilder.DropTable(
                name: "ResidenАddress");

            migrationBuilder.RenameColumn(
                name: "ResidenАddressId",
                table: "Residents",
                newName: "АddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Residents_ResidenАddressId",
                table: "Residents",
                newName: "IX_Residents_АddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Addresses_АddressId",
                table: "Residents",
                column: "АddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Addresses_АddressId",
                table: "Residents");

            migrationBuilder.RenameColumn(
                name: "АddressId",
                table: "Residents",
                newName: "ResidenАddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Residents_АddressId",
                table: "Residents",
                newName: "IX_Residents_ResidenАddressId");

            migrationBuilder.CreateTable(
                name: "ResidenАddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    АddressId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidenАddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidenАddress_Addresses_АddressId",
                        column: x => x.АddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidenАddress_АddressId",
                table: "ResidenАddress",
                column: "АddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_ResidenАddress_ResidenАddressId",
                table: "Residents",
                column: "ResidenАddressId",
                principalTable: "ResidenАddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
