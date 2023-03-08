using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerRegistration.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTestRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Number", "PostalCode", "Street" },
                values: new object[] { 1, "DC", "US", 56, "762853", "New Wantons" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "EmailAddress", "InvoiceAddressId", "Name", "PhoneNumber", "PostalAddressId", "Website" },
                values: new object[] { 1, "chr.undr@gmail.com", 1, "Christian Undertow", "555-1745-9745", 1, "www.nonewrelevance.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
