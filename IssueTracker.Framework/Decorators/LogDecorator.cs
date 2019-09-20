namespace IssueTracker.Framework.Decorators
{
	using System.Threading;
	using System.Threading.Tasks;
	using MediatR;
	using Microsoft.Extensions.Logging;

	public class LogDecorator<TIn, TOut> : IRequestHandler<TIn, TOut> where TIn : IRequest<TOut>
	{
		private readonly IRequestHandler<TIn, TOut> _decorated;
		private readonly ILogger _logger;

		public LogDecorator(IRequestHandler<TIn, TOut> decorated, ILoggerFactory loggerFactory)
		{
			_decorated = decorated;
			_logger = loggerFactory.CreateLogger("LogBehavior");
		}

		public Task<TOut> Handle(TIn request, CancellationToken cancellationToken)
		{
			var result = _decorated.Handle(request, cancellationToken);
			_logger.LogWarning(">>>>>> LogDecorator -> Process");
			return result;
		}
	}
}