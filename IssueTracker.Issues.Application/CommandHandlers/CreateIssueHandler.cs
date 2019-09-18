namespace IssueTracker.Issues.Handlers.CommandHandlers
{
	using System.Threading;
	using System.Threading.Tasks;
	using AutoMapper;
	using IssueTracker.Framework.Abstractions.Data;
	using IssueTracker.Framework.Abstractions.Handlers;
	using IssueTracker.Framework.Decorators.Interfaces;
	using IssueTracker.Issues.Domain.Issue;
	using IssueTracker.Issues.Handlers.Commands;
	using IssueTracker.Issues.Handlers.CommandsResults;
	using MediatR;

	public class CreateIssueHandler : ICommandHandler<CreateIssue, IssueCreatedResult>, IWithLogging, IWithValidation
	{
		private readonly IMapper _mapper;
		private readonly IRepository<Issue> _repository;

		public CreateIssueHandler(IRepository<Issue> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IssueCreatedResult> Handle(CreateIssue request, CancellationToken cancellationToken)
		{
			var issue = new Issue(new Name(request.Name), new Description(request.Description));
			issue = await _repository.InsertAsync(issue);

			//var result = _mapper.Map<IssueCreatedResult>(issue);
			return null;
		}
	}
}