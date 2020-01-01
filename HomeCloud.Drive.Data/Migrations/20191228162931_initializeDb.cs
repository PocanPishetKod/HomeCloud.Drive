using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeCloud.Drive.Data.Migrations
{
    public partial class initializeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DirectoryDescriptors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoryDescriptors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileDescriptors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    DirectoryDescriptorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDescriptors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileDescriptors_DirectoryDescriptors_DirectoryDescriptorId",
                        column: x => x.DirectoryDescriptorId,
                        principalTable: "DirectoryDescriptors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileDescriptors_DirectoryDescriptorId",
                table: "FileDescriptors",
                column: "DirectoryDescriptorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileDescriptors");

            migrationBuilder.DropTable(
                name: "DirectoryDescriptors");
        }
    }
}
