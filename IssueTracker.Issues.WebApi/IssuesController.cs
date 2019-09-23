namespace IssueTracker.Issues.WebApi
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using IssueTracker.Framework.WebApi;
	using IssueTracker.Issues.Handlers.Queries;
	using IssueTracker.Issues.Handlers.QueriesResults;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;

	[Route("issues")]
	public class IssuesController : CoreApiController
	{
		private readonly IMediator _mediator;

		public IssuesController(IMediator mediator, ILoggerFactory loggerFactory)
		{
			_mediator = mediator;
		}

		[HttpGet("")]
		[ProducesResponseType(typeof(List<GetFullIssueResult>), 200)]
		public async Task<List<GetFullIssueResult>> GetAllIssues()
		{
			var result = await _mediator.Send(new GetIssuesQuery());
			return result;
		}
	}
}