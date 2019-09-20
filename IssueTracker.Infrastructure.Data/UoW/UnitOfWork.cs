namespace IssueTracker.Infrastructure.Data.UoW
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Autofac;
	using IssueTracker.Framework.Abstractions.Data;
	using IssueTracker.Framework.Abstractions.Domain;
	using IssueTracker.Infrastructure.Data.Context;

	public class UnitOfWork: IUnitOfWork
	{
		private readonly IContainer _container;
		private readonly ApplicationDbContext _dbContext;

		public UnitOfWork(IContainer container, ApplicationDbContext dbContext)
		{
			_container = container;
			_dbContext = dbContext;
		}

		public IRepository<T> Repository<T>() where T : DomainModel
		{
			var repository = _container.Resolve<IRepository<T>>();
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