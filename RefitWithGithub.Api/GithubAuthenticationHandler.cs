using Microsoft.Extensions.Options;
using System.Net.Http;

namespace RefitWithGithub.Api
{
    public class GithubAuthenticationHandler:DelegatingHandler
    {
        private readonly GithubSetting _githubSetting;

        public GithubAuthenticationHandler(IOptions<GithubSetting> options)
        {
            _githubSetting = options.Value;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken
            )
        {
            request.Headers.Add("Authorization", _githubSetting.AccessToken);
            request.Headers.Add("User-Agent", _githubSetting.UserAgent);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
