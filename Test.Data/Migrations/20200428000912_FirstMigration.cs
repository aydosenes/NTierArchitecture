using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityNo = table.Column<long>(maxLength: 11, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    SurName = table.Column<string>(maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubTest",
                columns: table => new
                {
                    SubTestModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(maxLength: 20, nullable: false),
                    City = table.Column<string>(maxLength: 20, nullable: false),
                    Phone = table.Column<long>(maxLength: 10, nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    TestModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTest", x => x.SubTestModelId);
                    table.ForeignKey(
                        name: "FK_SubTest_Test_TestModelId",
                        column: x => x.TestModelId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "Id", "BirthDate", "IdentityNo", "Name", "SurName", "isDeleted" },
                values: new object[] { 1, new DateTime(1995, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 12345678910L, "Name1", "Surname1", false });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "Id", "BirthDate", "IdentityNo", "Name", "SurName", "isDeleted" },
                values: new object[] { 2, new DateTime(1995, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 12345678912L, "Name2", "Surname2", false });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "Id", "BirthDate", "IdentityNo", "Name", "SurName", "isDeleted" },
                values: new object[] { 3, new DateTime(1995, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 12345678914L, "Name3", "Surname3", false });

            migrationBuilder.InsertData(
                table: "SubTest",
                columns: new[] { "SubTestModelId", "City", "Country", "Phone", "TestModelId", "isDeleted" },
                values: new object[] { 1, "Ankara", "Turkey", 5321234567L, 1, false });

            migrationBuilder.InsertData(
                table: "SubTest",
                columns: new[] { "SubTestModelId", "City", "Country", "Phone", "TestModelId", "isDeleted" },
                values: new object[] { 2, "Istanbul", "Turkey", 5321234567L, 2, false });

            migrationBuilder.InsertData(
                table: "SubTest",
                columns: new[] { "SubTestModelId", "City", "Country", "Phone", "TestModelId", "isDeleted" },
                values: new object[] { 3, "Izmir", "Turkey", 5321234567L, 3, false });

            migrationBuilder.CreateIndex(
                name: "IX_SubTest_TestModelId",
                table: "SubTest",
                column: "TestModelId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTest");

            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
