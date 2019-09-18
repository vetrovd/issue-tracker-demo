namespace IssueTracker.Issues.Handlers.QueryHandlers
{
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;
	using IssueTracker.Framework.Abstractions.Handlers;
	using IssueTracker.Issues.Domain.Issue;
	using IssueTracker.Issues.Handlers.Queries;
	using Microsoft.Extensions.Logging;

	public class GetIssuesHandler : IQueryHandler<GetIssuesQuery, List<Issue>>
	{
		private readonly ILogger _logger;

		public GetIssuesHandler(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger<GetIssuesHandler>();
		}

		public async Task<List<Issue>> Handle(GetIssuesQuery request, CancellationToken cancellationToken)
		{
			_logger.LogWarning(">>>>>> GetIssuesHandler -> Handle");

			return null;
		}
	}
}