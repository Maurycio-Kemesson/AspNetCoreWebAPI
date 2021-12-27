using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWda.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublishingCompanys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishingCompanys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    PublishingCompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_PublishingCompanys_PublishingCompanyId",
                        column: x => x.PublishingCompanyId,
                        principalTable: "PublishingCompanys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLoans",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoans", x => new { x.StudentId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookLoans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLoans_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PublishingCompanys",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Interseca" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Name", "Surname", "Telephone" },
                values: new object[] { 1, "Rua A", "Maurycio", "Kemesson", "33225555" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Name", "Surname", "Telephone" },
                values: new object[] { 2, "Rua A", "Valdeli", "Nascimento", "3354288" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Name", "Surname", "Telephone" },
                values: new object[] { 3, "Rua A", "Rafael", "Araujo", "55668899" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Name", "Surname", "Telephone" },
                values: new object[] { 4, "Rua A", "Lucas", "Unifametro", "6565659" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Name", "Surname", "Telephone" },
                values: new object[] { 5, "Rua A", "Rhaun", "Junior", "565685415" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Name", "Surname", "Telephone" },
                values: new object[] { 6, "Rua A", "Caio", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Name", "Surname", "Telephone" },
                values: new object[] { 7, "Rua A", "Pedro", "Lucas", "9874512" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "maurycio.kemesson@gmail.com", "Maurycio Kemesson", "Qwe123*" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "PublishingCompanyId", "Title" },
                values: new object[] { 1, 1, "A culpa é das estrelas" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "PublishingCompanyId", "Title" },
                values: new object[] { 2, 1, "Quem é você alasca" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "PublishingCompanyId", "Title" },
                values: new object[] { 3, 1, "A dois passos de você" });

            migrationBuilder.InsertData(
                table: "BookLoans",
                columns: new[] { "StudentId", "BookId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "BookLoans",
                columns: new[] { "StudentId", "BookId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "BookLoans",
                columns: new[] { "StudentId", "BookId" },
                values: new object[] { 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_BookId",
                table: "BookLoans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublishingCompanyId",
                table: "Books",
                column: "PublishingCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLoans");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "PublishingCompanys");
        }
    }
}
