using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeCloud.Drive.Data.Migrations
{
    public partial class setNullableAttr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileDescriptors_DirectoryDescriptors_DirectoryDescriptorId",
                table: "FileDescriptors");

            migrationBuilder.AlterColumn<int>(
                name: "DirectoryDescriptorId",
                table: "FileDescriptors",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FileDescriptors_DirectoryDescriptors_DirectoryDescriptorId",
                table: "FileDescriptors",
                column: "DirectoryDescriptorId",
                principalTable: "DirectoryDescriptors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileDescriptors_DirectoryDescriptors_DirectoryDescriptorId",
                table: "FileDescriptors");

            migrationBuilder.AlterColumn<int>(
                name: "DirectoryDescriptorId",
                table: "FileDescriptors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FileDescriptors_DirectoryDescriptors_DirectoryDescriptorId",
                table: "FileDescriptors",
                column: "DirectoryDescriptorId",
                principalTable: "DirectoryDescriptors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
