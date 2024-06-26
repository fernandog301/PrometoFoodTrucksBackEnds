﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrometoFoodTrucksBackEnds.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "TruckInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    schedule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TruckInfos_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    itemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodTrucksID = table.Column<int>(type: "int", nullable: false),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodTrucksIteamsModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.itemId);
                    table.ForeignKey(
                        name: "FK_MenuItems_TruckInfos_FoodTrucksIteamsModelID",
                        column: x => x.FoodTrucksIteamsModelID,
                        principalTable: "TruckInfos",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_FoodTrucksIteamsModelID",
                table: "MenuItems",
                column: "FoodTrucksIteamsModelID");

            migrationBuilder.CreateIndex(
                name: "IX_TruckInfos_UserId",
                table: "TruckInfos",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "TruckInfos");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
