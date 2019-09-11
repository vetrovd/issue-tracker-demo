namespace IssueTracker.Core.Handlers.Abstractions
{
	using System.Threading;
	using System.Threading.Tasks;
	using IssueTracker.Core.Domain.Abstractions;
	using MediatR;

	public abstract class CommandHandler<TCommand, TResult>: IRequestHandler<TCommand, TResult> 
		where TCommand: Command<TResult>
	{
		public abstract Task<TResult> Handle(TCommand request, CancellationToken cancellationToken);
	}
}