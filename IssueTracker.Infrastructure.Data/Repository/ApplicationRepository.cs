namespace IssueTracker.Infrastructure.Data.Repository
{
	using IssueTracker.Framework.Abstractions.Data;
	using IssueTracker.Framework.Abstractions.Domain;
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