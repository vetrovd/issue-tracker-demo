namespace IssueTracker.Framework.Exceptions
{
	public class EntityDoNotExistsDomainException : DomainException
	{
		public string Entity { get; protected set; }

		public EntityDoNotExistsDomainException(string entityName)
		{
			Entity = entityName;
		}
	}
}