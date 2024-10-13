var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddOptions<GithubSetting>()
                .BindConfiguration(GithubSetting.ConfigurationSection)
                .ValidateDataAnnotations()
                .ValidateOnStart();

builder.Services.AddTransient<GithubAuthenticationHandler>();

builder.Services.AddHttpClient<GithubService>((sp, httpClient) =>
{
    var githubSetting = sp.GetRequiredService<IOptions<GithubSetting>>().Value;
    httpClient.BaseAddress = new Uri(githubSetting.BaseAddress);
})
    .AddHttpMessageHandler<GithubAuthenticationHandler>();

builder.Services.AddRefitClient<IGithubApi>()
                .ConfigureHttpClient((sp, httpClient) =>
                {
                    var githubSetting = sp.GetRequiredService<IOptions<GithubSetting>>().Value;
                    httpClient.BaseAddress = new Uri(githubSetting.BaseAddress);
                }).AddHttpMessageHandler<GithubAuthenticationHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddUserService();

app.Run();