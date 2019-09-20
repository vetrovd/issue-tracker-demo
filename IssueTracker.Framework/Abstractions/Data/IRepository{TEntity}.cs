namespace IssueTracker.Framework.Abstractions.Data
{
	using IssueTracker.Framework.Abstractions.Domain;

	public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : DomainModel
	{
	}
}