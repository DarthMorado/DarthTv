using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DarthTV.Migrations
{
    /// <inheritdoc />
    public partial class v014 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    TvItemEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Items_TvItemEntityId",
                        column: x => x.TvItemEntityId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Released = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: true),
                    imdbRating = table.Column<double>(type: "float", nullable: true),
                    imdbID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TvSeasonEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Seasons_TvSeasonEntityId",
                        column: x => x.TvSeasonEntityId,
                        principalTable: "Seasons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_TvSeasonEntityId",
                table: "Episodes",
                column: "TvSeasonEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_TvItemEntityId",
                table: "Seasons",
                column: "TvItemEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Seasons");
        }
    }
}
