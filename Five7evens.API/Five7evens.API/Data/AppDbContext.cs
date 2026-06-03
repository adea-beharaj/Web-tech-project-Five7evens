using Microsoft.EntityFrameworkCore;
using Five7evens.API.Models;

namespace Five7evens.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Package> Packages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed travel packages
        modelBuilder.Entity<Package>().HasData(
            new Package { Id = 1, Value = "paris",  Name = "Paris, France",       Price = "$899",  Duration = "6 Hours",  BestTime = "April - June, September - October", Highlights = "Eiffel Tower, Louvre Museum, Seine River Cruise",    ImageUrl = "https://i.pinimg.com/1200x/98/51/0a/98510a0c6013f5913fac4b6d6c3aac12.jpg", Description = "Experience the romantic charm of Paris, known as the City of Light. Walk through historic streets, admire world-famous art, and enjoy breathtaking views from iconic landmarks." },
            new Package { Id = 2, Value = "bali",   Name = "Bali, Indonesia",     Price = "$699",  Duration = "5 Hours",  BestTime = "May - September",                  Highlights = "Beaches, Ubud Rice Terraces, Temples",                 ImageUrl = "https://i.pinimg.com/736x/be/b8/09/beb8091eccec3bbbf2d4a9f0e722722b.jpg", Description = "Discover the tropical paradise of Bali, famous for its stunning beaches, lush landscapes, and rich cultural heritage." },
            new Package { Id = 3, Value = "nyc",    Name = "New York, USA",       Price = "$799",  Duration = "7 Hours",  BestTime = "April - June, September - November",Highlights = "Statue of Liberty, Times Square, Central Park",         ImageUrl = "https://i.pinimg.com/736x/92/a1/a5/92a1a5bea064b5c48cc8b5bdee84de7b.jpg", Description = "Explore the vibrant energy of New York City, where culture, entertainment, and iconic sights come together." },
            new Package { Id = 4, Value = "tokyo",  Name = "Tokyo, Japan",        Price = "$1099", Duration = "6 Hours",  BestTime = "March - May, October - November",   Highlights = "Shibuya Crossing, Tokyo Tower, Sushi Experience",       ImageUrl = "https://i.pinimg.com/1200x/4a/0d/36/4a0d3638b7b0091d65a9c37fbb67f78e.jpg", Description = "Immerse yourself in Tokyo's unique blend of tradition and modern innovation." },
            new Package { Id = 5, Value = "rome",   Name = "Rome, Italy",         Price = "$849",  Duration = "5 Hours",  BestTime = "April - June, September - October", Highlights = "Colosseum, Vatican City, Trevi Fountain",               ImageUrl = "https://i.pinimg.com/1200x/12/2b/26/122b26e0eae55ae80c5d076fef34576b.jpg", Description = "Step back in time in Rome, a city filled with ancient history and stunning architecture." },
            new Package { Id = 6, Value = "dubai",  Name = "Dubai, UAE",          Price = "$999",  Duration = "6 Hours",  BestTime = "November - March",                  Highlights = "Burj Khalifa, Desert Safari, Dubai Mall",              ImageUrl = "https://i.pinimg.com/1200x/c2/c0/bb/c2c0bbc20e505f676efae924279029bb.jpg", Description = "Experience luxury and innovation in Dubai, a city of futuristic skyscrapers and desert adventures." }
        );
    }
}
