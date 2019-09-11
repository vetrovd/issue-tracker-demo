namespace IssueTracker.Features.Issues.Domain.Queries
{
	using System.Collections.Generic;
	using IssueTracker.Core.Domain.Abstractions;
	using IssueTracker.Features.Issues.Domain.Entities;
	using Microsoft.Extensions.Logging;

	public class GetIssues: Query<List<Issue>>
	{
	}
}