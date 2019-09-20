namespace IssueTracker.Framework.Abstractions.Handlers
{
	using System.Threading;
	using System.Threading.Tasks;
	using IssueTracker.Framework.Abstractions.Domain;
	using MediatR;

	public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
		where TQuery : Query<TResult>
	{
		Task<TResult> Handle(TQuery request, CancellationToken cancellationToken);
	}
}