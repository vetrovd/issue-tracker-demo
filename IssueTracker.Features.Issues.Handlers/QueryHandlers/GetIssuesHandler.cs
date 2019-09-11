namespace IssueTracker.Features.Issues.Handlers.QueryHandlers
{
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;
	using IssueTracker.Core.Handlers;
	using IssueTracker.Core.Handlers.Abstractions;
	using IssueTracker.Features.Issues.Domain.Entities;
	using IssueTracker.Features.Issues.Domain.Queries;
	using Microsoft.Extensions.Logging;

	public class GetIssuesHandler : QueryHandler<GetIssues, List<Issue>>
	{
		private readonly ILogger _logger;

		public GetIssuesHandler(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger<GetIssuesHandler>();
		}

		public override async Task<List<Issue>> Handle(GetIssues request, CancellationToken cancellationToken)
		{
			_logger.LogWarning(">>>>>> GetIssuesHandler -> Handle");

			return new List<Issue>()
			{
				new Issue() { Id = 1, Name = "Hello!" }
			};
		}
	}
}