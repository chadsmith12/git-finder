using System;
using Microsoft.Extensions.Configuration;
using GitFinderApiServer.GitHubApi.Settings;

namespace GitFinderApiServer.GitHubApi.Configuration
{
    /// <summary>
    /// Represents the api configuration to use for the GitHub api.
    /// </summary>
    public static class GitHubApiConfiguration
    {
        private const string GitHubApiSection = "GitHubApi";

        /// <summary>
        /// Gets the current api settings being used.
        /// </summary>
        public static GitHubApiSettings ApiSettings { get; private set; }

        /// <summary>
        /// Configures and sets the api settings for github.
        /// </summary>
        /// <param name="configSettings">The action to run to set the settings for the api.</param>
        public static void Configure(Action<GitHubApiSettings> configSettings)
        {
            ApiSettings = new GitHubApiSettings();

            configSettings(ApiSettings);
        }

        /// <summary>
        /// Extension method to get the github api settings from the "GitHubApi" section in the appsettings.
        /// </summary>
        /// <param name="configuration">The IConfiguration.</param>
        /// <returns>The configuration section found in the appsettings.</returns>
        public static IConfigurationSection GetGitHubApiSettings(this IConfiguration configuration)
        {
            var settings = configuration.GetSection(GitHubApiSection);
            var apiSettings = settings.Get<GitHubApiSettings>();

            Configure(cfg =>
            {
                cfg.ClientId = apiSettings.ClientId;
                cfg.SecretKey = apiSettings.SecretKey;
                cfg.BaseUrl = apiSettings.BaseUrl;
            });
            return settings;
        }
    }
}
