using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("f7d31d43-485b-4499-9502-97c3cf0c8061"), null, "Actividades Personales", 50 },
                    { new Guid("f7d31d43-485b-4499-9502-97c3cf0c806d"), null, "Actividades Pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "TaskPriority", "Title" },
                values: new object[,]
                {
                    { new Guid("f7d31d43-485b-4499-9502-97c3cf0c8100"), new Guid("f7d31d43-485b-4499-9502-97c3cf0c8061"), new DateTime(2023, 7, 3, 22, 21, 4, 279, DateTimeKind.Local).AddTicks(2530), null, 1, "Sacar a zeus" },
                    { new Guid("f7d31d43-485b-4499-9502-97c3cf0c81a1"), new Guid("f7d31d43-485b-4499-9502-97c3cf0c8061"), new DateTime(2023, 7, 3, 22, 21, 4, 279, DateTimeKind.Local).AddTicks(2530), null, 0, "Nose" },
                    { new Guid("f7d31d43-485b-4499-9502-97c3cf0c8780"), new Guid("f7d31d43-485b-4499-9502-97c3cf0c806d"), new DateTime(2023, 7, 3, 22, 21, 4, 279, DateTimeKind.Local).AddTicks(2520), null, 2, "Hacer la tarea de la U" },
                    { new Guid("f7d31d43-485b-4499-9502-97c3cf0c8789"), new Guid("f7d31d43-485b-4499-9502-97c3cf0c806d"), new DateTime(2023, 7, 3, 22, 21, 4, 279, DateTimeKind.Local).AddTicks(2490), null, 1, "Pago servicios publicos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8100"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c81a1"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8780"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8789"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8061"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c806d"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
