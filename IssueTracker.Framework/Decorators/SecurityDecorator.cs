namespace IssueTracker.Framework.Decorators
{
	using System.Security;
	using System.Threading;
	using System.Threading.Tasks;
	using IssueTracker.Framework.Abstractions.Security;
	using MediatR;

	public class SecurityDecorator<TIn, TOut> : IRequestHandler<TIn, TOut> where TIn : IRequest<TOut>
	{
		private readonly IRequestHandler<TIn, TOut> _decorated;
		private readonly IPermissionManager _permissionManager;

		public SecurityDecorator(IRequestHandler<TIn, TOut> decorated, IPermissionManager permissionManager)
		{
			_decorated = decorated;
			_permissionManager = permissionManager;
		}

		public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken)
		{
			var hasAccess = await _permissionManager.IsPermittedAsync(request);
			if (!hasAccess)
			{
				throw new SecurityException();
			}

			return await _decorated.Handle(request, cancellationToken);
		}
	}
}