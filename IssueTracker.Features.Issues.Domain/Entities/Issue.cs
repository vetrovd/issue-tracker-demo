namespace IssueTracker.Features.Issues.Domain.Entities
{
	using IssueTracker.Core.Domain.Abstractions;

	public class Issue : DomainModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}