namespace IssueTracker.Core.Domain.Abstractions
{
	using MediatR;

	public abstract class Query<TResult>: IRequest<TResult>
	{
		
	}
}