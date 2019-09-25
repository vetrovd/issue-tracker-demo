namespace IssueTracker.Contexts.Core.Abstractions.Validation
{
	public abstract class ValidationRule<T>
	{
		public abstract bool IsValid(T value);
	}
}