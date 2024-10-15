using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BooksApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesUpdateNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EducationalBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalBooks_Books_Id",
                        column: x => x.Id,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FictionBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeRestrictions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FictionBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FictionBooks_Books_Id",
                        column: x => x.Id,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublisherBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublisherBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublisherBooks_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "Name", "Year" },
                values: new object[] { "Joanne Rowling", "Harry Potter", 2000 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Name", "Year" },
                values: new object[] { "John Ronald Reuel Tolkien", "The Lord of the Rings", 2010 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "Name", "Year" },
                values: new object[] { "Natalya Shulzhenka", "C# for adults", 2015 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Name", "Year" },
                values: new object[] { 4, "Mister Bean", "How to learn", 2005 });

            migrationBuilder.InsertData(
                table: "EducationalBooks",
                columns: new[] { "Id", "Level", "Speciality" },
                values: new object[] { 3, "Adults", "Programming" });

            migrationBuilder.InsertData(
                table: "FictionBooks",
                columns: new[] { "Id", "AgeRestrictions", "Genre" },
                values: new object[,]
                {
                    { 1, 6, "Fantasy" },
                    { 2, 18, "Mystery" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "Belarus", "Ad Press" },
                    { 2, "Poland", "Academic Studies" }
                });

            migrationBuilder.InsertData(
                table: "EducationalBooks",
                columns: new[] { "Id", "Level", "Speciality" },
                values: new object[] { 4, "Childrren", "Psycology" });

            migrationBuilder.InsertData(
                table: "PublisherBooks",
                columns: new[] { "Id", "BookId", "PublisherId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublisherBooks_BookId",
                table: "PublisherBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_PublisherBooks_PublisherId",
                table: "PublisherBooks",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationalBooks");

            migrationBuilder.DropTable(
                name: "FictionBooks");

            migrationBuilder.DropTable(
                name: "PublisherBooks");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "Name", "Year" },
                values: new object[] { "Roman", "First book", 2010 });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Name", "Year" },
                values: new object[] { "Natalya", "Second book", 2020 });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "Name", "Year" },
                values: new object[] { "Anton", "Third book", 2021 });
        }
    }
}
