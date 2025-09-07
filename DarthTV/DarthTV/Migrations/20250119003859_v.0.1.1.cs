using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DarthTV.Migrations
{
    /// <inheritdoc />
    public partial class v011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    YearFrom = table.Column<int>(type: "int", nullable: false),
                    YearTo = table.Column<int>(type: "int", nullable: false),
                    Rated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Released = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RuntimeMinutes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Awards = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosterUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metascore = table.Column<double>(type: "float", nullable: true),
                    ImdbRating = table.Column<double>(type: "float", nullable: true),
                    ImdbID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SeasonsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TvItemEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Items_TvItemEntityId",
                        column: x => x.TvItemEntityId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TvItemEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_Items_TvItemEntityId",
                        column: x => x.TvItemEntityId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TvItemEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Items_TvItemEntityId",
                        column: x => x.TvItemEntityId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDirector = table.Column<bool>(type: "bit", nullable: false),
                    IsWriter = table.Column<bool>(type: "bit", nullable: false),
                    IsActor = table.Column<bool>(type: "bit", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: true),
                    DirectorId = table.Column<int>(type: "int", nullable: true),
                    WriterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Items_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_People_Items_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_People_Items_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_TvItemEntityId",
                table: "Countries",
                column: "TvItemEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_TvItemEntityId",
                table: "Genres",
                column: "TvItemEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_TvItemEntityId",
                table: "Languages",
                column: "TvItemEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_People_ActorId",
                table: "People",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_People_DirectorId",
                table: "People",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_People_WriterId",
                table: "People",
                column: "WriterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
