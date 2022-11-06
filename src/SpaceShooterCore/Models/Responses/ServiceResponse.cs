﻿using System.Net;

namespace SpaceShooterCore
{
    public class ServiceResponse
    {
        public string RequestUri { get; set; } = string.Empty;

        public string ExternalError { get; set; } = string.Empty;

        public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.OK;

        public object Result { get; set; } = new object();

        public ServiceResponse BuildSuccessResponse(object result, string requestUri = "")
        {
            return new ServiceResponse() { HttpStatusCode = HttpStatusCode.OK, Result = result, RequestUri = requestUri };
        }

        public ServiceResponse BuildErrorResponse(string error, string requestUri = "")
        {
            return new ServiceResponse() { HttpStatusCode = HttpStatusCode.InternalServerError, ExternalError = error, RequestUri = requestUri };
        }
    }

    public static class Response
    {
        public static ServiceResponse Build()
        {
            return new ServiceResponse();
        }
    }
}
