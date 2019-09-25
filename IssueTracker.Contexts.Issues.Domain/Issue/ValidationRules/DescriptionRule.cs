namespace IssueTracker.Issues.Domain.Issue.ValidationRules
{
	using IssueTracker.Contexts.Core.Abstractions.Validation;

	public class DescriptionRule : ValidationRule<string>
	{
		private int _max = 250;

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