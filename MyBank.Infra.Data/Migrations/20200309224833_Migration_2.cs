using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBank.Infra.Data.Migrations
{
    public partial class Migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Profitable",
                table: "BankAccount",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "BankCustomer",
                columns: new[] { "Id", "Address", "Document", "FullName", "Name" },
                values: new object[] { 1L, "The North", "00000000000", "Snow", "John" });

            migrationBuilder.InsertData(
                table: "BankAccount",
                columns: new[] { "Id", "Account", "AuthorizationPass", "BankCustomerId", "Branch", "CreateDate", "Digit", "IsMainAccount", "Profitable", "TotalBalance", "Type", "Uid" },
                values: new object[] { 1L, "0010", "1234", 1L, "0001", new DateTime(2020, 3, 9, 19, 48, 32, 817, DateTimeKind.Local).AddTicks(4025), "1", true, true, 0m, "CURRENT_ACCOUNT", new Guid("ad2fc66e-eecd-42d3-b661-42cab2444320") });

            migrationBuilder.InsertData(
                table: "BankTransaction",
                columns: new[] { "Id", "Amount", "BankAccountId", "CreateDate", "Description" },
                values: new object[] { 1L, 0m, 1L, new DateTime(2020, 3, 9, 19, 48, 32, 830, DateTimeKind.Local).AddTicks(4694), "Initital Transaction" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BankTransaction",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "BankAccount",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "BankCustomer",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "Profitable",
                table: "BankAccount");
        }
    }
}
