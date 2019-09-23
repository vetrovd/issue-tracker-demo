namespace IssueTracker.Framework.Abstractions.Handlers
{
	using IssueTracker.Framework.Abstractions.Domain;
	using MediatR;

	public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
		where TEvent : Event
	{
		
	}
}