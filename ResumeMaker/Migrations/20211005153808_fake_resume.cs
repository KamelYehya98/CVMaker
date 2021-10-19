using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeMaker.Migrations
{
    public partial class fake_resume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnRegisteredResumes",
                columns: table => new
                {
                    UnregisteredID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnRegisteredResumes", x => x.UnregisteredID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnRegisteredResumes");
        }
    }
}
