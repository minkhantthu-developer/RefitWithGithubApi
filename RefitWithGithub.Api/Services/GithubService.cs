namespace RefitWithGithub.Api.Services;

public sealed class GithubService(HttpClient _httpClient)
{
    public async Task<GithubUserDTO?> GetByUserNameAsync(string userName)
    {
        var user = await _httpClient.GetFromJsonAsync<GithubUserDTO>($"users/{userName}");
        return user;
    }
}
