namespace IssueTracker.Issues.Handlers.Queries
{
	using System.Collections.Generic;
	using IssueTracker.Framework.Abstractions.Domain;
	using IssueTracker.Issues.Domain.Issue;

	public class GetIssuesQuery : Query<List<Issue>>
	{
	}
}