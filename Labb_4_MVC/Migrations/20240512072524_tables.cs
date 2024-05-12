using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb_4_MVC.Migrations
{
    /// <inheritdoc />
    public partial class tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedBook",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowedBook_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowedBook_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("359ef01e-5294-4773-a59a-5b2677bfdcc3"), "C.S.Lewis", "ett lejon och en häxa i garderoben", "Narnia" },
                    { new Guid("5dbffa4c-6956-4cd2-8606-86d59a0c666a"), "Tolkien", "två stora torn", "Two Towers" },
                    { new Guid("bf55ef41-5174-44ad-af48-cf6a7a03aa3f"), "Tolkien", "Magisk ring", "Lord of the rings" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Email", "FullName", "PhoneNumber", "age" },
                values: new object[,]
                {
                    { new Guid("3d14e96d-5526-492b-8494-c0b7b65ba2b0"), "Berit@mail.com", "Berit Bok", "634523", 33 },
                    { new Guid("8c9a0fb0-274e-494e-be52-7cc58de22bbd"), "Bertil@mail.com", "Bertil Bok", "312453", 32 },
                    { new Guid("fb756fa6-afcb-4163-940f-039877239b34"), "adam@mail.com", "Adam Ask", "123456", 23 }
                });

            migrationBuilder.InsertData(
                table: "BorrowedBook",
                columns: new[] { "Id", "BookId", "BorrowedDate", "CustomerId", "IsReturned", "ReturnDate" },
                values: new object[,]
                {
                    { new Guid("8c9a0fb0-274e-494e-be52-7cc58de22bbb"), new Guid("359ef01e-5294-4773-a59a-5b2677bfdcc3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022), new Guid("8c9a0fb0-274e-494e-be52-7cc58de22bbd"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2012) },
                    { new Guid("e58f7808-f945-40b6-bede-d3e1daba6b08"), new Guid("5dbffa4c-6956-4cd2-8606-86d59a0c666a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2016), new Guid("fb756fa6-afcb-4163-940f-039877239b34"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1999) },
                    { new Guid("fa737607-6f55-4608-a301-3d447422de5b"), new Guid("bf55ef41-5174-44ad-af48-cf6a7a03aa3f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022), new Guid("fb756fa6-afcb-4163-940f-039877239b34"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2013) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBook_BookId",
                table: "BorrowedBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBook_CustomerId",
                table: "BorrowedBook",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowedBook");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
