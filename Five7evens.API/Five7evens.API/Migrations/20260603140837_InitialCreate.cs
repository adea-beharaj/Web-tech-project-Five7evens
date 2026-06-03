using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Five7evens.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Destination = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    Guests = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    BestTime = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<string>(type: "text", nullable: false),
                    Highlights = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "BestTime", "Description", "Duration", "Highlights", "ImageUrl", "Name", "Price", "Value" },
                values: new object[,]
                {
                    { 1, "April - June, September - October", "Experience the romantic charm of Paris, known as the City of Light. Walk through historic streets, admire world-famous art, and enjoy breathtaking views from iconic landmarks.", "6 Hours", "Eiffel Tower, Louvre Museum, Seine River Cruise", "https://i.pinimg.com/1200x/98/51/0a/98510a0c6013f5913fac4b6d6c3aac12.jpg", "Paris, France", "$899", "paris" },
                    { 2, "May - September", "Discover the tropical paradise of Bali, famous for its stunning beaches, lush landscapes, and rich cultural heritage.", "5 Hours", "Beaches, Ubud Rice Terraces, Temples", "https://i.pinimg.com/736x/be/b8/09/beb8091eccec3bbbf2d4a9f0e722722b.jpg", "Bali, Indonesia", "$699", "bali" },
                    { 3, "April - June, September - November", "Explore the vibrant energy of New York City, where culture, entertainment, and iconic sights come together.", "7 Hours", "Statue of Liberty, Times Square, Central Park", "https://i.pinimg.com/736x/92/a1/a5/92a1a5bea064b5c48cc8b5bdee84de7b.jpg", "New York, USA", "$799", "nyc" },
                    { 4, "March - May, October - November", "Immerse yourself in Tokyo's unique blend of tradition and modern innovation.", "6 Hours", "Shibuya Crossing, Tokyo Tower, Sushi Experience", "https://i.pinimg.com/1200x/4a/0d/36/4a0d3638b7b0091d65a9c37fbb67f78e.jpg", "Tokyo, Japan", "$1099", "tokyo" },
                    { 5, "April - June, September - October", "Step back in time in Rome, a city filled with ancient history and stunning architecture.", "5 Hours", "Colosseum, Vatican City, Trevi Fountain", "https://i.pinimg.com/1200x/12/2b/26/122b26e0eae55ae80c5d076fef34576b.jpg", "Rome, Italy", "$849", "rome" },
                    { 6, "November - March", "Experience luxury and innovation in Dubai, a city of futuristic skyscrapers and desert adventures.", "6 Hours", "Burj Khalifa, Desert Safari, Dubai Mall", "https://i.pinimg.com/1200x/c2/c0/bb/c2c0bbc20e505f676efae924279029bb.jpg", "Dubai, UAE", "$999", "dubai" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Packages");
        }
    }
}
