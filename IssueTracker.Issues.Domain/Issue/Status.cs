namespace IssueTracker.Issues.Domain.Issue
{
	using System;
	using System.Collections.Generic;
	using IssueTracker.Framework.Abstractions.Domain;

	public class Status : ValueObject
	{
		protected override IEnumerable<object> GetAtomicValues()
		{
			throw new NotImplementedException();
		}
	}
}