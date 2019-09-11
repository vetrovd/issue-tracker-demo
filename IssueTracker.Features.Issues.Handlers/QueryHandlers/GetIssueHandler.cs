namespace IssueTracker.Features.Issues.Handlers.QueryHandlers
{
	using System.Threading;
	using System.Threading.Tasks;
	using IssueTracker.Core.Handlers;
	using IssueTracker.Core.Handlers.Abstractions;
	using IssueTracker.Features.Issues.Domain.Entities;
	using IssueTracker.Features.Issues.Domain.Queries;
	using Microsoft.Extensions.Logging;

	public class GetIssueHandler : QueryHandler<GetIssue, Issue>
	{
		private readonly ILogger _logger;

		public GetIssueHandler(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger<GetIssuesHandler>();
		}

		public override async Task<Issue> Handle(GetIssue request, CancellationToken cancellationToken)
		{
			_logger.LogWarning(">>>>>> GetIssueHandler -> Handle");

			return new Issue() { Id = 1, Name = "Hello!" };
		}
	}
}