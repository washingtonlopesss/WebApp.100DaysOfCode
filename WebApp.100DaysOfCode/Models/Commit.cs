namespace WebApp._100DaysOfCode.Models;

public class Commit
{
    public string Title { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string RepositoryName { get; set; } = string.Empty;  
    public string Url { get; set; } = string.Empty;
}
