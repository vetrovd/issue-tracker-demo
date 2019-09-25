namespace IssueTracker.Contexts.Core.Abstractions.Handlers
{
	using IssueTracker.Contexts.Core.Abstractions.Domain;
	using MediatR;

	public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
		where TEvent : Event
	{
		
	}
}