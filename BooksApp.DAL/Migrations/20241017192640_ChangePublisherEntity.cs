using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BooksApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangePublisherEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublisherBooks_Books_BookId",
                table: "PublisherBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublisherBooks",
                table: "PublisherBooks");

            migrationBuilder.DropIndex(
                name: "IX_PublisherBooks_BookId",
                table: "PublisherBooks");

            migrationBuilder.DeleteData(
                table: "PublisherBooks",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PublisherBooks",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PublisherBooks",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PublisherBooks",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PublisherBooks");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "PublisherBooks",
                newName: "BooksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublisherBooks",
                table: "PublisherBooks",
                columns: new[] { "BooksId", "PublisherId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PublisherBooks_Books_BooksId",
                table: "PublisherBooks",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublisherBooks_Books_BooksId",
                table: "PublisherBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublisherBooks",
                table: "PublisherBooks");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "PublisherBooks",
                newName: "BookId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PublisherBooks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublisherBooks",
                table: "PublisherBooks",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PublisherBooks_Books_BookId",
                table: "PublisherBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
