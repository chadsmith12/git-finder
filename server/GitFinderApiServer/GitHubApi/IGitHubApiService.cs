using System.Threading.Tasks;
using GitFinderApiServer.GitHubApi.Responses;

namespace GitFinderApiServer.GitHubApi
{
    public interface IGitHubApiService
    {
        /// <summary>
        /// Provides publicly available information about someone with a GitHub account.
        /// </summary>
        /// <param name="username">The username of the user you are searching for.</param>
        /// <returns>The public information available.</returns>
        Task<UserResponse> GetUser(string username);
    }
}
