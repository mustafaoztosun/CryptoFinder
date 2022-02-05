using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoFinder.DataAccess.Migrations
{
    public partial class initialCreate : Migration
    {
        //Add-migration initialCreate was uploaded via console and 
        //the table was added.
        //I was on console "update-database" for create new table in SqlServer 
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cryptos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                    //will increase 1+1
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cryptos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cryptos");
        }
    }
}
