namespace IssueTracker.Users.WebApi
{
	using IssueTracker.Framework.WebApi;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;

	[Route("members")]
	public class MembersController : CoreApiController
	{
		private readonly IMediator _mediator;

		public MembersController(IMediator mediator, ILoggerFactory loggerFactory)
		{
			_mediator = mediator;
		}
	}
}