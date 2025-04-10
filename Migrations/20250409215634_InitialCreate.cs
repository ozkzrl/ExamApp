using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMvcExamProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_BookId",
                table: "Questions",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Books_BookId",
                table: "Questions",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Books_BookId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Questions_BookId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Questions");

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CorrectOptionIndex", "Text" },
                values: new object[,]
                {
                    { 1, 0, "George ve Lennie'nin çiftlikte çalışmaya gitme amacı nedir?" },
                    { 2, 1, "Lennie neden başlarını belaya sokar?" },
                    { 3, 0, "Lennie'nin en büyük hayali nedir?" },
                    { 4, 2, "George, Lennie ile ilgili ne kadar endişelenmektedir?" },
                    { 5, 0, "Çiftlikte çalışmak isteyenlerin motivasyonu nedir?" },
                    { 6, 1, "Lennie'nin başına gelen olaylar neden genellikle trajik sonuçlanır?" },
                    { 7, 3, "George ve Lennie'nin hayalini paylaştığı çiftlikte ne tür bir hayat yaşamayı planlarlar?" },
                    { 8, 2, "George, Lennie'yi hangi durumlarda savunur?" },
                    { 9, 0, "Lennie'nin zihinsel engelli olmasının etkileri nelerdir?" },
                    { 10, 3, "Hangi olay, George'un Lennie'yi öldürmesini zorunlu kılar?" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, true, 1, "Para kazanmak" },
                    { 2, false, 1, "Arkadaş bulmak" },
                    { 3, false, 1, "Macera yaşamak" },
                    { 4, false, 1, "Okula gitmek" },
                    { 5, false, 2, "Yalan söylediği için" },
                    { 6, true, 2, "Güçlü ama zihinsel engelli olduğu için" },
                    { 7, false, 2, "Hırsızlık yaptığı için" },
                    { 8, false, 2, "George'u kıskandığı için" },
                    { 9, true, 3, "Büyük bir çiftlik kurmak" },
                    { 10, false, 3, "Yazın okula gitmek" },
                    { 11, false, 3, "Zengin olmak" },
                    { 12, false, 3, "Tatile gitmek" },
                    { 13, false, 4, "Çiftlikteki diğer işçilerin tavrı" },
                    { 14, false, 4, "Lennie'nin zihinsel engeli" },
                    { 15, true, 4, "George'un arkadaşlık anlayışı" },
                    { 16, false, 4, "Çiftlik işlerinin zor olması" },
                    { 17, false, 5, "Zenginleşme ve güç kazanma" },
                    { 18, true, 5, "Huzurlu bir yaşam kurma" },
                    { 19, false, 5, "Büyük bir çiftlik kurma" },
                    { 20, false, 5, "Görkemli bir ev inşa etme" },
                    { 21, false, 6, "Çevresindeki insanlara zarar vermek" },
                    { 22, true, 6, "Zihinsel engelinin kontrolsüz bir şekilde ortaya çıkması" },
                    { 23, false, 6, "Gözyaşlarını tutamaması" },
                    { 24, false, 6, "Başka insanları kıskanması" },
                    { 25, false, 7, "Yeni insanlar tanımak" },
                    { 26, false, 7, "Büyük bir çiftlikte çalışmak" },
                    { 27, false, 7, "Güvenli bir yaşam sürmek" },
                    { 28, true, 7, "Kendi çiftliklerine sahip olmak" },
                    { 29, false, 8, "Onun adına parayı almak" },
                    { 30, true, 8, "Ona güvenmek ve korumak" },
                    { 31, false, 8, "Başka insanlara yardım etmek" },
                    { 32, false, 8, "Kendi çıkarlarını savunmak" },
                    { 33, true, 9, "Düşünmeden hareket etmesi" },
                    { 34, false, 9, "Çevresindeki insanları sevmesi" },
                    { 35, false, 9, "George'a duyduğu hayranlık" },
                    { 36, false, 9, "Kendi gücünü fark etmesi" },
                    { 37, false, 10, "Bir başkasına zarar vermek" },
                    { 38, true, 10, "Lennie'nin yanlış anlaması" },
                    { 39, false, 10, "Çiftlikteki diğer işçilerin sorumsuzluğu" },
                    { 40, false, 10, "Çiftlik yöneticisinin cezalandırması" }
                });
        }
    }
}
