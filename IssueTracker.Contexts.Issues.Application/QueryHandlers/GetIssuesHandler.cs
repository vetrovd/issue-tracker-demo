namespace IssueTracker.Issues.Handlers.QueryHandlers
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using AutoMapper;
	using AutoMapper.QueryableExtensions;
	using IssueTracker.Contexts.Core.Abstractions.Data;
	using IssueTracker.Contexts.Core.Abstractions.Handlers;
	using IssueTracker.Issues.Domain.Issue;
	using IssueTracker.Issues.Handlers.Queries;
	using IssueTracker.Issues.Handlers.QueriesResults;
	using Microsoft.Extensions.Logging;

	public class GetIssuesHandler : IQueryHandler<GetIssuesQuery, List<GetFullIssueResult>>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public GetIssuesHandler(ILoggerFactory loggerFactory, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetFullIssueResult>> Handle(GetIssuesQuery request, CancellationToken cancellationToken)
		{
			var issues = _unitOfWork.Repository<Issue>()
				.GetAllForQuery()
				.ProjectTo<GetFullIssueResult>(_mapper.ConfigurationProvider)
				.ToList();

			return issues;
		}
	}
}