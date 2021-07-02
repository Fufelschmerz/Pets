using Microsoft.EntityFrameworkCore.Migrations;

namespace Pets.DataAccess.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Foods",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:DefaultColumnCollation", "my_collation");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Animals",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:DefaultColumnCollation", "my_collation");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "AnimalBreeds",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:DefaultColumnCollation", "my_collation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Foods",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Npgsql:DefaultColumnCollation", "my_collation");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Animals",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Npgsql:DefaultColumnCollation", "my_collation");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "AnimalBreeds",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Npgsql:DefaultColumnCollation", "my_collation");
        }
    }
}
