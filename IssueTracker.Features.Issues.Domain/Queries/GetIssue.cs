namespace IssueTracker.Features.Issues.Domain.Queries
{
	using IssueTracker.Core.Domain.Abstractions;
	using IssueTracker.Features.Issues.Domain.Entities;

	public class GetIssue: Query<Issue>
	{
		public int Id { get; set; }
	}
}