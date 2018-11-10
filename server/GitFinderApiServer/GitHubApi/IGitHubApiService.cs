using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitFinderApiServer.GitHubApi.Requests;
using GitFinderApiServer.GitHubApi.Responses;
using RESTService.ResponseModels;

namespace GitFinderApiServer.GitHubApi
{
    public interface IGitHubApiService
    {
        /// <summary>
        /// The base uri of the github api.
        /// </summary>
        Uri BaseUri { get; }

        /// <summary>
        /// Provides publicly available information about someone with a GitHub account.
        /// </summary>
        /// <param name="username">The username of the user you are searching for.</param>
        /// <returns>The public information available.</returns>
        Task<Response<UserResponse>> GetUser(string username);

        /// <summary>
        /// Lists the public repositories availiable for the given username.
        /// </summary>
        Task<Response<List<UserRepoResponse>>> GetUserRepos(string username, ListUsersReposRequests query);
    }
}
