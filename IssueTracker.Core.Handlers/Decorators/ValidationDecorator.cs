namespace IssueTracker.Core.Handlers.Decorators
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using FluentValidation;
	using IssueTracker.Core.Domain.Abstractions;
	using IssueTracker.Core.Handlers.Abstractions;
	using Microsoft.Extensions.Logging;

	public class ValidationDecorator<TQuery, TResult> : QueryHandler<TQuery, TResult> where TQuery: Query<TResult>
	{
		private readonly ILogger _logger;
		private readonly QueryHandler<TQuery, TResult> _decorated;
		private readonly IEnumerable<IValidator<TQuery>> _validators;

		public ValidationDecorator(QueryHandler<TQuery, TResult> decorated, ILoggerFactory loggerFactory, IEnumerable<IValidator<TQuery>> validators)
		{
			_decorated = decorated;
			_validators = validators;
			_logger = loggerFactory.CreateLogger("LogBehavior");
		}

		public override Task<TResult> Handle(TQuery request, CancellationToken cancellationToken)
		{
			_logger.LogWarning(">>>>>> ValidationDecorator -> Founded: " + _validators.Count());
			return _decorated.Handle(request, cancellationToken);
		}
	}
}