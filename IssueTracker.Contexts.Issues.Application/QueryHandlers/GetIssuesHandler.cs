namespace IssueTracker.Issues.Handlers.QueryHandlers
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using AutoMapper;
	using AutoMapper.QueryableExtensions;
	using IssueTracker.Framework.Abstractions.Data;
	using IssueTracker.Framework.Abstractions.Handlers;
	using IssueTracker.Issues.Domain.Issue;
	using IssueTracker.Issues.Handlers.Queries;
	using IssueTracker.Issues.Handlers.QueriesResults;
	using Microsoft.Extensions.Logging;

	public class GetIssuesHandler : IQueryHandler<GetIssuesQuery, List<GetFullIssueResult>>
	{
		private readonly ILogger _logger;
		private readonly IMapper _mapper;

		public GetIssuesHandler(ILoggerFactory loggerFactory, IMapper mapper)
		{
			_mapper = mapper;
			_logger = loggerFactory.CreateLogger<GetIssuesHandler>();
		}

		public async Task<List<GetFullIssueResult>> Handle(GetIssuesQuery request, CancellationToken cancellationToken)
		{
			_logger.LogWarning(">>>>>> GetIssuesHandler -> Handle");

			/*var issues = _repository.GetAllForQuery()
				.Where(a => a.Id > 0)
				.ProjectTo<GetFullIssueResult>(_mapper.ConfigurationProvider)
				.ToList();

			return issues;*/
			return null;
		}
	}
}