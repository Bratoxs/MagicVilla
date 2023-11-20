using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionCampoFecha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fechaActualizacion",
                table: "Villas",
                newName: "FechaActualizacion");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 11, 19, 13, 58, 46, 717, DateTimeKind.Local).AddTicks(317), new DateTime(2023, 11, 19, 13, 58, 46, 717, DateTimeKind.Local).AddTicks(302) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 11, 19, 13, 58, 46, 717, DateTimeKind.Local).AddTicks(322), new DateTime(2023, 11, 19, 13, 58, 46, 717, DateTimeKind.Local).AddTicks(321) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaActualizacion",
                table: "Villas",
                newName: "fechaActualizacion");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "fechaActualizacion" },
                values: new object[] { new DateTime(2023, 11, 19, 10, 59, 8, 226, DateTimeKind.Local).AddTicks(3687), new DateTime(2023, 11, 19, 10, 59, 8, 226, DateTimeKind.Local).AddTicks(3703) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "fechaActualizacion" },
                values: new object[] { new DateTime(2023, 11, 19, 10, 59, 8, 226, DateTimeKind.Local).AddTicks(3706), new DateTime(2023, 11, 19, 10, 59, 8, 226, DateTimeKind.Local).AddTicks(3707) });
        }
    }
}
