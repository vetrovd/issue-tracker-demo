namespace IssueTracker.Features.Issues.Domain.Validators
{
	using FluentValidation;
	using IssueTracker.Features.Issues.Domain.Queries;

	public class GetIssueCommandValidator: AbstractValidator<GetIssue>
	{
		public GetIssueCommandValidator()
		{
			RuleFor(model => model.Id).GreaterThan(5);
		}
	}
}