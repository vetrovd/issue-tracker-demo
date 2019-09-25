namespace IssueTracker.Contexts.Core.Abstractions.Domain
{
	using MediatR;

	public abstract class Command<TResponse> : IRequest<TResponse>
	{
	}
}