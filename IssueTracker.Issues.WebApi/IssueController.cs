namespace IssueTracker.Issues.WebApi
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using AutoMapper;
	using IssueTracker.Framework.WebApi;
	using IssueTracker.Issues.Handlers.Commands;
	using IssueTracker.Issues.Handlers.CommandsResults;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;

	[Route("issue")]
	public class IssueController : CoreApiController
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public IssueController(IMediator mediator, ILoggerFactory loggerFactory, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpPost("")]
		[ProducesResponseType(typeof(IssueCreatedResult), 200)]
		public async Task<IssueCreatedResult> CreateIssue([FromBody] CreateIssue issue)
		{
			var commandResult = await _mediator.Send(issue);

			var dto = _mapper.Map<IssueCreatedResult>(commandResult);
			return dto;
		}
	}
}