using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebStore.Infrastructure
{
    public class TokenMiddleware
    {
        readonly string  correctToken = "qwerty123";

        public RequestDelegate Next { get; }

        public TokenMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["referenceToken"];

            if (string.IsNullOrEmpty(token))
            {
                await Next.Invoke(context);
            }

            if (token == correctToken)
            {
                await Next.Invoke(context);
            }
            else
            {
                await context.Response.WriteAsync("Token is incorrect");
            }

        }
    }
}
