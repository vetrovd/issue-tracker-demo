namespace IssueTracker.Contexts.Core.Abstractions.Handlers
{
	using System.Threading;
	using System.Threading.Tasks;
	using IssueTracker.Contexts.Core.Abstractions.Domain;
	using MediatR;

	public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
		where TQuery : Query<TResult>
	{
		Task<TResult> Handle(TQuery request, CancellationToken cancellationToken);
	}
}