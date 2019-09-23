namespace IssueTracker.Framework.Abstractions.Domain
{
	using System.Collections.Generic;

	public interface IHasEvents
	{
		List<Event> GetDomainEvents();
	}
}