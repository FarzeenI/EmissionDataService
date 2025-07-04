﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using EmissionDataRecordService.Exceptions;

namespace EmissionDataRecordService.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                var statusCode = HttpStatusCode.InternalServerError;

                if (ex is EmissionNotFoundException)
                    statusCode = HttpStatusCode.NotFound;
                else if (ex is EmissionValidationException || ex is ArgumentException || ex is ArgumentNullException)
                    statusCode = HttpStatusCode.BadRequest;

                var response = new
                {
                    error = ex.Message,
                    status = (int)statusCode
                };

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)statusCode;
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
