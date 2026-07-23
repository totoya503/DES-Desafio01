using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DES___Desafio_1.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEmpleados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_Empleados_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "EmpleadoId", "DepartamentoId", "Descripcion", "FechaContratacion", "FechaNacimiento", "Nombre", "Salario" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2010, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", 50000m },
                    { 2, 2, null, new DateTime(2015, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith", 70000m },
                    { 3, 3, null, new DateTime(2012, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1982, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark Johnson", 55000m },
                    { 4, 1, null, new DateTime(2005, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily Davis", 75000m },
                    { 5, 2, null, new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael Brown", 60000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_DepartamentoId",
                table: "Empleados",
                column: "DepartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
