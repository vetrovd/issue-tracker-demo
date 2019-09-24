namespace IssueTracker.Contexts.Identity.Domain
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using IssueTracker.Framework.Abstractions.Security;
	using IssueTracker.Issues.Handlers.Commands;
	using MediatR;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Http;

	public class PermissionManager: IPermissionManager
	{
		private readonly IAuthorizationService _authorizationService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		protected readonly Dictionary<Type, string> _permissionsMatrix = new Dictionary<Type, string>()
		{
			[typeof(CreateIssue)] = Actions.CreateIssue,
		};

		public PermissionManager(IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor)
		{
			_authorizationService = authorizationService;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<bool> IsPermittedAsync<TOut>(IRequest<TOut> request)
		{
			return true;

			var user = _httpContextAccessor?.HttpContext?.User;
			var permissionName = _permissionsMatrix[request.GetType()];

			var isAuthorized = await _authorizationService.AuthorizeAsync(user, permissionName);
			return isAuthorized.Succeeded;
		}
	}
}