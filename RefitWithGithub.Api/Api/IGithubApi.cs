namespace RefitWithGithub.Api.Api;

public interface IGithubApi
{
    [Get("/users/{userName}")]
    Task<GithubUserDTO> GetByUserNameAsync(string userName);

    [Patch("/user")]
    Task<HttpResponseMessage> UpdateUserBioAsync([Body] UpdateBioRequestDTO requestDTO);
}

public class UpdateBioRequestDTO
{
    public string bio { get; init; }
}
