using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Flag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    //table.UniqueConstraint();
                }
            );

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Type_id = table.Column<byte>(type: "tinyint", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "CountriesUser",
                columns: table =>
                    new
                    {
                        CountriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesUser", x => new { x.CountriesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CountriesUser_Country_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_CountriesUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_CountriesUser_UsersId",
                table: "CountriesUser",
                column: "UsersId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "CountriesUser");

            migrationBuilder.DropTable(name: "Country");

            migrationBuilder.DropTable(name: "Users");
        }
    }
}
