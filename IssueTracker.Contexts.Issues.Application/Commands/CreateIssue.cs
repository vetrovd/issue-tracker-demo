namespace IssueTracker.Issues.Handlers.Commands
{
	using IssueTracker.Contexts.Core.Abstractions.Domain;
	using IssueTracker.Issues.Domain.Issue;

	public class CreateIssue : Command<Issue>
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}