using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vm.persistence.Migrations
{
    public partial class vmServicesMac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_VmMedata_ProfileMetadataId",
                table: "Profile");

            migrationBuilder.DropTable(
                name: "VmMedata");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_ProfileMetadataId",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "ProfileMetadataId",
                table: "Profile");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "Profiles");

            migrationBuilder.AddColumn<Guid>(
                name: "MetadataId",
                table: "Profiles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProfileMetadatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileMetadatas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_MetadataId",
                table: "Profiles",
                column: "MetadataId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ProfileMetadatas_MetadataId",
                table: "Profiles",
                column: "MetadataId",
                principalTable: "ProfileMetadatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_ProfileMetadatas_MetadataId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "ProfileMetadatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_MetadataId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "MetadataId",
                table: "Profiles");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "Profile");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileMetadataId",
                table: "Profile",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "VmMedata",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VmMedata", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profile_ProfileMetadataId",
                table: "Profile",
                column: "ProfileMetadataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_VmMedata_ProfileMetadataId",
                table: "Profile",
                column: "ProfileMetadataId",
                principalTable: "VmMedata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
