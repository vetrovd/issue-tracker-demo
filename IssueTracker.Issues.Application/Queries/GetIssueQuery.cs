namespace IssueTracker.Issues.Handlers.Queries
{
	using IssueTracker.Framework.Abstractions.Domain;
	using IssueTracker.Issues.Domain.Issue;

	public class GetIssueQuery: Query<Issue>
	{
		public int Id { get; set; }
	}
}