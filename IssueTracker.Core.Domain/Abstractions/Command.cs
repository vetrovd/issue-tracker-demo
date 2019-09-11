namespace IssueTracker.Core.Domain.Abstractions
{
	using MediatR;

	public abstract class Command<TResponse>: IRequest<TResponse>
	{
	}
}