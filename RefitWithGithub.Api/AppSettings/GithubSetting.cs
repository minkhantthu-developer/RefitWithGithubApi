namespace RefitWithGithub.Api.AppSettings;

public sealed class GithubSetting
{
    public const string ConfigurationSection = "Github";

    [Required, Url]
    public string BaseAddress { get; init; } = string.Empty;

    [Required]
    public string AccessToken { get; init; } = string.Empty;

    [Required]
    public string UserAgent { get; init; } = string.Empty;
}
