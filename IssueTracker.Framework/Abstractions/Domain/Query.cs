namespace IssueTracker.Framework.Abstractions.Domain
{
	using MediatR;

	public abstract class Query<TResult> : IRequest<TResult>
	{
	}
}