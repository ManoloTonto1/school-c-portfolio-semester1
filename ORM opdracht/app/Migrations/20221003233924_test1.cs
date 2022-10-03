using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace admin.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gasten_Attractie_FavoriteAttractieID",
                table: "Gasten");

            migrationBuilder.DropForeignKey(
                name: "FK_GastInfo_Gasten_ID",
                table: "GastInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Mederwerkers_Reservering_reserveringID",
                table: "Mederwerkers");

            migrationBuilder.DropForeignKey(
                name: "FK_Onderhoud_Attractie_attractieOmTeOnderhoudenID",
                table: "Onderhoud");

            migrationBuilder.DropForeignKey(
                name: "FK_Onderhoud_DateTimeBereik_datumonderhoudID",
                table: "Onderhoud");

            migrationBuilder.DropForeignKey(
                name: "FK_Onderhoud_Mederwerkers_medewerkerCoordinatorID",
                table: "Onderhoud");

            migrationBuilder.DropForeignKey(
                name: "FK_Onderhoud_Mederwerkers_medewerkerID",
                table: "Onderhoud");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservering_DateTimeBereik_datumReserveeringID",
                table: "Reservering");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservering_Gasten_ID",
                table: "Reservering");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Onderhoud",
                table: "Onderhoud");

            migrationBuilder.DropIndex(
                name: "IX_Onderhoud_attractieOmTeOnderhoudenID",
                table: "Onderhoud");

            migrationBuilder.DropIndex(
                name: "IX_Onderhoud_datumonderhoudID",
                table: "Onderhoud");

            migrationBuilder.DropIndex(
                name: "IX_Onderhoud_medewerkerCoordinatorID",
                table: "Onderhoud");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mederwerkers",
                table: "Mederwerkers");

            migrationBuilder.DropIndex(
                name: "IX_Mederwerkers_reserveringID",
                table: "Mederwerkers");

            migrationBuilder.DropColumn(
                name: "attractieOmTeOnderhoudenID",
                table: "Onderhoud");

            migrationBuilder.DropColumn(
                name: "datumonderhoudID",
                table: "Onderhoud");

            migrationBuilder.DropColumn(
                name: "medewerkerCoordinatorID",
                table: "Onderhoud");

            migrationBuilder.DropColumn(
                name: "GebruikerId",
                table: "Mederwerkers");

            migrationBuilder.DropColumn(
                name: "reserveringID",
                table: "Mederwerkers");

            migrationBuilder.RenameTable(
                name: "Onderhoud",
                newName: "OnderHoud");

            migrationBuilder.RenameTable(
                name: "Mederwerkers",
                newName: "Medewerkers");

            migrationBuilder.RenameColumn(
                name: "datumReserveeringID",
                table: "Reservering",
                newName: "datumReserveeringId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Reservering",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reservering_datumReserveeringID",
                table: "Reservering",
                newName: "IX_Reservering_datumReserveeringId");

            migrationBuilder.RenameColumn(
                name: "medewerkerID",
                table: "OnderHoud",
                newName: "attractieId");

            migrationBuilder.RenameIndex(
                name: "IX_Onderhoud_medewerkerID",
                table: "OnderHoud",
                newName: "IX_OnderHoud_attractieId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "GastInfo",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Gasten",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GebruikerId",
                table: "Gasten",
                newName: "gastInfoId");

            migrationBuilder.RenameColumn(
                name: "FavoriteAttractieID",
                table: "Gasten",
                newName: "attractieId");

            migrationBuilder.RenameIndex(
                name: "IX_Gasten_FavoriteAttractieID",
                table: "Gasten",
                newName: "IX_Gasten_attractieId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "DateTimeBereik",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Attractie",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Medewerkers",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reservering",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "attractieId",
                table: "Reservering",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "gastId",
                table: "Reservering",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "GastInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "coordinate_X",
                table: "GastInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "coordinate_Y",
                table: "GastInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "gastId",
                table: "GastInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OnderHoud",
                table: "OnderHoud",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medewerkers",
                table: "Medewerkers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MedewerkerOnderHoud",
                columns: table => new
                {
                    coordinatorenId = table.Column<int>(type: "int", nullable: false),
                    onderhoudenTeCoordinerenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerOnderHoud", x => new { x.coordinatorenId, x.onderhoudenTeCoordinerenID });
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderHoud_Medewerkers_coordinatorenId",
                        column: x => x.coordinatorenId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderHoud_OnderHoud_onderhoudenTeCoordinerenID",
                        column: x => x.onderhoudenTeCoordinerenID,
                        principalTable: "OnderHoud",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerOnderHoud1",
                columns: table => new
                {
                    medewerkersId = table.Column<int>(type: "int", nullable: false),
                    onderhoudenTeDoenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerOnderHoud1", x => new { x.medewerkersId, x.onderhoudenTeDoenID });
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderHoud1_Medewerkers_medewerkersId",
                        column: x => x.medewerkersId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderHoud1_OnderHoud_onderhoudenTeDoenID",
                        column: x => x.onderhoudenTeDoenID,
                        principalTable: "OnderHoud",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservering_attractieId",
                table: "Reservering",
                column: "attractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservering_gastId",
                table: "Reservering",
                column: "gastId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_gastInfoId",
                table: "Gasten",
                column: "gastInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerOnderHoud_onderhoudenTeCoordinerenID",
                table: "MedewerkerOnderHoud",
                column: "onderhoudenTeCoordinerenID");

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerOnderHoud1_onderhoudenTeDoenID",
                table: "MedewerkerOnderHoud1",
                column: "onderhoudenTeDoenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Gasten_Attractie_attractieId",
                table: "Gasten",
                column: "attractieId",
                principalTable: "Attractie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gasten_GastInfo_gastInfoId",
                table: "Gasten",
                column: "gastInfoId",
                principalTable: "GastInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnderHoud_Attractie_attractieId",
                table: "OnderHoud",
                column: "attractieId",
                principalTable: "Attractie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservering_Attractie_attractieId",
                table: "Reservering",
                column: "attractieId",
                principalTable: "Attractie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservering_DateTimeBereik_datumReserveeringId",
                table: "Reservering",
                column: "datumReserveeringId",
                principalTable: "DateTimeBereik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservering_Gasten_gastId",
                table: "Reservering",
                column: "gastId",
                principalTable: "Gasten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gasten_Attractie_attractieId",
                table: "Gasten");

            migrationBuilder.DropForeignKey(
                name: "FK_Gasten_GastInfo_gastInfoId",
                table: "Gasten");

            migrationBuilder.DropForeignKey(
                name: "FK_OnderHoud_Attractie_attractieId",
                table: "OnderHoud");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservering_Attractie_attractieId",
                table: "Reservering");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservering_DateTimeBereik_datumReserveeringId",
                table: "Reservering");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservering_Gasten_gastId",
                table: "Reservering");

            migrationBuilder.DropTable(
                name: "MedewerkerOnderHoud");

            migrationBuilder.DropTable(
                name: "MedewerkerOnderHoud1");

            migrationBuilder.DropIndex(
                name: "IX_Reservering_attractieId",
                table: "Reservering");

            migrationBuilder.DropIndex(
                name: "IX_Reservering_gastId",
                table: "Reservering");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OnderHoud",
                table: "OnderHoud");

            migrationBuilder.DropIndex(
                name: "IX_Gasten_gastInfoId",
                table: "Gasten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medewerkers",
                table: "Medewerkers");

            migrationBuilder.DropColumn(
                name: "attractieId",
                table: "Reservering");

            migrationBuilder.DropColumn(
                name: "gastId",
                table: "Reservering");

            migrationBuilder.DropColumn(
                name: "coordinate_X",
                table: "GastInfo");

            migrationBuilder.DropColumn(
                name: "coordinate_Y",
                table: "GastInfo");

            migrationBuilder.DropColumn(
                name: "gastId",
                table: "GastInfo");

            migrationBuilder.RenameTable(
                name: "OnderHoud",
                newName: "Onderhoud");

            migrationBuilder.RenameTable(
                name: "Medewerkers",
                newName: "Mederwerkers");

            migrationBuilder.RenameColumn(
                name: "datumReserveeringId",
                table: "Reservering",
                newName: "datumReserveeringID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reservering",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservering_datumReserveeringId",
                table: "Reservering",
                newName: "IX_Reservering_datumReserveeringID");

            migrationBuilder.RenameColumn(
                name: "attractieId",
                table: "Onderhoud",
                newName: "medewerkerID");

            migrationBuilder.RenameIndex(
                name: "IX_OnderHoud_attractieId",
                table: "Onderhoud",
                newName: "IX_Onderhoud_medewerkerID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GastInfo",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Gasten",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "gastInfoId",
                table: "Gasten",
                newName: "GebruikerId");

            migrationBuilder.RenameColumn(
                name: "attractieId",
                table: "Gasten",
                newName: "FavoriteAttractieID");

            migrationBuilder.RenameIndex(
                name: "IX_Gasten_attractieId",
                table: "Gasten",
                newName: "IX_Gasten_FavoriteAttractieID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DateTimeBereik",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Attractie",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Mederwerkers",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Reservering",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "attractieOmTeOnderhoudenID",
                table: "Onderhoud",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "datumonderhoudID",
                table: "Onderhoud",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "medewerkerCoordinatorID",
                table: "Onderhoud",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "GastInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "GebruikerId",
                table: "Mederwerkers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "reserveringID",
                table: "Mederwerkers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Onderhoud",
                table: "Onderhoud",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mederwerkers",
                table: "Mederwerkers",
                column: "ID");

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
                name: "IX_Mederwerkers_reserveringID",
                table: "Mederwerkers",
                column: "reserveringID");

            migrationBuilder.AddForeignKey(
                name: "FK_Gasten_Attractie_FavoriteAttractieID",
                table: "Gasten",
                column: "FavoriteAttractieID",
                principalTable: "Attractie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GastInfo_Gasten_ID",
                table: "GastInfo",
                column: "ID",
                principalTable: "Gasten",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mederwerkers_Reservering_reserveringID",
                table: "Mederwerkers",
                column: "reserveringID",
                principalTable: "Reservering",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Onderhoud_Attractie_attractieOmTeOnderhoudenID",
                table: "Onderhoud",
                column: "attractieOmTeOnderhoudenID",
                principalTable: "Attractie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Onderhoud_DateTimeBereik_datumonderhoudID",
                table: "Onderhoud",
                column: "datumonderhoudID",
                principalTable: "DateTimeBereik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Onderhoud_Mederwerkers_medewerkerCoordinatorID",
                table: "Onderhoud",
                column: "medewerkerCoordinatorID",
                principalTable: "Mederwerkers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Onderhoud_Mederwerkers_medewerkerID",
                table: "Onderhoud",
                column: "medewerkerID",
                principalTable: "Mederwerkers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservering_DateTimeBereik_datumReserveeringID",
                table: "Reservering",
                column: "datumReserveeringID",
                principalTable: "DateTimeBereik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservering_Gasten_ID",
                table: "Reservering",
                column: "ID",
                principalTable: "Gasten",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
