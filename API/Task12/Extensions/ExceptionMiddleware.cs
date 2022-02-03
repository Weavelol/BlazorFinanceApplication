﻿using Core.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task12.Extensions {
    public class ExceptionMiddleware {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext) {
            try {
                await _next(httpContext);
            }
            catch (Exception ex) {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception) {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch {
                EntityNotFoundException => HttpStatusCode.NotFound,
                AbstractBadRequestException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(new ErrorDetails() {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }

        private class ErrorDetails {
            public int StatusCode { get; set; }
            public string Message { get; set; }
            public override string ToString() {
                return JsonSerializer.Serialize(this);
            }
        }
    }
}
