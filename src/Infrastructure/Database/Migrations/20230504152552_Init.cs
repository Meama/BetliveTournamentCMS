using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "TurnamentResults",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IsWinner = table.Column<bool>(type: "bit", nullable: false),
                FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                PrizeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                PersonalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TurnamentResults", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "TurnamentResults");
    }
}