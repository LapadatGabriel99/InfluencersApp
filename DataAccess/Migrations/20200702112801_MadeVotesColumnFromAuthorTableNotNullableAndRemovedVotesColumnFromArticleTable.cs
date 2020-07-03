using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class MadeVotesColumnFromAuthorTableNotNullableAndRemovedVotesColumnFromArticleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Votes",
                table: "Article");

            migrationBuilder.AlterColumn<int>(
                name: "Votes",
                table: "Author",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Votes",
                table: "Author",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Votes",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
