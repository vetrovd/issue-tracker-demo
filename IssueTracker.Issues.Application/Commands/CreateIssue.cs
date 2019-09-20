namespace IssueTracker.Issues.Handlers.Commands
{
	using IssueTracker.Framework.Abstractions.Domain;
	using IssueTracker.Issues.Handlers.CommandsResults;

	public class CreateIssue : Command<IssueCreatedResult>
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}