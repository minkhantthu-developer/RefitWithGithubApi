namespace RefitWithGithub.Api.Features.User;

public static class UserService
{
    public static void AddUserService(this IEndpointRouteBuilder app)
    {
        app.MapGet("/users/{userName}", async (string userName, IGithubApi service) =>
        {
            var response = await service.GetByUserNameAsync(userName);
            return Results.Ok(response);
        });

        app.MapPatch("/user/bio", async (UpdateBioRequestDTO requestDTO, IGithubApi githubApi) =>
        {
            var response = await githubApi.UpdateUserBioAsync(requestDTO);
            response.EnsureSuccessStatusCode();
            return Results.NoContent();
        });
    }
}
