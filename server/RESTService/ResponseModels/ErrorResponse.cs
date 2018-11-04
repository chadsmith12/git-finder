using System;
using System.Collections.Generic;
using System.Text;

namespace RESTService.ResponseModels
{
    /// <summary>
    /// Represents the error details of a request.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Creates an empty ErrorResponse.
        /// </summary>
        public ErrorResponse()
        {

        }

        /// <summary>
        /// Creates a new error response with the specific code and error message.
        /// </summary>
        /// <param name="errorCode">The error/http status code.</param>
        /// <param name="errorMessage">The error message.</param>
        public ErrorResponse(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// The http status error code of the response.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// The error message from the response.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
