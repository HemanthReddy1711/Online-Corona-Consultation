using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Consultation.Migrations
{
    public partial class firs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mdesc",
                table: "billings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mdesc",
                table: "billings");
        }
    }
}
