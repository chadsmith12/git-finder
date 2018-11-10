namespace GitFinderApiServer.GitHubApi.Settings
{
    public class GitHubApiSettings
    {
        /// <summary>
        /// The base url to use for the requests.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// The client id to use for the api requests
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The secret key to use for the api requests.
        /// </summary>
        public string SecretKey { get; set; }
    }
}
