namespace IssueTracker.Framework.Exceptions
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using FluentValidation.Results;

	public class InvalidRequestException : DomainException
	{
		public IEnumerable<ValidationFailure> Errors { get; protected set; }

		public InvalidRequestException()
		{

		}

		public InvalidRequestException(IEnumerable<ValidationFailure> errors)
		{
			Errors = errors;
		}
	}
}