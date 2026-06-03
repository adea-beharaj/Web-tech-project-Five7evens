namespace Five7evens.API.Models;

public class Package
{
    public int Id { get; set; }
    public string Value { get; set; } = string.Empty;   // e.g. "paris"
    public string Name { get; set; } = string.Empty;    // e.g. "Paris, France"
    public string Price { get; set; } = string.Empty;   // e.g. "$899"
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string BestTime { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string Highlights { get; set; } = string.Empty;
}
