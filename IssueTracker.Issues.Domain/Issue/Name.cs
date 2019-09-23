namespace IssueTracker.Issues.Domain.Issue
{
	using System;
	using System.Collections.Generic;
	using IssueTracker.Framework.Abstractions.Domain;
	using IssueTracker.Issues.Domain.Issue.ValidationRules;

	public class Name : ValueObject<string>
	{
		protected Name()
		{
		}

		public Name(string name)
		{
			var validator = new NameRule();
			if (!validator.IsValid(name))
			{
				throw new ArgumentException();
			}
			Value = name;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return Value;
		}
	}
}