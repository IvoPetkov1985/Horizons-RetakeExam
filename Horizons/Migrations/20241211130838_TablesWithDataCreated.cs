using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Horizons.Migrations
{
    /// <inheritdoc />
    public partial class TablesWithDataCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Terrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Terrain identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Terrain type name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terrains", x => x.Id);
                },
                comment: "Terrain of the destination");

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Destination identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "Destination name"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Detailed information about the destination"),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Link to a photo from the place"),
                    PublisherId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    PublishedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "When the ad was published on the platform"),
                    TerrainId = table.Column<int>(type: "int", nullable: false, comment: "Terrain identifier"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Is the ad outdated, set as inactive")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destinations_AspNetUsers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Destinations_Terrains_TerrainId",
                        column: x => x.TerrainId,
                        principalTable: "Terrains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Bulgarian destination");

            migrationBuilder.CreateTable(
                name: "UsersDestinations",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    DestinationId = table.Column<int>(type: "int", nullable: false, comment: "Destination identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDestinations", x => new { x.UserId, x.DestinationId });
                    table.ForeignKey(
                        name: "FK_UsersDestinations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersDestinations_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "The relational table between users and marked destinations as favorite");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7699db7d-964f-4782-8209-d76562e0fece", 0, "d79d5357-dc24-4922-a46a-1cd7dcf4af5e", "admin@horizons.com", true, false, null, "ADMIN@HORIZONS.COM", "ADMIN@HORIZONS.COM", "AQAAAAIAAYagAAAAEDAEpgw/l/PMbImqgNpF1IKm1qDay+1z9rjcawYLtNzNiDZlpKE0biS700m6qCMrdA==", null, false, "fc8bcbc5-bfd9-4f57-b0db-fe5b5dd26b6b", false, "admin@horizons.com" });

            migrationBuilder.InsertData(
                table: "Terrains",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mountain" },
                    { 2, "Beach" },
                    { 3, "Forest" },
                    { 4, "Plain" },
                    { 5, "Urban" },
                    { 6, "Village" },
                    { 7, "Cave" },
                    { 8, "Canyon" }
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "Description", "ImageUrl", "IsDeleted", "Name", "PublishedOn", "PublisherId", "TerrainId" },
                values: new object[,]
                {
                    { 1, "A stunning historical landmark nestled in the Rila Mountains.", "https://img.etimg.com/thumb/msid-112831459,width-640,height-480,imgsize-2180890,resizemode-4/rila-monastery-bulgaria.jpg", false, "Rila Monastery", new DateTime(2024, 12, 11, 15, 8, 37, 264, DateTimeKind.Local).AddTicks(2590), "7699db7d-964f-4782-8209-d76562e0fece", 1 },
                    { 2, "The sand at Durankulak Beach showcases a pristine golden color, creating a beautiful contrast against the azure waters of the Black Sea.", "https://travelplanner.ro/blog/wp-content/uploads/2023/01/durankulak-beach-1-850x550.jpg.webp", false, "Durankulak Beach", new DateTime(2024, 12, 11, 15, 8, 37, 264, DateTimeKind.Local).AddTicks(2678), "7699db7d-964f-4782-8209-d76562e0fece", 2 },
                    { 3, "A mysterious cave located in the Rhodope Mountains.", "https://detskotobnr.binar.bg/wp-content/uploads/2017/11/Diavolsko_garlo_17.jpg", false, "Devil's Throat Cave", new DateTime(2024, 12, 11, 15, 8, 37, 264, DateTimeKind.Local).AddTicks(2693), "7699db7d-964f-4782-8209-d76562e0fece", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_PublisherId",
                table: "Destinations",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_TerrainId",
                table: "Destinations",
                column: "TerrainId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDestinations_DestinationId",
                table: "UsersDestinations",
                column: "DestinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersDestinations");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "Terrains");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece");
        }
    }
}
