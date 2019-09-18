namespace IssueTracker.Framework.WebApi
{
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	[Route("[area]/[controller]")]
	[Area("api")]
	[Consumes("application/json")]
	[Produces("application/json")]
	public abstract class CoreApiController : ControllerBase 
	{
	}
}