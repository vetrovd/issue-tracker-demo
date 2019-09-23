namespace IssueTracker.Framework.Decorators
{
	using System.Threading;
	using System.Threading.Tasks;
	using IssueTracker.Framework.Abstractions.Data;
	using IssueTracker.Framework.Abstractions.Domain;
	using IssueTracker.Framework.Abstractions.Handlers;

	public class TransactionDecorator<TIn, TOut> : ICommandHandler<TIn, TOut> where TIn : Command<TOut>
	{
		private readonly ICommandHandler<TIn, TOut> _decorated;
		private readonly IUnitOfWork _unitOfWork;

		public TransactionDecorator(ICommandHandler<TIn, TOut> decorated, IUnitOfWork unitOfWork)
		{
			_decorated = decorated;
			_unitOfWork = unitOfWork;
		}

		public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken)
		{
			//todo: open transaction here
			var result = await _decorated.Handle(request, cancellationToken);
			//todo: close transaction here
			return result;
		}
	}
}