namespace IssueTracker.Issues.WebApi
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using IssueTracker.Framework.WebApi;
	using IssueTracker.Issues.Domain.Issue;
	using IssueTracker.Issues.Handlers.Commands;
	using IssueTracker.Issues.Handlers.CommandsResults;
	using IssueTracker.Issues.Handlers.Queries;
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

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(Issue), 200)]
		[ProducesResponseType(typeof(List<ErrorDto>),400)]
		public async Task<Issue> GetIssueById([FromRoute] int id)
		{
			var result = await _mediator.Send(new GetIssueQuery() { Id = id });
			return result;
		}

		[HttpPost("")]
		public async Task<IssueCreatedResult> CreateIssue([FromBody] CreateIssue issue)
		{
			var result = await _mediator.Send(issue);
			return result;
		}

		[HttpPut("{id}")]
		public async Task<Issue> UpdateIssue([FromRoute] int id, [FromBody] GetIssueQuery issue)
		{
			var result = await _mediator.Send(new GetIssueQuery() { Id = id });
			return result;
		}

		[HttpDelete("{id}")]
		public async Task<RemovedObjectDto> DeleteIssue([FromRoute] int id)
		{
			var result = new RemovedObjectDto();
			return result;
		}

		[HttpPost("{id}/move")]
		public async Task<Issue> MoveIssue([FromRoute] int id, CreateIssue transition)
		{
			var result = await _mediator.Send(new GetIssueQuery() { Id = id });
			return result;
		}
	}
}