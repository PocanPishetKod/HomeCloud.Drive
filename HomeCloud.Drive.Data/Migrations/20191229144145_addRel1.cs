using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeCloud.Drive.Data.Migrations
{
    public partial class addRel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentDirectoryDescryptorId",
                table: "DirectoryDescriptors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DirectoryDescriptors_ParentDirectoryDescryptorId",
                table: "DirectoryDescriptors",
                column: "ParentDirectoryDescryptorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectoryDescriptors_DirectoryDescriptors_ParentDirectoryDescryptorId",
                table: "DirectoryDescriptors",
                column: "ParentDirectoryDescryptorId",
                principalTable: "DirectoryDescriptors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectoryDescriptors_DirectoryDescriptors_ParentDirectoryDescryptorId",
                table: "DirectoryDescriptors");

            migrationBuilder.DropIndex(
                name: "IX_DirectoryDescriptors_ParentDirectoryDescryptorId",
                table: "DirectoryDescriptors");

            migrationBuilder.DropColumn(
                name: "ParentDirectoryDescryptorId",
                table: "DirectoryDescriptors");
        }
    }
}
