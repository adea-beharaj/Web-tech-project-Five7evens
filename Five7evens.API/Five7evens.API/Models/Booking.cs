namespace Five7evens.API.Models;

public class Booking
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public int Guests { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
