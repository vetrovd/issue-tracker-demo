namespace IssueTracker.Contexts.Core.Abstractions.Handlers
{
	using IssueTracker.Contexts.Core.Abstractions.Domain;
	using MediatR;

	public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
		where TCommand : Command<TResult>
	{
	}
}