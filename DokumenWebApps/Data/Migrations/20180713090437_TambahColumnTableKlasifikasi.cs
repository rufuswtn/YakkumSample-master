using Microsoft.EntityFrameworkCore.Migrations;

namespace DokumenWebApps.Data.Migrations
{
    public partial class TambahColumnTableKlasifikasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RetensiAktif",
                table: "Klasifikasi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RetensiInaktif",
                table: "Klasifikasi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "StatusAktif",
                table: "Klasifikasi",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Uraian",
                table: "Klasifikasi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RetensiAktif",
                table: "Klasifikasi");

            migrationBuilder.DropColumn(
                name: "RetensiInaktif",
                table: "Klasifikasi");

            migrationBuilder.DropColumn(
                name: "StatusAktif",
                table: "Klasifikasi");

            migrationBuilder.DropColumn(
                name: "Uraian",
                table: "Klasifikasi");
        }
    }
}
