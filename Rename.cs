private static async Task Rename()
{
  var apiClient = new GitHubClient(new Octokit.ProductHeaderValue("Issue-Managment")) /* Put credentials here */;
  var repoName = $"test-{DateTime.UtcNow.ToBinary()}";
  var repo = await apiClient.Repository.Create(new NewRepository(repoName));
  Console.WriteLine($"Created repo {repo.Name} under {repo.Owner.Login}");

  repo = await apiClient.Repository.Edit(repo.Owner.Login, repo.Name, new RepositoryUpdate { Name = $"{repo.Name} ll {repo.Name}" });
  Console.WriteLine($"Repo renamed to {repo.Name}");

  await apiClient.Repository.Delete(repo.Owner.Login, repo.Name);
  Console.WriteLine("Repository deleted");
}