namespace IssueTracker.Core.Web
{
	using Microsoft.AspNetCore.Mvc;

	[Area("api")]
	[Route("[area]/[controller]")]
	[ApiController]
	public abstract class CoreApiController : ControllerBase 
	{
	}
}