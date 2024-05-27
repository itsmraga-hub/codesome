using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codesome.Migrations
{
    public partial class UpdateAuthorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CourseCategories_CourseCategoryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseCategories_CourseCategoryId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_AuthorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTags_CourseCategories_CourseCategoryId",
                table: "CourseTags");

            migrationBuilder.DropTable(
                name: "CategoryCourse");

            migrationBuilder.DropIndex(
                name: "IX_CourseTags_CourseCategoryId",
                table: "CourseTags");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseCategoryId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CourseCategoryId",
                table: "CourseTags");

            migrationBuilder.DropColumn(
                name: "CourseAuthorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseCategoryId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseCategoryId",
                table: "Categories",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CourseCategoryId",
                table: "Categories",
                newName: "IX_Categories_CourseId");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "AuthorId",
                keyValue: null,
                column: "AuthorId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Courses",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Courses_CourseId",
                table: "Categories",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_AuthorId",
                table: "Courses",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Courses_CourseId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_AuthorId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Categories",
                newName: "CourseCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CourseId",
                table: "Categories",
                newName: "IX_Categories_CourseCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseCategoryId",
                table: "CourseTags",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Courses",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CourseAuthorId",
                table: "Courses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CourseCategoryId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryCourse",
                columns: table => new
                {
                    CourseCategoriesId = table.Column<int>(type: "int", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCourse", x => new { x.CourseCategoriesId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_CategoryCourse_Categories_CourseCategoriesId",
                        column: x => x.CourseCategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryCourse_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTags_CourseCategoryId",
                table: "CourseTags",
                column: "CourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCategoryId",
                table: "Courses",
                column: "CourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCourse_CoursesId",
                table: "CategoryCourse",
                column: "CoursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_CourseCategories_CourseCategoryId",
                table: "Categories",
                column: "CourseCategoryId",
                principalTable: "CourseCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseCategories_CourseCategoryId",
                table: "Courses",
                column: "CourseCategoryId",
                principalTable: "CourseCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_AuthorId",
                table: "Courses",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTags_CourseCategories_CourseCategoryId",
                table: "CourseTags",
                column: "CourseCategoryId",
                principalTable: "CourseCategories",
                principalColumn: "Id");
        }
    }
}
