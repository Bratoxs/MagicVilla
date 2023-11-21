using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NumeroVillas_Villas_VillaId",
                table: "NumeroVillas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Villas",
                table: "Villas");

            migrationBuilder.RenameTable(
                name: "Villas",
                newName: "Villa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Villa",
                table: "Villa",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 11, 20, 19, 4, 3, 645, DateTimeKind.Local).AddTicks(5122), new DateTime(2023, 11, 20, 19, 4, 3, 645, DateTimeKind.Local).AddTicks(5112) });

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 11, 20, 19, 4, 3, 645, DateTimeKind.Local).AddTicks(5124), new DateTime(2023, 11, 20, 19, 4, 3, 645, DateTimeKind.Local).AddTicks(5124) });

            migrationBuilder.AddForeignKey(
                name: "FK_NumeroVillas_Villa_VillaId",
                table: "NumeroVillas",
                column: "VillaId",
                principalTable: "Villa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NumeroVillas_Villa_VillaId",
                table: "NumeroVillas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Villa",
                table: "Villa");

            migrationBuilder.RenameTable(
                name: "Villa",
                newName: "Villas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Villas",
                table: "Villas",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 11, 19, 20, 50, 13, 804, DateTimeKind.Local).AddTicks(948), new DateTime(2023, 11, 19, 20, 50, 13, 804, DateTimeKind.Local).AddTicks(937) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 11, 19, 20, 50, 13, 804, DateTimeKind.Local).AddTicks(950), new DateTime(2023, 11, 19, 20, 50, 13, 804, DateTimeKind.Local).AddTicks(950) });

            migrationBuilder.AddForeignKey(
                name: "FK_NumeroVillas_Villas_VillaId",
                table: "NumeroVillas",
                column: "VillaId",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
