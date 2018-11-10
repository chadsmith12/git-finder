using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using GitFinderApiServer.GitHubApi.Responses;
using GitFinderApiServer.GitHubApi.Configuration;
using RESTService;
using RESTService.ResponseModels;
using GitFinderApiServer.GitHubApi.Requests;

namespace GitFinderApiServer.GitHubApi
{
    public class GitHubApiService : BaseHttpService, IGitHubApiService
    {
        private static readonly Dictionary<string, string> HEADERS = new Dictionary<string, string> { { "User-Agent", "GitFinder" }, { "Accept", "application/vnd.github.v3+json" } };
        public Uri BaseUri => new Uri(GitHubApiConfiguration.ApiSettings.BaseUrl);

        public async Task<Response<UserResponse>> GetUser(string username)
        {
            var baseUri = $"{BaseUri}{string.Format(GitHubEndPoints.Users, username)}";
            var fullUri = new Uri(BuildOAuthUrl(baseUri));

            var response = await SendRequestAsync<UserResponse, UserResponse>(fullUri, headers: HEADERS);

            return response;
        }

        public async Task<Response<List<UserRepoResponse>>> GetUserRepos(string username, ListUsersReposRequests query)
        {
            var baseUri = $"{BaseUri}{string.Format(GitHubEndPoints.UserRepos, username)}";
            var oauthUri = BuildOAuthUrl(baseUri);
            var fullUri = QueryHelpers.AddQueryString(oauthUri, GetUserReposQuery(query));
            var response = await SendRequestAsync<List<UserRepoResponse>, List<UserRepoResponse>>(new Uri(fullUri), headers: HEADERS);


            return response;
        }

        private string BuildOAuthUrl(string baseUrl)
        {
            var url = QueryHelpers.AddQueryString(baseUrl, "client_id", GitHubApiConfiguration.ApiSettings.ClientId);
            return QueryHelpers.AddQueryString(url, "client_secret", GitHubApiConfiguration.ApiSettings.SecretKey);
        }

        private Dictionary<string, string> GetUserReposQuery(ListUsersReposRequests query)
        {
            var direction = query.Direction.ToString().ToLower();
            var type = query.Type.ToString().ToLower();
            var sort = query.Sort == RepoSortColumn.FullName ? "full_name" : query.Sort.ToString().ToLower();

            return new Dictionary<string, string>
            {
                {"type", type },
                {"direction", direction },
                {"sort", sort },
                {"per_page", query.PerPage.ToString() }
            };
        }
    }
}
