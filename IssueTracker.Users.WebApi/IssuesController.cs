namespace IssueTracker.Users.WebApi
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using IssueTracker.Framework.WebApi;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;

	[Route("users")]
	public class UsersController : CoreApiController
	{
		private readonly IMediator _mediator;

		public UsersController(IMediator mediator, ILoggerFactory loggerFactory)
		{
			_mediator = mediator;
		}
	}
}