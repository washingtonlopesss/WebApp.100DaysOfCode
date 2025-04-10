using System.Net.Http.Headers;
using System.Text.Json;
using WebApp._100DaysOfCode.Models;

namespace WebApp._100DaysOfCode.Services;

public class GitHubAPI
{
    private readonly string _username = "lopes0x";

    public List<Commit> SearchLatestCommits()
    {
        HttpClient _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("DotNetApp", "1.0"));

        var reposResponse = _httpClient.GetAsync($"https://api.github.com/users/{_username}/repos?per_page=100").Result;
        var reposJson = reposResponse.Content.ReadAsStringAsync().Result;
        var repos = JsonSerializer.Deserialize<List<Repo>>(reposJson);

        if (repos == null) return [];

        var commitsFinal = new List<Commit>();

        foreach (var repo in repos)
        {
            var commitsResponse = _httpClient.GetAsync(
                $"https://api.github.com/repos/{repo.owner.login}/{repo.name}/commits?author={_username}&per_page=10"
            ).Result;

            if (!commitsResponse.IsSuccessStatusCode) continue;

            var commitsJson = commitsResponse.Content.ReadAsStringAsync().Result;
            var commits = JsonSerializer.Deserialize<List<CommitResponse>>(commitsJson);

            if (commits == null) continue;

            foreach (var c in commits)
            {
                commitsFinal.Add(new Commit
                {
                    Title = c.commit.message,
                    Data = DateTime.Parse(c.commit.author.date),
                    RepositoryName = repo.name,
                    Url = c.html_url
                });
            }

            if (commitsFinal.Count >= 15) break;
        }

        return commitsFinal.OrderByDescending(c => c.Data).Take(15).ToList();
    }


    private class Repo
    {
        public string name { get; set; }
        public Owner owner { get; set; }
    }

    private class Owner
    {
        public string login { get; set; }
    }

    private class CommitResponse
    {
        public string html_url { get; set; }
        public CommitInfo commit { get; set; }
    }

    private class CommitInfo
    {
        public CommitAuthor author { get; set; }
        public string message { get; set; }
    }

    private class CommitAuthor
    {
        public string date { get; set; }
    }
}
