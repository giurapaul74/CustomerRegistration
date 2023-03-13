using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerRegistration.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedStreetNumberDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Number", "PostalCode", "Street" },
                values: new object[] { 2, "New Orleans", "US", 543, "358394", "Checkery Street" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "EmailAddress", "InvoiceAddressId", "Name", "PhoneNumber", "PostalAddressId", "Website" },
                values: new object[] { 2, "pl.blrt@gmail.com", 2, "Paul Blart", "555-8474-1732", 2, "www.emtspecials.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
