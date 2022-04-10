using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndividualSeeSharpers.Migrations
{
    public partial class TicketOrderTheatreRowSpecial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfRows",
                table: "Theatres");

            migrationBuilder.DropColumn(
                name: "AmountOfSeats",
                table: "Theatres");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Row",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    AmountOfSeats = table.Column<int>(type: "int", nullable: false),
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
