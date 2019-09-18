namespace IssueTracker.Issues.Domain.Issue
{
	using System.Collections.Generic;
	using IssueTracker.Framework.Abstractions.Domain;

	public class Description: ValueObject
	{
		public string Value { get; }

		protected Description()
		{

		}

		public Description(string description)
		{
			Value = description;
		}
		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return Value;
		}
	}
}