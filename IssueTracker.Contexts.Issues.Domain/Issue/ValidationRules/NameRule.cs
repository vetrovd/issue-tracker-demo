namespace IssueTracker.Issues.Domain.Issue.ValidationRules
{
	using IssueTracker.Contexts.Core.Abstractions.Validation;

	public class NameRule :  ValidationRule<string>
	{
		private int _max = 100;

		public NameRule() 
		{
		}

		public override bool IsValid(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return false;
			}

			if (value.Length > _max)
			{
				return false;
			}

			return true;
		}
	}
}