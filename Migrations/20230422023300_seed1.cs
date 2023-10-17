using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperGalerieInfinie.Migrations
{
    public partial class seed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddf1bcf8-8a68-4e86-be6c-19aaf801ffc0", "AQAAAAEAACcQAAAAENOsQJYfHvORsiyuof9HMszRFNcCXF5ZibRiEpnwi4+fuMYCKGT+0yXocY3fpXmx9A==", "e01ebeab-e369-4526-91ab-90635abddb6d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ea206c5-7228-4e61-aab5-828d0b52f4f3", "AQAAAAEAACcQAAAAECYOF3Uy6Efc76e862wOguEMsAWXPIbOydGymRo0vGHcwjr0KCrzW2wVHE5khnFyug==", "4c88ae12-d3af-46e6-a95a-15a1dc621f23" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3619680-8e85-40a1-ba81-5079884033a1", "AQAAAAEAACcQAAAAEPQ3U7/Sa7pCaweIT5fY74seUG0344IwMXkjn2zEy/QMucP6ekYSIqh1dFeDb3539A==", "f1411307-eebd-460d-92d4-350cba2b6129" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d96ef637-ee5d-4fa5-ac5b-9243801dca8e", "AQAAAAEAACcQAAAAEN7/Z3Zsvf1/AxJwQUOiNtU4w7Wi4OITHP1PSRSWqgSPEvJRoloLWrrIVa6L5xlGRg==", "b6292fac-7a73-4cde-8a9a-25bc26645204" });
        }
    }
}
