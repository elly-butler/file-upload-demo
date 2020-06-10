using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexul.Demo.SqlDbServices.Migrations.NexulDemoDb
{
    public partial class InitialDemo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FileId = table.Column<Guid>(nullable: false),
                    FileBlob = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.FileId);
                });

            migrationBuilder.CreateTable(
                name: "FileImageAlternate",
                columns: table => new
                {
                    FileImageAlternateId = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: false),
                    FileBlob = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileImageAlternate", x => x.FileImageAlternateId);
                });

            migrationBuilder.CreateTable(
                name: "FileMetadata",
                columns: table => new
                {
                    FileId = table.Column<Guid>(nullable: false),
                    Size = table.Column<long>(nullable: false),
                    Extension = table.Column<string>(maxLength: 25, nullable: true),
                    ContentType = table.Column<string>(maxLength: 225, nullable: true),
                    Audit_CreatedDate = table.Column<DateTime>(nullable: true),
                    Audit_CreatedUserId = table.Column<string>(maxLength: 40, nullable: true),
                    Audit_CreatedUserName = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMetadata", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_FileMetadata_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileImageAlternateMetadata",
                columns: table => new
                {
                    FileImageAlternateId = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Size = table.Column<long>(nullable: false),
                    Extension = table.Column<string>(maxLength: 25, nullable: true),
                    ContentType = table.Column<string>(maxLength: 225, nullable: true),
                    Audit_CreatedDate = table.Column<DateTime>(nullable: true),
                    Audit_CreatedUserId = table.Column<string>(maxLength: 40, nullable: true),
                    Audit_CreatedUserName = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileImageAlternateMetadata", x => x.FileImageAlternateId);
                    table.ForeignKey(
                        name: "FK_FileImageAlternateMetadata_FileImageAlternate_FileImageAlternateId",
                        column: x => x.FileImageAlternateId,
                        principalTable: "FileImageAlternate",
                        principalColumn: "FileImageAlternateId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileImageAlternateMetadata");

            migrationBuilder.DropTable(
                name: "FileMetadata");

            migrationBuilder.DropTable(
                name: "FileImageAlternate");

            migrationBuilder.DropTable(
                name: "File");
        }
    }
}
