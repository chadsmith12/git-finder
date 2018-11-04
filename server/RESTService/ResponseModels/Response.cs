namespace RESTService.ResponseModels
{
    /// <summary>
    /// Represents a generic API Response.
    /// This can be used to store an HTTP Response.
    /// Gives information on the message, successful or not, and the actual result the request returned, if any.
    /// </summary>
    /// <typeparam name="T">The type you expect the result to be from the request.</typeparam>
    public class Response<T>
    {
        /// <summary>
        /// Represents the error object in a response, if there was an error.
        /// Will give details of the HTTP Status Code of the error, and the error message.
        /// </summary>
        public ErrorResponse Error { get; set; }

        /// <summary>
        /// If the request was successful or not.
        /// Will be true if successful; otherwise, <c>false.</c>
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Represents the actual result, if any, returned from the request.
        /// </summary>
        public T Result { get; set; }
    }
}
