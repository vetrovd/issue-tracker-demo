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

	public class GetIssuesDynamicHandler: IQueryHandler<GetIssuesDynamicQuery, List<GetFullIssueResultDynamic>>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public GetIssuesDynamicHandler(ILoggerFactory loggerFactory, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetFullIssueResultDynamic>> Handle(GetIssuesDynamicQuery request, CancellationToken cancellationToken)
		{
			var result = _unitOfWork.Repository<Issue>()
				.GetAllForQuery()
				.ProjectTo<GetFullIssueResultDynamic>(
					_mapper.ConfigurationProvider, 
					null, 
					request.Columns.ToArray())
				.ToList();

			return result;
		}
	}
}