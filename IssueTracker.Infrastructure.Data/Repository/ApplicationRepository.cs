namespace IssueTracker.Infrastructure.Data.Repository
{
	using IssueTracker.Contexts.Core.Abstractions.Data;
	using IssueTracker.Contexts.Core.Abstractions.Domain;
	using IssueTracker.Infrastructure.Data.Context;

	public class ApplicationRepository<TEntity> : EfRepository<ApplicationDbContext, TEntity, int>, IRepository<TEntity>
		where TEntity : DomainModel
	{
		public ApplicationRepository(ApplicationDbContext dbContext)
		{
			Context = dbContext;
		}
	}
}