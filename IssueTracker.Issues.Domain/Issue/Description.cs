namespace IssueTracker.Issues.Domain.Issue
{
	using System.Collections.Generic;
	using IssueTracker.Framework.Abstractions.Domain;

	public class Description : ValueObject
	{
		protected Description()
		{
		}

		public Description(string description)
		{
			Value = description;
		}

		public string Value { get; }

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return Value;
		}
	}
}