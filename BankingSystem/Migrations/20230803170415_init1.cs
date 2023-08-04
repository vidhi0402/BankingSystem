using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingSystem.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccountType_FK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_AccountTypes_AccountType_FK",
                        column: x => x.AccountType_FK,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod_FK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccount_FK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankTransactions_BankAccounts_BankAccount_FK",
                        column: x => x.BankAccount_FK,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankTransactions_PaymentMethods_PaymentMethod_FK",
                        column: x => x.PaymentMethod_FK,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountPostings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankTransationId_FK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountPostings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccountPostings_BankTransactions_BankTransationId_FK",
                        column: x => x.BankTransationId_FK,
                        principalTable: "BankTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ab80a42f-7ea5-4d6e-8f84-7b041e95794d"), "Liability" },
                    { new Guid("ac39bf8b-36a0-4523-a0b2-8ea47172e6a8"), "Asset" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1e8ad561-4bc7-4995-b731-b7c61f93b099"), "Cash" },
                    { new Guid("5d40a7ce-3454-406f-bf1e-2f52cbd2d5c6"), "NEFT" },
                    { new Guid("75e898a7-44e6-4552-b57d-777181c95290"), "Cheque" },
                    { new Guid("87e7f6b5-82fa-460d-ae43-52d93bf7831e"), "Other" },
                    { new Guid("9b57941f-466c-4a86-bb41-c5b5811d3a36"), "RTGS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountPostings_BankTransationId_FK",
                table: "BankAccountPostings",
                column: "BankTransationId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_AccountType_FK",
                table: "BankAccounts",
                column: "AccountType_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_BankAccount_FK",
                table: "BankTransactions",
                column: "BankAccount_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_PaymentMethod_FK",
                table: "BankTransactions",
                column: "PaymentMethod_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccountPostings");

            migrationBuilder.DropTable(
                name: "BankTransactions");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "AccountTypes");
        }
    }
}
