namespace IssueTracker.Issues.Domain.Issue
{
	using System.Collections.Generic;
	using IssueTracker.Framework.Abstractions.Domain;

	public class Name: ValueObject
	{
		public string Value { get; }

		protected Name()
		{

		}

		public Name(string name)
		{
			Value = name;
		}

		public bool IsValid(string value)
		{
			return true;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return Value;
		}
	}
}