namespace IssueTracker.Contexts.Identity.Domain
{
	using Microsoft.AspNetCore.Authorization;

	public static class ConfigurePolicy
	{
		public static void AddPolicy(AuthorizationOptions options)
		{
			/*options.AddPolicy(Actions.CreateIssue, policy =>
			{
				  
			});*/
		}
	}
}