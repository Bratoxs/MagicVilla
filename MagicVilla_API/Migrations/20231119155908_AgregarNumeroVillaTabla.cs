using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNumeroVillaTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumeroVillas",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    DetalleEspecial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroVillas", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_NumeroVillas_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_NumeroVillas_VillaId",
                table: "NumeroVillas",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumeroVillas");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "fechaActualizacion" },
                values: new object[] { new DateTime(2023, 11, 17, 16, 5, 29, 281, DateTimeKind.Local).AddTicks(2647), new DateTime(2023, 11, 17, 16, 5, 29, 281, DateTimeKind.Local).AddTicks(2657) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "fechaActualizacion" },
                values: new object[] { new DateTime(2023, 11, 17, 16, 5, 29, 281, DateTimeKind.Local).AddTicks(2660), new DateTime(2023, 11, 17, 16, 5, 29, 281, DateTimeKind.Local).AddTicks(2660) });
        }
    }
}
