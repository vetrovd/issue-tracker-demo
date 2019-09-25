namespace IssueTracker.Contexts.Core.WebApi.Middleware.Exceptions
{
	using System;
	using System.Linq;
	using System.Threading.Tasks;
	using IssueTracker.Contexts.Core.Exceptions;
	using Microsoft.AspNetCore.Http;
	using Microsoft.Extensions.Logging;
	using Newtonsoft.Json;

	public class HttpStatusCodeExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<HttpStatusCodeExceptionMiddleware> _logger;

		public HttpStatusCodeExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
		{
			_next = next ?? throw new ArgumentNullException(nameof(next));
			_logger = loggerFactory?.CreateLogger<HttpStatusCodeExceptionMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (DomainException ex)
			{
				if (context.Response.HasStarted)
				{
					_logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
					throw;
				}

				int statusCode;
				string message;

				if (ex is InvalidRequestException)
				{
					statusCode = 422;
					var errors = (ex as InvalidRequestException).Errors
						.Select(
							error => new ErrorDto() {Name = error.PropertyName, Reason = error.ErrorMessage}
						); 

					message = JsonConvert.SerializeObject(errors);
				}
				else
				{
					statusCode = 500;
					message = string.Empty;
				}

				context.Response.Clear();

				context.Response.StatusCode = statusCode;
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(message);

				return;
			}
		}
	}
}