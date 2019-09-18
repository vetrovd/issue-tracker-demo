namespace IssueTracker.Framework.Abstractions.Handlers
{
	using System.Threading;
	using System.Threading.Tasks;
	using IssueTracker.Framework.Abstractions.Domain;
	using MediatR;

	public interface ICommandHandler<in TCommand, TResult>: IRequestHandler<TCommand, TResult> 
		where TCommand: Command<TResult>
	{
	}
}