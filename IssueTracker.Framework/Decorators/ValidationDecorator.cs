namespace IssueTracker.Framework.Decorators
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using FluentValidation;
	using IssueTracker.Framework.Exceptions;
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
			var context = new ValidationContext(request);
			var failures = _validators
				.Select(v => v.Validate(context))
				.SelectMany(result => result.Errors)
				.Where(f => f != null)
				.ToList();

			if (failures.Count > 0)
			{
				var exception = new InvalidRequestException(failures);
				throw exception;
			}
			
			return _decorated.Handle(request, cancellationToken);
		}
	}
}