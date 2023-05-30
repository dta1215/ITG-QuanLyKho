using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKho.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChitietNhapxuats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    so_phieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay_lap_phieu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ma_vt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ten_vt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dvt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sl_nhap = table.Column<float>(type: "real", nullable: true),
                    sl_xuat = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitietNhapxuats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChitietNhapxuats");
        }
    }
}
