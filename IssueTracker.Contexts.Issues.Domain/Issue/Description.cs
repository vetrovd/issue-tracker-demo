namespace IssueTracker.Issues.Domain.Issue
{
	using System;
	using System.Collections.Generic;
	using IssueTracker.Framework.Abstractions.Domain;
	using IssueTracker.Framework.Exceptions;
	using IssueTracker.Issues.Domain.Issue.ValidationRules;

	public class Description : ValueObject<string>
	{
		protected Description()
		{
		}

		public Description(string description)
		{
			var validator = new DescriptionRule();
			if (!validator.IsValid(description))
			{
				throw new InvalidEntityException();
			}
			Value = description;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return Value;
		}
	}
}