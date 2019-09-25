namespace IssueTracker.Contexts.Core.Abstractions.Domain
{
	using System.Collections.Generic;

	public interface IHasEvents
	{
		List<Event> GetDomainEvents();
	}
}