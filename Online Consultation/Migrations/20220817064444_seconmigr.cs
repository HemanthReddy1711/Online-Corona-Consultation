using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Consultation.Migrations
{
    public partial class seconmigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "did",
                table: "feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_did",
                table: "feedbacks",
                column: "did");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_doctorsProfiles_did",
                table: "feedbacks",
                column: "did",
                principalTable: "doctorsProfiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_doctorsProfiles_did",
                table: "feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_feedbacks_did",
                table: "feedbacks");

            migrationBuilder.DropColumn(
                name: "did",
                table: "feedbacks");
        }
    }
}
