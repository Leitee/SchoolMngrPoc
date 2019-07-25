using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandora.NetStandard.Data.Migrations
{
    public partial class addDeletedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Disable",
                schema: "School",
                table: "SubjectAssingments",
                newName: "Deleted");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "13e17977-1360-4339-aba6-94488ee52935");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ae6b4e4c-50c3-4384-952e-4f66a6aa8379");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "bf206a54-6c36-4b6c-b0b7-095684b5bc49");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "380f8b16-29f5-4f17-82ae-737083bc6b4f");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "5bfc1652-f452-4881-8e92-a2fcff80cfe8");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "6d0fccfd-c3b9-40dd-ae0c-655903116192", new DateTime(2019, 7, 25, 2, 0, 1, 231, DateTimeKind.Utc).AddTicks(4975), "AQAAAAEAACcQAAAAEOy7klBCy3dhyEPbVFP0Z3N2fhtJmKnAM1tva4w2HhQI8QVN7/Z971D78zgMVg4uYQ==" });

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "ed61cf66-7666-4bc7-92d3-52235ad7b185", new DateTime(2019, 7, 25, 2, 0, 1, 245, DateTimeKind.Utc).AddTicks(6018), "AQAAAAEAACcQAAAAEI4ITpGaJ70iZgCxl260xczLiUhvci23VBsj71CKQ8KAuum9Awc0vZe7TYdn3iGveg==" });

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "17ced13f-6c8c-4662-8fa7-803068fb9e4f", new DateTime(2019, 7, 25, 2, 0, 1, 254, DateTimeKind.Utc).AddTicks(5084), "AQAAAAEAACcQAAAAEPTfwLXVud7o6RmXBw0yYyVI3RGZ0dzoxUYOW48SLvTZzV7egIGPx4fx5/eze9hIeQ==" });

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "8ed2d6c5-7cb7-4114-a0a7-5fe3365ae664", new DateTime(2019, 7, 25, 2, 0, 1, 262, DateTimeKind.Utc).AddTicks(3922), "AQAAAAEAACcQAAAAEIpsMozczm6Jpayp6eBdWo2hhLLqmR+NotrZ7v2PXq9kkaVzaJ+TvLh4CoxXyUQtgg==" });

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "526a48e3-0c12-4db3-a81d-b72d4e049657", new DateTime(2019, 7, 25, 2, 0, 1, 269, DateTimeKind.Utc).AddTicks(3167), "AQAAAAEAACcQAAAAELmoDvdJ6ZEuMp5SAf9nKbFpPFWu7Ble4DOkxiUQQkdAwu09hjNz3QyKmksVIueZrg==" });

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "0a2ed0d2-1471-473b-a9fe-26ee269aeffd", new DateTime(2019, 7, 25, 2, 0, 1, 278, DateTimeKind.Utc).AddTicks(5555), "AQAAAAEAACcQAAAAEO8J7oplILHdTzAuBl38oVAWUMQ2ass+me4hUIlGf25V5ggVPU0CnOh3H+drWlvsWA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deleted",
                schema: "School",
                table: "SubjectAssingments",
                newName: "Disable");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "79c59c9c-1e31-4017-9b62-33b350f7bcca");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d13452da-7fb7-41a1-833d-7104e228f62f");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c2233b8f-2bed-478d-9e97-845de7d0e404");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "49c207c7-6a13-48f9-9b4f-b3a8261cea49");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "ff1e828a-6434-458d-9d94-78a7e32215e3");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "a1637585-1120-46bc-8937-0bdef470e839", new DateTime(2019, 6, 14, 2, 50, 26, 4, DateTimeKind.Utc).AddTicks(4287), "AQAAAAEAACcQAAAAELQRDSDYGKOTHvwK+yh4E6jpZLWdMHO6xbbzNrTzq61hS9Yp9tkF/bO4lzYM/1TeLQ==" });

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "1645d07f-7cfe-4b07-989f-a105c434aca6", new DateTime(2019, 6, 14, 2, 50, 26, 12, DateTimeKind.Utc).AddTicks(3500), "AQAAAAEAACcQAAAAEJQEXGcv6K/sqzcmGiAtRAe4POZ+mSIFVn+inn7w73zWKHYZe0Akb4dAtvT+AMD54Q==" });

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "3e097363-070a-4927-bff6-87d3d5422b76", new DateTime(2019, 6, 14, 2, 50, 26, 17, DateTimeKind.Utc).AddTicks(3532), "AQAAAAEAACcQAAAAEIAQxKyMzjQvxx9tWdkk2RkjkLxmDW0gEHQLDTzgws+bxsmj6SBJU+cbPIxRFYARMw==" });

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "2703a81e-1c04-4897-9e09-8e6c955e678a", new DateTime(2019, 6, 14, 2, 50, 26, 22, DateTimeKind.Utc).AddTicks(3233), "AQAAAAEAACcQAAAAEFcYsRnUEcreRtrC/NykXTrigDvxMNJ2eiaM805KGJzbNXpnxjLZhn1Y+OIc8au/pg==" });

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "45f5145a-4cfd-4030-871e-4ed5642bfafc", new DateTime(2019, 6, 14, 2, 50, 26, 27, DateTimeKind.Utc).AddTicks(3120), "AQAAAAEAACcQAAAAEChA1GDqX91r8IVoxat7u49wCwCx71n3UbqOMWe+3kzTOZPrQUDLR7JprrzGNKxmkg==" });

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "01c5f351-bcdf-49e4-bd16-fc8b09b09b1e", new DateTime(2019, 6, 14, 2, 50, 26, 32, DateTimeKind.Utc).AddTicks(2738), "AQAAAAEAACcQAAAAEITCaGTYRyNkrNndG6k6Pd4T4ACE64Drt/DiJKBaovQ1xohNw0n1nPjc9etRt7FQPQ==" });
        }
    }
}
