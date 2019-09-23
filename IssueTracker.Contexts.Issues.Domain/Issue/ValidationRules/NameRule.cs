namespace IssueTracker.Issues.Domain.Issue.ValidationRules
{
	using IssueTracker.Framework.Abstractions.Validation;

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