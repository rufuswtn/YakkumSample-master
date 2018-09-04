using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DokumenWebApps.Data.Migrations
{
    public partial class TambahTabelDokumen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.CreateTable(
                name: "Klasifikasi",
                columns: table => new
                {
                    KodeKlasifikasi = table.Column<string>(maxLength: 20, nullable: false),
                    Induk = table.Column<string>(maxLength: 20, nullable: true),
                    Level = table.Column<int>(nullable: false),
                    NamaKlasifikasi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klasifikasi", x => x.KodeKlasifikasi);
                });

            migrationBuilder.CreateTable(
                name: "Dokumen",
                columns: table => new
                {
                    DokumenID = table.Column<string>(maxLength: 20, nullable: false),
                    KodeKlasifikasi = table.Column<string>(nullable: true),
                    NamaDokumen = table.Column<string>(nullable: true),
                    TanggalDibuat = table.Column<DateTime>(nullable: false),
                    TanggalDiterima = table.Column<DateTime>(nullable: false),
                    Sumber = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumen", x => x.DokumenID);
                    table.ForeignKey(
                        name: "FK_Dokumen_Klasifikasi_KodeKlasifikasi",
                        column: x => x.KodeKlasifikasi,
                        principalTable: "Klasifikasi",
                        principalColumn: "KodeKlasifikasi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dokumen_KodeKlasifikasi",
                table: "Dokumen",
                column: "KodeKlasifikasi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dokumen");

            migrationBuilder.DropTable(
                name: "Klasifikasi");

            migrationBuilder.CreateTable(
                name: "Classifications",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Keterangan = table.Column<string>(nullable: true),
                    Kode = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifications", x => x.ID);
                });
        }
    }
}
