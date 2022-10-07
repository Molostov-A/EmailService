using Microsoft.EntityFrameworkCore.Migrations;

namespace EmailService.Db.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Signed",
                table: "MailsItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Signed",
                table: "MailsItems");
        }
    }
}
