namespace IssueTracker.Features.Issues.WebApi.Issues
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using IssueTracker.Core.Web;
	using IssueTracker.Features.Issues.Domain.Entities;
	using IssueTracker.Features.Issues.Domain.Queries;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;

	public class IssuesController : CoreApiController
	{
		private readonly IMediator _mediator;
		private readonly ILogger  _logger;

		public IssuesController(IMediator mediator, ILoggerFactory loggerFactory)
		{
			_mediator = mediator;
			_logger = loggerFactory.CreateLogger<IssuesController>();
		}

		[Route("")]
		public async Task<List<Issue>> Issues()
		{
			_logger.LogWarning(">>>>>> IssuesController -> Issues");

			var result = await _mediator.Send(new GetIssues());
			return result;
		}

		[Route("{id}")]
		public async Task<Issue> Issue(int id)
		{
			_logger.LogWarning($">>>>>> IssuesController -> Issue {id}");

			var result = await _mediator.Send(new GetIssue() { Id = id });
			return result;
		}
	}
}