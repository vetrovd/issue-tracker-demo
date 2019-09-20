namespace IssueTracker.Infrastructure.Data
{
	using System;
	using System.Linq;
	using System.Linq.Expressions;
	using IssueTracker.Framework.Abstractions.Data;
	using IssueTracker.Framework.Abstractions.Domain;
	using Microsoft.EntityFrameworkCore;

	public class EfRepository<TDbContext, TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey>
		where TEntity : DomainModel
		where TDbContext : DbContext
	{
		protected TDbContext Context { get; set; }

		public virtual DbSet<TEntity> Table => Context.Set<TEntity>();

		public override IQueryable<TEntity> GetAllForQuery()
		{
			return GetAllForQueryIncluding();
		}
		public override IQueryable<TEntity> GetAllForQueryIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
		{
			var query = Table.AsNoTracking();
			if (propertySelectors != null && propertySelectors.Length > 0)
			{
				foreach (var propertySelector in propertySelectors)
				{
					query = query.Include(propertySelector);
				}
			}

			return query;
		}

		public override IQueryable<TEntity> GetAll()
		{
			return GetAllIncluding();
		}

		public override IQueryable<TEntity> GetAllIncluding(
			params Expression<Func<TEntity, object>>[] propertySelectors)
		{
			var query = Table.AsQueryable();
			if (propertySelectors != null && propertySelectors.Length > 0)
			{
				foreach (var propertySelector in propertySelectors)
				{
					query = query.Include(propertySelector);
				}
			}

			return query;
		}

		public override TEntity Insert(TEntity entity)
		{
			return Table.Add(entity).Entity;
		}

		public override TEntity Update(TEntity entity)
		{
			AttachIfNot(entity);
			Context.Entry(entity).State = EntityState.Modified;
			return entity;
		}

		public override void Delete(TEntity entity)
		{
			AttachIfNot(entity);
			Table.Remove(entity);
		}

		public override void Delete(TPrimaryKey id)
		{
			var entity = FirstOrDefault(id);
			if (entity != null)
			{
				Delete(entity);
			}
		}

		protected virtual void AttachIfNot(TEntity entity)
		{
			var entry = Context.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
			if (entry != null)
			{
				return;
			}

			Table.Attach(entity);
		}
	}
}