using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace admin.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gasten_Attracties_attractieId",
                table: "Gasten");

            migrationBuilder.DropForeignKey(
                name: "FK_Gasten_GastInfo_gastInfoId",
                table: "Gasten");

            migrationBuilder.DropTable(
                name: "MedewerkerOnderHoud");

            migrationBuilder.DropTable(
                name: "MedewerkerOnderHoud1");

            migrationBuilder.DropIndex(
                name: "IX_Gasten_attractieId",
                table: "Gasten");

            migrationBuilder.DropIndex(
                name: "IX_Gasten_gastInfoId",
                table: "Gasten");

            migrationBuilder.RenameColumn(
                name: "gastInfoId",
                table: "Gasten",
                newName: "gastInfoID");

            migrationBuilder.RenameColumn(
                name: "attractieId",
                table: "Gasten",
                newName: "FavAttractieID");

            migrationBuilder.AddColumn<int>(
                name: "FavoriteAttractieId",
                table: "Gasten",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OnderhoudenTeCoordineren",
                columns: table => new
                {
                    coordinatorenId = table.Column<int>(type: "int", nullable: false),
                    onderhoudenTeCoordinerenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnderhoudenTeCoordineren", x => new { x.coordinatorenId, x.onderhoudenTeCoordinerenId });
                    table.ForeignKey(
                        name: "FK_OnderhoudenTeCoordineren_Medewerkers_coordinatorenId",
                        column: x => x.coordinatorenId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnderhoudenTeCoordineren_OnderHouden_onderhoudenTeCoordinerenId",
                        column: x => x.onderhoudenTeCoordinerenId,
                        principalTable: "OnderHouden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnderhoudenTeDoen",
                columns: table => new
                {
                    medewerkersId = table.Column<int>(type: "int", nullable: false),
                    onderhoudenTeDoenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnderhoudenTeDoen", x => new { x.medewerkersId, x.onderhoudenTeDoenId });
                    table.ForeignKey(
                        name: "FK_OnderhoudenTeDoen_Medewerkers_medewerkersId",
                        column: x => x.medewerkersId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnderhoudenTeDoen_OnderHouden_onderhoudenTeDoenId",
                        column: x => x.onderhoudenTeDoenId,
                        principalTable: "OnderHouden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_FavoriteAttractieId",
                table: "Gasten",
                column: "FavoriteAttractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_gastInfoID",
                table: "Gasten",
                column: "gastInfoID",
                unique: true,
                filter: "[gastInfoID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OnderhoudenTeCoordineren_onderhoudenTeCoordinerenId",
                table: "OnderhoudenTeCoordineren",
                column: "onderhoudenTeCoordinerenId");

            migrationBuilder.CreateIndex(
                name: "IX_OnderhoudenTeDoen_onderhoudenTeDoenId",
                table: "OnderhoudenTeDoen",
                column: "onderhoudenTeDoenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gasten_Attracties_FavoriteAttractieId",
                table: "Gasten",
                column: "FavoriteAttractieId",
                principalTable: "Attracties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gasten_GastInfo_gastInfoID",
                table: "Gasten",
                column: "gastInfoID",
                principalTable: "GastInfo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gasten_Attracties_FavoriteAttractieId",
                table: "Gasten");

            migrationBuilder.DropForeignKey(
                name: "FK_Gasten_GastInfo_gastInfoID",
                table: "Gasten");

            migrationBuilder.DropTable(
                name: "OnderhoudenTeCoordineren");

            migrationBuilder.DropTable(
                name: "OnderhoudenTeDoen");

            migrationBuilder.DropIndex(
                name: "IX_Gasten_FavoriteAttractieId",
                table: "Gasten");

            migrationBuilder.DropIndex(
                name: "IX_Gasten_gastInfoID",
                table: "Gasten");

            migrationBuilder.DropColumn(
                name: "FavoriteAttractieId",
                table: "Gasten");

            migrationBuilder.RenameColumn(
                name: "gastInfoID",
                table: "Gasten",
                newName: "gastInfoId");

            migrationBuilder.RenameColumn(
                name: "FavAttractieID",
                table: "Gasten",
                newName: "attractieId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Gasten_Attracties_attractieId",
                table: "Gasten",
                column: "attractieId",
                principalTable: "Attracties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gasten_GastInfo_gastInfoId",
                table: "Gasten",
                column: "gastInfoId",
                principalTable: "GastInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
