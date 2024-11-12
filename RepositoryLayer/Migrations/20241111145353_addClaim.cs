using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class addClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserClaims",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c90791e-7c0c-4366-a315-6d51287c1c76",
                column: "ConcurrencyStamp",
                value: "e3463023-87d4-46f5-bfd7-e48b09b2951e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bad7cc85-8f42-4bf8-a0db-1a078d18ce40",
                column: "ConcurrencyStamp",
                value: "95cca7a5-e842-425c-8372-1db2cfb1a900");

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "Discriminator", "UserId" },
                values: new object[] { 1, "AdminObserverExpireDate", "11/11/2024", "AppUserClaim", "fb2be674-dbfc-4226-8931-f382cbfe79c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "506c3d14-6659-4821-84a1-658b2f27da16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba5ba01f-8fa2-4498-8c3c-475a43158b5a", "AQAAAAIAAYagAAAAEBfc/p5ZRxOS4uxF7RF+dclfFR+EDecy6IXJT+QJvR/vlgU4xVJXexbEEpOg6YWN+A==", "451066ad-0e97-442c-8806-01ef4ce2e766" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb2be674-dbfc-4226-8931-f382cbfe79c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ad15dcd-6b5d-4cfe-941e-40be287d96b1", "AQAAAAIAAYagAAAAEHRj9HXFN3E0bBw3fMA88QzyCEih8O6lVBKTlij7u25nbOMVSUIUiJ+DW0BQe/5DFA==", "1ae754ef-b975-4b35-9323-02f33e9c2d6c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserClaims");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c90791e-7c0c-4366-a315-6d51287c1c76",
                column: "ConcurrencyStamp",
                value: "e84654d0-acf5-48d2-91e9-8a80e0d48a88");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bad7cc85-8f42-4bf8-a0db-1a078d18ce40",
                column: "ConcurrencyStamp",
                value: "b6fc9522-dbae-4a50-be25-8e3572563532");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "506c3d14-6659-4821-84a1-658b2f27da16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06e2a304-6db4-4b12-8ff0-b1915322ea41", "AQAAAAIAAYagAAAAEJ6XGhQr12z6dbBLsU6iTGZVkB9RwKyac59EqK126eix8GQcWzExUNkm2vcABdmKTQ==", "cdc905b0-43e9-401e-8bc6-a51fffd67fa4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb2be674-dbfc-4226-8931-f382cbfe79c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "295a1d49-1491-4838-8562-ebb83ad09cbd", "AQAAAAIAAYagAAAAECVWkvmFi9gqo5VhYFZKXljTsvy1yP/4Rv0U8YAjYMMfUARJGLkZO6ckBqIqqZOITQ==", "e706c044-4f13-408b-a20b-d1f2a72edaae" });
        }
    }
}
