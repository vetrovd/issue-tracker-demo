namespace IssueTracker.Issues.WebApi
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using IssueTracker.Framework.WebApi;
	using IssueTracker.Issues.Domain.Issue;
	using IssueTracker.Issues.Handlers.Commands;
	using IssueTracker.Issues.Handlers.CommandsResults;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;

	[Route("issue")]
	public class IssueController : CoreApiController
	{
		private readonly IMediator _mediator;

		public IssueController(IMediator mediator, ILoggerFactory loggerFactory)
		{
			_mediator = mediator;
		}

		[HttpPost("")]
		public async Task<IssueCreatedResult> CreateIssue([FromBody] CreateIssue issue)
		{
			var result = await _mediator.Send(issue);
			return result;
		}
	}
}