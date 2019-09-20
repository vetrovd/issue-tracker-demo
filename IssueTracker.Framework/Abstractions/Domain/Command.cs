namespace IssueTracker.Framework.Abstractions.Domain
{
	using MediatR;

	public abstract class Command<TResponse> : IRequest<TResponse>
	{
	}
}