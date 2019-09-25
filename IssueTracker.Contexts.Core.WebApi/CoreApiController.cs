namespace IssueTracker.Contexts.Core.WebApi
{
	using System.Collections.Generic;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	[Route("[area]/[controller]")]
	[Area("api")]
	[Consumes("application/json")]
	[Produces("application/json")]
	[ProducesResponseType(typeof(List<ErrorDto>), 422)]
	public abstract class CoreApiController : ControllerBase
	{
	}
}