namespace IssueTracker.Issues.Handlers.CommandHandlers
{
	using System.Threading;
	using System.Threading.Tasks;
	using AutoMapper;
	using IssueTracker.Contexts.Core.Abstractions.Data;
	using IssueTracker.Contexts.Core.Abstractions.Handlers;
	using IssueTracker.Contexts.Core.Decorators.Interfaces;
	using IssueTracker.Issues.Domain.Issue;
	using IssueTracker.Issues.Handlers.Commands;
	using IssueTracker.Issues.Handlers.CommandsResults;

	public class CreateIssueHandler : ICommandHandler<CreateIssue, Issue>, IWithSaveChanges, IWithLogging
	{
		private readonly IUnitOfWork _unitOfWork;

		public CreateIssueHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Issue> Handle(CreateIssue request, CancellationToken cancellationToken)
		{
			var issue = new Issue(new Name(request.Name), new Description(request.Description));

			var repository = _unitOfWork.Repository<Issue>();
			issue = await repository.InsertAsync(issue);
			return issue;
		}
	}
}