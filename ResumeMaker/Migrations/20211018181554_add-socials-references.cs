using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeMaker.Migrations
{
    public partial class addsocialsreferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "ResumeInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GitHub",
                table: "ResumeInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "ResumeInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "ResumeInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "ResumeInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "ResumeInfos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "ResumeInfos");

            migrationBuilder.DropColumn(
                name: "GitHub",
                table: "ResumeInfos");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "ResumeInfos");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "ResumeInfos");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "ResumeInfos");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "ResumeInfos");
        }
    }
}
