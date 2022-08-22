using Microsoft.EntityFrameworkCore.Migrations;

namespace Fika.Migrations
{
    public partial class test123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musteris_Personels_OperasyonIDPersonelID",
                table: "Musteris");

            migrationBuilder.DropForeignKey(
                name: "FK_Musteris_Personels_SatisIDPersonelID",
                table: "Musteris");

            migrationBuilder.DropIndex(
                name: "IX_Musteris_OperasyonIDPersonelID",
                table: "Musteris");

            migrationBuilder.DropIndex(
                name: "IX_Musteris_SatisIDPersonelID",
                table: "Musteris");

            migrationBuilder.DropColumn(
                name: "OperasyonIDPersonelID",
                table: "Musteris");

            migrationBuilder.DropColumn(
                name: "SatisIDPersonelID",
                table: "Musteris");

            migrationBuilder.CreateTable(
                name: "MusteriPersonel",
                columns: table => new
                {
                    OperasyonIDPersonelID = table.Column<int>(type: "int", nullable: false),
                    OperasyonMusteriID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriPersonel", x => new { x.OperasyonIDPersonelID, x.OperasyonMusteriID });
                    table.ForeignKey(
                        name: "FK_MusteriPersonel_Musteris_OperasyonMusteriID",
                        column: x => x.OperasyonMusteriID,
                        principalTable: "Musteris",
                        principalColumn: "MusteriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusteriPersonel_Personels_OperasyonIDPersonelID",
                        column: x => x.OperasyonIDPersonelID,
                        principalTable: "Personels",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusteriPersonel1",
                columns: table => new
                {
                    SatisIDPersonelID = table.Column<int>(type: "int", nullable: false),
                    SatisMusteriID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriPersonel1", x => new { x.SatisIDPersonelID, x.SatisMusteriID });
                    table.ForeignKey(
                        name: "FK_MusteriPersonel1_Musteris_SatisMusteriID",
                        column: x => x.SatisMusteriID,
                        principalTable: "Musteris",
                        principalColumn: "MusteriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusteriPersonel1_Personels_SatisIDPersonelID",
                        column: x => x.SatisIDPersonelID,
                        principalTable: "Personels",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusteriPersonel_OperasyonMusteriID",
                table: "MusteriPersonel",
                column: "OperasyonMusteriID");

            migrationBuilder.CreateIndex(
                name: "IX_MusteriPersonel1_SatisMusteriID",
                table: "MusteriPersonel1",
                column: "SatisMusteriID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusteriPersonel");

            migrationBuilder.DropTable(
                name: "MusteriPersonel1");

            migrationBuilder.AddColumn<int>(
                name: "OperasyonIDPersonelID",
                table: "Musteris",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SatisIDPersonelID",
                table: "Musteris",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musteris_OperasyonIDPersonelID",
                table: "Musteris",
                column: "OperasyonIDPersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_Musteris_SatisIDPersonelID",
                table: "Musteris",
                column: "SatisIDPersonelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteris_Personels_OperasyonIDPersonelID",
                table: "Musteris",
                column: "OperasyonIDPersonelID",
                principalTable: "Personels",
                principalColumn: "PersonelID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Musteris_Personels_SatisIDPersonelID",
                table: "Musteris",
                column: "SatisIDPersonelID",
                principalTable: "Personels",
                principalColumn: "PersonelID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
