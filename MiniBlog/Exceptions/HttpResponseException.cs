using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MiniBlog.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }

        public HttpResponseException(HttpStatusCode statusCode, string errorMessage = "")
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    }
}
