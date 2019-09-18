namespace IssueTracker.Issues.Handlers.QueryHandlers
{
	using System.Threading;
	using System.Threading.Tasks;
	using IssueTracker.Framework.Abstractions.Handlers;
	using IssueTracker.Issues.Domain.Issue;
	using IssueTracker.Issues.Handlers.Queries;
	using Microsoft.Extensions.Logging;

	public class GetIssueHandler : IQueryHandler<GetIssueQuery, Issue>
	{
		private readonly ILogger _logger;

		public GetIssueHandler(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger<GetIssuesHandler>();
		}

		public async Task<Issue> Handle(GetIssueQuery query, CancellationToken cancellationToken)
		{
			_logger.LogWarning(">>>>>> GetIssueHandler -> Handle");

			return null;
		}
	}
}