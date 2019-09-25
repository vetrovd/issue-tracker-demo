namespace IssueTracker.Issues.Handlers.Queries
{
	using System.Collections.Generic;
	using IssueTracker.Contexts.Core.Abstractions.Domain;
	using IssueTracker.Issues.Handlers.QueriesResults;

	public class GetIssuesDynamicQuery :  Query<List<GetFullIssueResultDynamic>>
	{
		public List<string> Columns { get; set; }
	}
}