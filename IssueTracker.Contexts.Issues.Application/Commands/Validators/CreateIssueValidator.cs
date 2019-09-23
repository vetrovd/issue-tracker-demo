namespace IssueTracker.Issues.Handlers.Commands.Validators
{
	using FluentValidation;
	using IssueTracker.Issues.Domain.Issue.ValidationRules;

	public class CreateIssueValidator : AbstractValidator<CreateIssue>
	{
		public CreateIssueValidator()
		{
			RuleFor(x => x.Name)
				.Must(name => (new NameRule()).IsValid(name))
				.WithMessage("Invalid name");

			RuleFor(x => x.Description)
				.Must(description => (new DescriptionRule()).IsValid(description))
				.WithMessage("Invalid description");
		}
	}
}