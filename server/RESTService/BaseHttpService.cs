using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using RESTService.ResponseModels;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RESTService
{
    /// <summary>
    /// Represents a base HTTP Service to help send request to an API.
    /// If something needs to implement or call out to an API, can derive from this.
    /// </summary>
    public abstract class BaseHttpService
    {
        /// <summary>
        /// Sends out an http Http Request.
        /// </summary>
        /// <typeparam name="TRequestData">The type of data you are sending with the response, if any.</typeparam>
        /// <typeparam name="TResponseData">The type of data you are expecting back from the request.</typeparam>
        /// <param name="uri">The URL to send the request to.</param>
        /// <param name="httpMethod">The HTTP Method used to send the reqest. Will default to GET if null.</param>
        /// <param name="headers">Any headers that you need to send along with the request.</param>
        /// <param name="requestData">The request data that you need to send along with the request.</param>
        /// <returns>A Response object with the response data if successful, or an error object if an error occured.</returns>
        protected virtual async Task<Response<TResponseData>> SendRequestAsync<TRequestData, TResponseData>(Uri uri, HttpMethod httpMethod = null, IDictionary<string, string> headers = null, TRequestData requestData = null) where TRequestData : class
        {
            var method = httpMethod ?? HttpMethod.Get;
            var data = requestData == null ? null : JsonConvert.SerializeObject(requestData);

            using (var request = new HttpRequestMessage(method, uri))
            {
                if(data != null)
                {
                    request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                }

                if(headers != null)
                {
                    foreach(var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                using (var client = new HttpClient())
                {
                    using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead))
                    {
                        return await CreateResponse<TResponseData>(response);
                    }
                }
            }
        }

        /// <summary>
        /// Creates a generic Response based on the response of the HttpResponseMessage.
        /// If the response is successful, will generate a successful response object, otherwise wil generate the error response object.
        /// </summary>
        /// <typeparam name="T">The type of data you are expecting back in the response.</typeparam>
        /// <param name="response">The HttpResponseMessage details.</param>
        /// <returns>A generic Response object.</returns>
        protected async Task<Response<T>> CreateResponse<T>(HttpResponseMessage response)
        {
            if(response.IsSuccessStatusCode)
            {
                return await CreateSuccessResponse<T>(response);
            }
            else
            {
                return CreateErrorResponse<T>(response);
            }
        }

        protected async Task<Response<T>> CreateSuccessResponse<T>(HttpResponseMessage response)
        {
            var responseStringTask = await response.Content.ReadAsStringAsync();
            return new Response<T>
            {
                Success = true,
                Result = JsonConvert.DeserializeObject<T>(responseStringTask)
            };
        }

        protected Response<T> CreateErrorResponse<T>(HttpResponseMessage response)
        {
            return new Response<T>
            {
                Error = new ErrorResponse((int)response.StatusCode, response.ReasonPhrase),
                Success = false
            };
        }
    }
}
