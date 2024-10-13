using Refit;

namespace RefitWithGithub.Api
{
    public interface IGithubApi
    {
        [Get("/users/{userName}")]
        Task<GithubUserDTO> GetByUserNameAsync(string userName);
    }
}
