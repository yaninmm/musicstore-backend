using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGenreDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concert_Genre_GenreId",
                schema: "Musicales",
                table: "Concert");

            migrationBuilder.AddForeignKey(
                name: "FK_Concert_Genre_GenreId",
                schema: "Musicales",
                table: "Concert",
                column: "GenreId",
                principalSchema: "Musicales",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concert_Genre_GenreId",
                schema: "Musicales",
                table: "Concert");

            migrationBuilder.AddForeignKey(
                name: "FK_Concert_Genre_GenreId",
                schema: "Musicales",
                table: "Concert",
                column: "GenreId",
                principalSchema: "Musicales",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
