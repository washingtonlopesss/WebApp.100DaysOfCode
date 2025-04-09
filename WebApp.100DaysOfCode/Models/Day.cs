namespace WebApp._100DaysOfCode.Models;

public class Day
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Summary { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public List<Tag> Tags { get; set; } = new List<Tag>();
}
