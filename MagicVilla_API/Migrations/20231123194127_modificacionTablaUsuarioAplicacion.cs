using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class modificacionTablaUsuarioAplicacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 11, 23, 14, 41, 27, 365, DateTimeKind.Local).AddTicks(1921), new DateTime(2023, 11, 23, 14, 41, 27, 365, DateTimeKind.Local).AddTicks(1911) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 11, 23, 14, 41, 27, 365, DateTimeKind.Local).AddTicks(1923), new DateTime(2023, 11, 23, 14, 41, 27, 365, DateTimeKind.Local).AddTicks(1923) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 11, 23, 14, 26, 14, 926, DateTimeKind.Local).AddTicks(5475), new DateTime(2023, 11, 23, 14, 26, 14, 926, DateTimeKind.Local).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 11, 23, 14, 26, 14, 926, DateTimeKind.Local).AddTicks(5477), new DateTime(2023, 11, 23, 14, 26, 14, 926, DateTimeKind.Local).AddTicks(5477) });
        }
    }
}
