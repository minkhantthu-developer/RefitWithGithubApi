using Microsoft.Extensions.Options;
using RefitWithGithub.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddOptions<GithubSetting>()
                .BindConfiguration(GithubSetting.ConfigurationSection)
                .ValidateDataAnnotations()
                .ValidateOnStart();

builder.Services.AddHttpClient<GithubService>((sp, httpClient) =>
{
    var githubSetting = sp.GetRequiredService<IOptions<GithubSetting>>().Value;
    httpClient.BaseAddress = new Uri(githubSetting.BaseAddress);
    httpClient.DefaultRequestHeaders.Add("Authorization",githubSetting.AccessToken);
    httpClient.DefaultRequestHeaders.Add("User-Agent", githubSetting.UserAgent);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/users/{userName}",async(string userName,GithubService service) =>
{
    var response=await service.GetByUserNameAsync(userName);
    return Results.Ok(response);
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
