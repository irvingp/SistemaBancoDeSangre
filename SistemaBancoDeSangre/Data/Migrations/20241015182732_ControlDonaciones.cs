using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaBancoDeSangre.Data.Migrations
{
    public partial class ControlDonaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ControlDonacionesID",
                table: "Donante",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ControlDonacionesID",
                table: "CentroDonacion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ControlDonaciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaDonacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlDonaciones", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donante_ControlDonacionesID",
                table: "Donante",
                column: "ControlDonacionesID");

            migrationBuilder.CreateIndex(
                name: "IX_CentroDonacion_ControlDonacionesID",
                table: "CentroDonacion",
                column: "ControlDonacionesID");

            migrationBuilder.AddForeignKey(
                name: "FK_CentroDonacion_ControlDonaciones_ControlDonacionesID",
                table: "CentroDonacion",
                column: "ControlDonacionesID",
                principalTable: "ControlDonaciones",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donante_ControlDonaciones_ControlDonacionesID",
                table: "Donante",
                column: "ControlDonacionesID",
                principalTable: "ControlDonaciones",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CentroDonacion_ControlDonaciones_ControlDonacionesID",
                table: "CentroDonacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Donante_ControlDonaciones_ControlDonacionesID",
                table: "Donante");

            migrationBuilder.DropTable(
                name: "ControlDonaciones");

            migrationBuilder.DropIndex(
                name: "IX_Donante_ControlDonacionesID",
                table: "Donante");

            migrationBuilder.DropIndex(
                name: "IX_CentroDonacion_ControlDonacionesID",
                table: "CentroDonacion");

            migrationBuilder.DropColumn(
                name: "ControlDonacionesID",
                table: "Donante");

            migrationBuilder.DropColumn(
                name: "ControlDonacionesID",
                table: "CentroDonacion");
        }
    }
}
