namespace IssueTracker.Contexts.Core.Abstractions.Data
{
	using IssueTracker.Contexts.Core.Abstractions.Domain;

	public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : DomainModel
	{
	}
}