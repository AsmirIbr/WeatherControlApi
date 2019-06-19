using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherControlApp.Migrations
{
    public partial class locationfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "WeatherItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherItems_LocationId",
                table: "WeatherItems",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherItems_Location_LocationId",
                table: "WeatherItems",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherItems_Location_LocationId",
                table: "WeatherItems");

            migrationBuilder.DropIndex(
                name: "IX_WeatherItems_LocationId",
                table: "WeatherItems");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "WeatherItems");
        }
    }
}
