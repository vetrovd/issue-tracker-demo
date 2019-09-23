namespace IssueTracker.Infrastructure.Data.UoW
{
	using System.Threading.Tasks;
	using IssueTracker.Framework.Abstractions.Data;
	using IssueTracker.Framework.Abstractions.Domain;
	using IssueTracker.Infrastructure.Data.Context;
	using IssueTracker.Infrastructure.Data.Repository;

	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _dbContext;

		public UnitOfWork(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IRepository<T> Repository<T>() where T : DomainModel
		{
			var repository = new ApplicationRepository<T>(_dbContext);
			return repository;
		}

		public void SaveChanges()
		{
			_dbContext.SaveChanges();
		}

		public Task SaveChangesAsync()
		{
			return _dbContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}
	}
}