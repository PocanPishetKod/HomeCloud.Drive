using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeCloud.Drive.Data.Migrations
{
    public partial class addAttr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "FileDescriptors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "FileDescriptors");
        }
    }
}
