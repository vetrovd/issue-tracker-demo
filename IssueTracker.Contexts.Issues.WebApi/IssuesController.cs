namespace IssueTracker.Contexts.Issues.WebApi
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Threading.Tasks;
	using IssueTracker.Contexts.Core.WebApi;
	using IssueTracker.Issues.Handlers.Queries;
	using IssueTracker.Issues.Handlers.QueriesResults;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;
	using Newtonsoft.Json;

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
			var query = new GetIssuesQuery();
			var result = await _mediator.Send(query);
			return result;
		}

		[HttpGet("query")]
		[ProducesResponseType(typeof(List<GetFullIssueResult>), 200)]
		public async Task<IActionResult> GetAllIssuesQuery([FromQuery][Required] string[] columns)
		{
			var query = new GetIssuesDynamicQuery
			{
				Columns = columns.ToList()
			};

			var issues = await _mediator.Send(query);

			var result = JsonConvert.SerializeObject(
				issues,
				new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore});

			return Content(result);
		}
	}
}