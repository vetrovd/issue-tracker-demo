namespace IssueTracker.Issues.Domain.Issue
{
	using System;
	using IssueTracker.Framework.Abstractions.Domain;

	public class Issue : DomainModel
	{
		protected Issue()
		{

		}

		public Issue(Name name, Description description): this(name, description, new Status())
		{
		}

		public Issue(Name name, Description description, Status status)
		{
			Name = name ?? throw new ArgumentNullException(nameof(name));
			Description = description ?? throw new ArgumentNullException(nameof(description));
			Status = status ?? throw new ArgumentNullException(nameof(status));
		}

		public Name Name { get; set; }

		public Description Description { get; set; }

		public Status Status { get; set; }
	}
}