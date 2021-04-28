using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIStuff.Migrations
{
    public partial class APIStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionHeroes",
                columns: table => new
                {
                    ActionHeroesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    epicMovies = table.Column<int>(nullable: false),
                    heroName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionHeroes", x => x.ActionHeroesID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionHeroes");
        }
    }
}
