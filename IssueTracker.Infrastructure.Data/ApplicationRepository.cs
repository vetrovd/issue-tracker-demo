namespace IssueTracker.Infrastructure.Data
{
	using IssueTracker.Framework.Abstractions.Data;
	using IssueTracker.Framework.Abstractions.Domain;
	using IssueTracker.Infrastructure.Data.Context;
	using Microsoft.EntityFrameworkCore;

	public class ApplicationRepository<TEntity> : EfRepository<ApplicationDbContext, TEntity, int>, IRepository<TEntity> 
		where TEntity : DomainModel
	{
		public ApplicationRepository(ApplicationDbContext dbContext)
		{
			Context = dbContext;
		}
	}
}