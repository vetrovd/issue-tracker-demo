namespace IssueTracker.Issues.Domain.Issue
{
	using System;
	using System.Collections.Generic;
	using IssueTracker.Contexts.Core.Abstractions.Domain;

	public class Status : ValueObject<int>
	{
		protected override IEnumerable<object> GetAtomicValues()
		{
			throw new NotImplementedException();
		}
	}
}