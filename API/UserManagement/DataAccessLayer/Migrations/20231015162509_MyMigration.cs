using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountriesUser_Country_CountriesId",
                table: "CountriesUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CountriesUser_Users_UsersId",
                table: "CountriesUser");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "CountriesUser",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "CountriesId",
                table: "CountriesUser",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CountriesUser_UsersId",
                table: "CountriesUser",
                newName: "IX_CountriesUser_CountryId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Country",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_Code",
                table: "Country",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_Name",
                table: "Country",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CountriesUser_Country_CountryId",
                table: "CountriesUser",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountriesUser_Users_UserId",
                table: "CountriesUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountriesUser_Country_CountryId",
                table: "CountriesUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CountriesUser_Users_UserId",
                table: "CountriesUser");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Country_Code",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_Name",
                table: "Country");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "CountriesUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CountriesUser",
                newName: "CountriesId");

            migrationBuilder.RenameIndex(
                name: "IX_CountriesUser_CountryId",
                table: "CountriesUser",
                newName: "IX_CountriesUser_UsersId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Country",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_CountriesUser_Country_CountriesId",
                table: "CountriesUser",
                column: "CountriesId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountriesUser_Users_UsersId",
                table: "CountriesUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
