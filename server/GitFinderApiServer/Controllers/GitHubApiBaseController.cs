using Microsoft.AspNetCore.Mvc;
using RESTService.ResponseModels;

namespace GitFinderApiServer.Controllers
{
    public class GitHubApiBaseController : ControllerBase
    {
        /// <summary>
        /// Creates the correct api response based on the error code.
        /// </summary>
        /// <typeparam name="T">The type of response</typeparam>
        /// <param name="response">The response from the github api.</param>
        /// <returns>NotFound response for 404, Ok for 200, BadRequest for anything else.</returns>
        public IActionResult CreateResponse<T>(Response<T> response)
        {
            if (!response.Success)
            {
                if (response.Error.ErrorCode == 404)
                {
                    return NotFound(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }

            return Ok(response);
        }
    }
}
