namespace IssueTracker.Core.Handlers.Decorators
{
	using System.Threading;
	using System.Threading.Tasks;
	using IssueTracker.Core.Domain.Abstractions;
	using IssueTracker.Core.Handlers.Abstractions;
	using Microsoft.Extensions.Logging;

	public class LogDecorator<TQuery, TResult> : QueryHandler<TQuery, TResult> where TQuery: Query<TResult>
	{
		private readonly ILogger _logger;
		private readonly QueryHandler<TQuery, TResult> _decorated;

		public LogDecorator(QueryHandler<TQuery, TResult> decorated, ILoggerFactory loggerFactory)
		{
			_decorated = decorated;
			_logger = loggerFactory.CreateLogger("LogBehavior");
		}

		public override Task<TResult> Handle(TQuery request, CancellationToken cancellationToken)
		{
			var result = _decorated.Handle(request, cancellationToken);
			_logger.LogWarning(">>>>>> LogDecorator -> Process");
			return result;
		}
	}
}