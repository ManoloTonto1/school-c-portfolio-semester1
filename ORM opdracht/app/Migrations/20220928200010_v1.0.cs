using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace admin.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attractie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DateTimeBereik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eind = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateTimeBereik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gasten",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<int>(type: "int", nullable: false),
                    isBegeleider = table.Column<bool>(type: "bit", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EersteBezoek = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FavoriteAttractieID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasten", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gasten_Attractie_FavoriteAttractieID",
                        column: x => x.FavoriteAttractieID,
                        principalTable: "Attractie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GastInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    LaatsteBezochteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GastInfo_Gasten_ID",
                        column: x => x.ID,
                        principalTable: "Gasten",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservering",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    datumReserveeringID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservering", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservering_DateTimeBereik_datumReserveeringID",
                        column: x => x.datumReserveeringID,
                        principalTable: "DateTimeBereik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservering_Gasten_ID",
                        column: x => x.ID,
                        principalTable: "Gasten",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mederwerkers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reserveringID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mederwerkers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Mederwerkers_Reservering_reserveringID",
                        column: x => x.reserveringID,
                        principalTable: "Reservering",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Onderhoud",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Probleem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    medewerkerCoordinatorID = table.Column<int>(type: "int", nullable: false),
                    medewerkerID = table.Column<int>(type: "int", nullable: false),
                    attractieOmTeOnderhoudenID = table.Column<int>(type: "int", nullable: false),
                    datumonderhoudID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderhoud", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Onderhoud_Attractie_attractieOmTeOnderhoudenID",
                        column: x => x.attractieOmTeOnderhoudenID,
                        principalTable: "Attractie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Onderhoud_DateTimeBereik_datumonderhoudID",
                        column: x => x.datumonderhoudID,
                        principalTable: "DateTimeBereik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Onderhoud_Mederwerkers_medewerkerCoordinatorID",
                        column: x => x.medewerkerCoordinatorID,
                        principalTable: "Mederwerkers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Onderhoud_Mederwerkers_medewerkerID",
                        column: x => x.medewerkerID,
                        principalTable: "Mederwerkers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_FavoriteAttractieID",
                table: "Gasten",
                column: "FavoriteAttractieID");

            migrationBuilder.CreateIndex(
                name: "IX_Mederwerkers_reserveringID",
                table: "Mederwerkers",
                column: "reserveringID");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_attractieOmTeOnderhoudenID",
                table: "Onderhoud",
                column: "attractieOmTeOnderhoudenID");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_datumonderhoudID",
                table: "Onderhoud",
                column: "datumonderhoudID");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_medewerkerCoordinatorID",
                table: "Onderhoud",
                column: "medewerkerCoordinatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_medewerkerID",
                table: "Onderhoud",
                column: "medewerkerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservering_datumReserveeringID",
                table: "Reservering",
                column: "datumReserveeringID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GastInfo");

            migrationBuilder.DropTable(
                name: "Onderhoud");

            migrationBuilder.DropTable(
                name: "Mederwerkers");

            migrationBuilder.DropTable(
                name: "Reservering");

            migrationBuilder.DropTable(
                name: "DateTimeBereik");

            migrationBuilder.DropTable(
                name: "Gasten");

            migrationBuilder.DropTable(
                name: "Attractie");
        }
    }
}
