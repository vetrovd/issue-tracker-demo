namespace IssueTracker.Framework.Abstractions.Data
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Threading.Tasks;
	using IssueTracker.Framework.Abstractions.Domain;

	public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
		where TEntity : DomainModel
	{
		public abstract IQueryable<TEntity> GetAll();

		public abstract IQueryable<TEntity> GetAllIncluding(
			params Expression<Func<TEntity, object>>[] propertySelectors);

		public virtual List<TEntity> GetAllList()
		{
			return GetAll().ToList();
		}

		public virtual Task<List<TEntity>> GetAllListAsync()
		{
			return Task.FromResult(GetAllList());
		}

		public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Where(predicate).ToList();
		}

		public virtual Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return Task.FromResult(GetAllList(predicate));
		}

		public virtual TEntity Get(TPrimaryKey id)
		{
			var entity = FirstOrDefault(id);
			return entity;
		}

		public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
		{
			var entity = await FirstOrDefaultAsync(id);
			return entity;
		}

		public virtual TEntity Single(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Single(predicate);
		}

		public virtual Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return Task.FromResult(Single(predicate));
		}

		public virtual TEntity FirstOrDefault(TPrimaryKey id)
		{
			return GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
		}

		public virtual Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
		{
			return Task.FromResult(FirstOrDefault(id));
		}

		public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().FirstOrDefault(predicate);
		}

		public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return Task.FromResult(FirstOrDefault(predicate));
		}

		public abstract TEntity Insert(TEntity entity);

		public virtual Task<TEntity> InsertAsync(TEntity entity)
		{
			return Task.FromResult(Insert(entity));
		}

		public abstract TEntity Update(TEntity entity);

		public virtual Task<TEntity> UpdateAsync(TEntity entity)
		{
			return Task.FromResult(Update(entity));
		}

		public virtual TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
		{
			var entity = Get(id);
			updateAction(entity);
			return entity;
		}

		public virtual async Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
		{
			var entity = await GetAsync(id);
			await updateAction(entity);
			return entity;
		}

		public abstract void Delete(TEntity entity);

		public virtual Task DeleteAsync(TEntity entity)
		{
			Delete(entity);
			return Task.CompletedTask;
		}

		public abstract void Delete(TPrimaryKey id);

		public virtual Task DeleteAsync(TPrimaryKey id)
		{
			Delete(id);
			return Task.CompletedTask;
		}

		public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
		{
			foreach (var entity in GetAllList(predicate))
			{
				Delete(entity);
			}
		}

		public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
		{
			var entities = await GetAllListAsync(predicate);

			foreach (var entity in entities)
			{
				await DeleteAsync(entity);
			}
		}

		public virtual int Count()
		{
			return GetAll().Count();
		}

		public virtual Task<int> CountAsync()
		{
			return Task.FromResult(Count());
		}

		public virtual int Count(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Count(predicate);
		}

		public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return Task.FromResult(Count(predicate));
		}

		// AbpRepositoryBase at:
		// https://github.com/aspnetboilerplate/aspnetboilerplate/blob/c0604b9b1347a3b9581bf97b4cae22db5b6bab1b/src/Abp/Domain/Repositories/AbpRepositoryBase.cs#L268
		protected virtual Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
		{
			var lambdaParam = Expression.Parameter(typeof(TEntity));

			var leftExpression = Expression.PropertyOrField(lambdaParam, "Id");

			Expression<Func<object>> closure = () => id;
			var rightExpression = Expression.Convert(closure.Body, leftExpression.Type);

			var lambdaBody = Expression.Equal(leftExpression, rightExpression);

			return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
		}
	}
}