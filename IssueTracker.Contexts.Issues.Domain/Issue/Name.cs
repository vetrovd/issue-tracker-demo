namespace IssueTracker.Issues.Domain.Issue
{
	using System;
	using System.Collections.Generic;
	using IssueTracker.Contexts.Core.Abstractions.Domain;
	using IssueTracker.Contexts.Core.Exceptions;
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
				throw new InvalidEntityException();
			}
			Value = name;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return Value;
		}
	}
}