namespace IssueTracker.Core.Handlers.Abstractions
{
	using System.Threading;
	using System.Threading.Tasks;
	using IssueTracker.Core.Domain.Abstractions;
	using MediatR;

	public abstract class QueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> 
		where TQuery: Query<TResult>
	{
		public abstract Task<TResult> Handle(TQuery request, CancellationToken cancellationToken);
	}
}