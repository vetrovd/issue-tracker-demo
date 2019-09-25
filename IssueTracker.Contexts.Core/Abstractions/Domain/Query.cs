namespace IssueTracker.Contexts.Core.Abstractions.Domain
{
	using MediatR;

	public abstract class Query<TResult> : IRequest<TResult>
	{
	}
}