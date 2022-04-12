using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndividualSeeSharpers.Migrations
{
    public partial class Theatref : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Row");

            migrationBuilder.AddColumn<int>(
                name: "AmountOfRows",
                table: "Theatres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfSeats",
                table: "Theatres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfRows",
                table: "Theatres");

            migrationBuilder.DropColumn(
                name: "AmountOfSeats",
                table: "Theatres");

            migrationBuilder.CreateTable(
                name: "Row",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountOfSeats = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TheatreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Row", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Row_Theatres_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Row_TheatreId",
                table: "Row",
                column: "TheatreId");
        }
    }
}
