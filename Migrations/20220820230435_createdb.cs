using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fika.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grups",
                columns: table => new
                {
                    GrupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grups", x => x.GrupID);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    PersonelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.PersonelID);
                });

            migrationBuilder.CreateTable(
                name: "Stoks",
                columns: table => new
                {
                    StokID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoks", x => x.StokID);
                });

            migrationBuilder.CreateTable(
                name: "Musteris",
                columns: table => new
                {
                    MusteriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrupID = table.Column<int>(type: "int", nullable: false),
                    SatisIDPersonelID = table.Column<int>(type: "int", nullable: true),
                    OperasyonIDPersonelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteris", x => x.MusteriID);
                    table.ForeignKey(
                        name: "FK_Musteris_Grups_GrupID",
                        column: x => x.GrupID,
                        principalTable: "Grups",
                        principalColumn: "GrupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musteris_Personels_OperasyonIDPersonelID",
                        column: x => x.OperasyonIDPersonelID,
                        principalTable: "Personels",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Musteris_Personels_SatisIDPersonelID",
                        column: x => x.SatisIDPersonelID,
                        principalTable: "Personels",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SatisHarekets",
                columns: table => new
                {
                    SatisHareketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokID = table.Column<int>(type: "int", nullable: false),
                    MusteriID = table.Column<int>(type: "int", nullable: false),
                    PersonelID = table.Column<int>(type: "int", nullable: false),
                    SatisZamani = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisHarekets", x => x.SatisHareketID);
                    table.ForeignKey(
                        name: "FK_SatisHarekets_Musteris_MusteriID",
                        column: x => x.MusteriID,
                        principalTable: "Musteris",
                        principalColumn: "MusteriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SatisHarekets_Personels_PersonelID",
                        column: x => x.PersonelID,
                        principalTable: "Personels",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SatisHarekets_Stoks_StokID",
                        column: x => x.StokID,
                        principalTable: "Stoks",
                        principalColumn: "StokID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musteris_GrupID",
                table: "Musteris",
                column: "GrupID");

            migrationBuilder.CreateIndex(
                name: "IX_Musteris_OperasyonIDPersonelID",
                table: "Musteris",
                column: "OperasyonIDPersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_Musteris_SatisIDPersonelID",
                table: "Musteris",
                column: "SatisIDPersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_SatisHarekets_MusteriID",
                table: "SatisHarekets",
                column: "MusteriID");

            migrationBuilder.CreateIndex(
                name: "IX_SatisHarekets_PersonelID",
                table: "SatisHarekets",
                column: "PersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_SatisHarekets_StokID",
                table: "SatisHarekets",
                column: "StokID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SatisHarekets");

            migrationBuilder.DropTable(
                name: "Musteris");

            migrationBuilder.DropTable(
                name: "Stoks");

            migrationBuilder.DropTable(
                name: "Grups");

            migrationBuilder.DropTable(
                name: "Personels");
        }
    }
}
