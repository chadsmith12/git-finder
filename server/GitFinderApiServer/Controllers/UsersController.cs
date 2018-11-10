using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GitFinderApiServer.GitHubApi;
using GitFinderApiServer.GitHubApi.Requests;


namespace GitFinderApiServer.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : GitHubApiBaseController
    {
        private readonly IGitHubApiService _apiService;

        public UsersController(IGitHubApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            var response = await _apiService.GetUser(username);
            return CreateResponse(response);
        }

        [HttpGet("{username}/repos")]
        public async Task<IActionResult> GetUserRepos([FromRoute]string username, [FromQuery] ListUsersReposRequests query)
        {
            var response = await _apiService.GetUserRepos(username, query);
            return CreateResponse(response);
        }
    }
}
