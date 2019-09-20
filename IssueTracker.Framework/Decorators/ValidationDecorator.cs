namespace IssueTracker.Framework.Decorators
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using FluentValidation;
	using MediatR;
	using Microsoft.Extensions.Logging;

	public class ValidationDecorator<TIn, TOut> : IRequestHandler<TIn, TOut> where TIn : IRequest<TOut>
	{
		private readonly IRequestHandler<TIn, TOut> _decorated;
		private readonly ILogger _logger;
		private readonly IEnumerable<IValidator<TIn>> _validators;

		public ValidationDecorator(IRequestHandler<TIn, TOut> decorated, ILoggerFactory loggerFactory,
			IEnumerable<IValidator<TIn>> validators)
		{
			_decorated = decorated;
			_validators = validators;
			_logger = loggerFactory.CreateLogger("ValidationBehavior");
		}

		public Task<TOut> Handle(TIn request, CancellationToken cancellationToken)
		{
			_logger.LogWarning(">>>>>> ValidationDecorator -> Founded: " + _validators.Count());
			return _decorated.Handle(request, cancellationToken);
		}
	}
}