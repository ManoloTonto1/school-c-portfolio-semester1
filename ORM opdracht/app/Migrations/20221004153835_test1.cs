using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace admin.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attracties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attracties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GastInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gastId = table.Column<int>(type: "int", nullable: false),
                    LaatsteBezochteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    coordinate_X = table.Column<int>(type: "int", nullable: true),
                    coordinate_Y = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnderHouden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attractieId = table.Column<int>(type: "int", nullable: false),
                    Probleem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumonderhoud_Id = table.Column<int>(type: "int", nullable: true),
                    datumonderhoud_Begin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    datumonderhoud_Eind = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnderHouden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnderHouden_Attracties_attractieId",
                        column: x => x.attractieId,
                        principalTable: "Attracties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gasten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    isBegeleider = table.Column<bool>(type: "bit", nullable: false),
                    attractieId = table.Column<int>(type: "int", nullable: false),
                    gastInfoId = table.Column<int>(type: "int", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EersteBezoek = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gasten_Attracties_attractieId",
                        column: x => x.attractieId,
                        principalTable: "Attracties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gasten_GastInfo_gastInfoId",
                        column: x => x.gastInfoId,
                        principalTable: "GastInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gasten_Gebruikers_Id",
                        column: x => x.Id,
                        principalTable: "Gebruikers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medewerkers_Gebruikers_Id",
                        column: x => x.Id,
                        principalTable: "Gebruikers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gastId = table.Column<int>(type: "int", nullable: false),
                    attractieId = table.Column<int>(type: "int", nullable: false),
                    datumReserveering_Id = table.Column<int>(type: "int", nullable: false),
                    datumReserveering_Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datumReserveering_Eind = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservering", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservering_Attracties_attractieId",
                        column: x => x.attractieId,
                        principalTable: "Attracties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservering_Gasten_gastId",
                        column: x => x.gastId,
                        principalTable: "Gasten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerOnderHoud",
                columns: table => new
                {
                    coordinatorenId = table.Column<int>(type: "int", nullable: false),
                    onderhoudenTeCoordinerenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerOnderHoud", x => new { x.coordinatorenId, x.onderhoudenTeCoordinerenId });
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderHoud_Medewerkers_coordinatorenId",
                        column: x => x.coordinatorenId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderHoud_OnderHouden_onderhoudenTeCoordinerenId",
                        column: x => x.onderhoudenTeCoordinerenId,
                        principalTable: "OnderHouden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerOnderHoud1",
                columns: table => new
                {
                    medewerkersId = table.Column<int>(type: "int", nullable: false),
                    onderhoudenTeDoenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerOnderHoud1", x => new { x.medewerkersId, x.onderhoudenTeDoenId });
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderHoud1_Medewerkers_medewerkersId",
                        column: x => x.medewerkersId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderHoud1_OnderHouden_onderhoudenTeDoenId",
                        column: x => x.onderhoudenTeDoenId,
                        principalTable: "OnderHouden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_attractieId",
                table: "Gasten",
                column: "attractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_gastInfoId",
                table: "Gasten",
                column: "gastInfoId",
                unique: true,
                filter: "[gastInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerOnderHoud_onderhoudenTeCoordinerenId",
                table: "MedewerkerOnderHoud",
                column: "onderhoudenTeCoordinerenId");

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerOnderHoud1_onderhoudenTeDoenId",
                table: "MedewerkerOnderHoud1",
                column: "onderhoudenTeDoenId");

            migrationBuilder.CreateIndex(
                name: "IX_OnderHouden_attractieId",
                table: "OnderHouden",
                column: "attractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservering_attractieId",
                table: "Reservering",
                column: "attractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservering_gastId",
                table: "Reservering",
                column: "gastId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedewerkerOnderHoud");

            migrationBuilder.DropTable(
                name: "MedewerkerOnderHoud1");

            migrationBuilder.DropTable(
                name: "Reservering");

            migrationBuilder.DropTable(
                name: "Medewerkers");

            migrationBuilder.DropTable(
                name: "OnderHouden");

            migrationBuilder.DropTable(
                name: "Gasten");

            migrationBuilder.DropTable(
                name: "Attracties");

            migrationBuilder.DropTable(
                name: "GastInfo");

            migrationBuilder.DropTable(
                name: "Gebruikers");
        }
    }
}
