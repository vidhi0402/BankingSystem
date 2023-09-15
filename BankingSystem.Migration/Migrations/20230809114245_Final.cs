using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingSystem.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("31d71cdc-bd13-4595-9115-767801d7cada"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("824e7549-8bf7-4454-900a-ef48303b184c"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("65e31bdf-12d2-478a-b8e8-f4e4f02013d1"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("7ffe1622-ee29-424b-a248-942938b993dc"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("dcc1a001-98a3-47e1-8256-f1b4fa9206e6"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("f3d2e807-c5ad-4b65-bae0-8de2fc05528b"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("f6dcba8a-89d5-401a-b4be-34fd5b38f49a"));

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8f878e13-f1d9-474d-ae98-6df3fe3b758d"), "Liability" },
                    { new Guid("9c1fc495-2f69-4a23-9161-e645acfebfa9"), "Asset" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3cecfffe-5ada-43af-b7fb-136dced78203"), "Other" },
                    { new Guid("4afad743-de20-41cd-97ad-2a27fcb79f34"), "Cash" },
                    { new Guid("5720e2d6-69aa-48c1-8e6d-e267eeb3f8c0"), "Cheque" },
                    { new Guid("7b033d28-374d-4873-a46f-af7780639b3e"), "NEFT" },
                    { new Guid("bbd9e10e-96a8-4978-8a42-c77910476384"), "RTGS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("8f878e13-f1d9-474d-ae98-6df3fe3b758d"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("9c1fc495-2f69-4a23-9161-e645acfebfa9"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("3cecfffe-5ada-43af-b7fb-136dced78203"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("4afad743-de20-41cd-97ad-2a27fcb79f34"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("5720e2d6-69aa-48c1-8e6d-e267eeb3f8c0"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("7b033d28-374d-4873-a46f-af7780639b3e"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("bbd9e10e-96a8-4978-8a42-c77910476384"));

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("31d71cdc-bd13-4595-9115-767801d7cada"), "Asset" },
                    { new Guid("824e7549-8bf7-4454-900a-ef48303b184c"), "Liability" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("65e31bdf-12d2-478a-b8e8-f4e4f02013d1"), "Cash" },
                    { new Guid("7ffe1622-ee29-424b-a248-942938b993dc"), "Cheque" },
                    { new Guid("dcc1a001-98a3-47e1-8256-f1b4fa9206e6"), "RTGS" },
                    { new Guid("f3d2e807-c5ad-4b65-bae0-8de2fc05528b"), "NEFT" },
                    { new Guid("f6dcba8a-89d5-401a-b4be-34fd5b38f49a"), "Other" }
                });
        }
    }
}
