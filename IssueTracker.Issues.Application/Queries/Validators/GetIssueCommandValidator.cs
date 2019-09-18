namespace IssueTracker.Issues.Handlers.Queries.Validators
{
	using FluentValidation;

	public class GetIssueCommandValidator: AbstractValidator<GetIssueQuery>
	{
		public GetIssueCommandValidator()
		{
			RuleFor(model => model.Id).GreaterThan(5);
		}
	}
}