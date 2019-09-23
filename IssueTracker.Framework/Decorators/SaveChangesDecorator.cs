namespace IssueTracker.Framework.Decorators
{
	using System.Threading;
	using System.Threading.Tasks;
	using IssueTracker.Framework.Abstractions.Data;
	using MediatR;

	public class SaveChangesDecorator<TIn, TOut> : IRequestHandler<TIn, TOut> where TIn : IRequest<TOut>
	{
		private readonly IRequestHandler<TIn, TOut> _decorated;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMediator _mediator;

		public SaveChangesDecorator(IRequestHandler<TIn, TOut> decorated, IUnitOfWork unitOfWork, IMediator mediator)
		{
			_decorated = decorated;
			_unitOfWork = unitOfWork;
			_mediator = mediator;
		}

		public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken)
		{
			var result = await _decorated.Handle(request, cancellationToken);

			_unitOfWork.GetEvents()
				.ForEach(@event => 
					  _mediator.Publish(@event, cancellationToken)
				);

			await _unitOfWork.SaveChangesAsync();

			return result;
		}
	}
}