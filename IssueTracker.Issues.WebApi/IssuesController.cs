namespace IssueTracker.Issues.WebApi
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using IssueTracker.Framework.WebApi;
	using IssueTracker.Issues.Domain.Issue;
	using IssueTracker.Issues.Handlers.Queries;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;

	[Route("issues")]
	public class IssuesController : CoreApiController
	{
		private readonly IMediator _mediator;

		public IssuesController(IMediator mediator, ILoggerFactory loggerFactory)
		{
			_mediator = mediator;
		}

		[HttpGet("")]
		[ProducesResponseType(typeof(List<Issue>), 200)]
		[ProducesResponseType(typeof(List<ErrorDto>),400)]
		public async Task<List<Issue>> GetAllIssues()
		{
			var result = await _mediator.Send(new GetIssuesQuery());
			return result;
		}

		[HttpGet("search")]
		[ProducesResponseType(typeof(List<Issue>), 200)]
		[ProducesResponseType(typeof(List<ErrorDto>),400)]
		public async Task<List<Issue>> SearchIssues([FromQuery] string text)
		{
			var result = await _mediator.Send(new GetIssuesQuery());
			return result;
		}
	}
}