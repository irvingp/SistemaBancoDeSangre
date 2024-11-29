using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaBancoDeSangre.Data.Migrations
{
    public partial class modificaControlDonaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CentroDonacion_ControlDonaciones_ControlDonacionesID",
                table: "CentroDonacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Donante_ControlDonaciones_ControlDonacionesID",
                table: "Donante");

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

            migrationBuilder.AddColumn<int>(
                name: "CentroDonacionId",
                table: "ControlDonaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DonanteId",
                table: "ControlDonaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ControlDonaciones_CentroDonacionId",
                table: "ControlDonaciones",
                column: "CentroDonacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlDonaciones_DonanteId",
                table: "ControlDonaciones",
                column: "DonanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlDonaciones_CentroDonacion_CentroDonacionId",
                table: "ControlDonaciones",
                column: "CentroDonacionId",
                principalTable: "CentroDonacion",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlDonaciones_Donante_DonanteId",
                table: "ControlDonaciones",
                column: "DonanteId",
                principalTable: "Donante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlDonaciones_CentroDonacion_CentroDonacionId",
                table: "ControlDonaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlDonaciones_Donante_DonanteId",
                table: "ControlDonaciones");

            migrationBuilder.DropIndex(
                name: "IX_ControlDonaciones_CentroDonacionId",
                table: "ControlDonaciones");

            migrationBuilder.DropIndex(
                name: "IX_ControlDonaciones_DonanteId",
                table: "ControlDonaciones");

            migrationBuilder.DropColumn(
                name: "CentroDonacionId",
                table: "ControlDonaciones");

            migrationBuilder.DropColumn(
                name: "DonanteId",
                table: "ControlDonaciones");

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
    }
}
