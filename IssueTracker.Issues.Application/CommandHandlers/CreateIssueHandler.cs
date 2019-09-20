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

	public class CreateIssueHandler : ICommandHandler<CreateIssue, IssueCreatedResult>, IWithLogging, IWithValidation
	{
		private readonly IMapper _mapper;
		private readonly  IUnitOfWork _unitOfWork;

		public CreateIssueHandler(IRepository<Issue> repository, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<IssueCreatedResult> Handle(CreateIssue request, CancellationToken cancelationToken)
		{
			var issue = new Issue(new Name(request.Name), new Description(request.Description));
			using (_unitOfWork)
			{
				var repository =  _unitOfWork.Repository<Issue>();
				issue = await repository.InsertAsync(issue);
				_unitOfWork.SaveChanges();
			}
			var result = _mapper.Map<IssueCreatedResult>(issue);
			return result;
		}
	}
}