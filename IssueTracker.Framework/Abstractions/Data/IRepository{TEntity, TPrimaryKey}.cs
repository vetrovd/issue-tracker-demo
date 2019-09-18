namespace IssueTracker.Framework.Abstractions.Data
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Threading.Tasks;
	using IssueTracker.Framework.Abstractions.Domain;

	public interface IRepository<TEntity, TPrimaryKey> where TEntity : DomainModel
	{

		IQueryable<TEntity> GetAll();

		IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

		List<TEntity> GetAllList();

		Task<List<TEntity>> GetAllListAsync();

		List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

		Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);

		TEntity Get(TPrimaryKey id);

		Task<TEntity> GetAsync(TPrimaryKey id);

		TEntity Single(Expression<Func<TEntity, bool>> predicate);

		Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

		TEntity FirstOrDefault(TPrimaryKey id);

		Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);

		/// <summary>
		/// Gets an entity with given given predicate or null if not found.
		/// </summary>
		/// <param name="predicate">Predicate to filter entities</param>
		TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

		/// <summary>
		/// Gets an entity with given given predicate or null if not found.
		/// </summary>
		/// <param name="predicate">Predicate to filter entities</param>
		Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

		/// <summary>
		/// Inserts a new entity.
		/// </summary>
		/// <param name="entity">Inserted entity</param>
		TEntity Insert(TEntity entity);

		/// <summary>
		/// Inserts a new entity.
		/// </summary>
		/// <param name="entity">Inserted entity</param>
		Task<TEntity> InsertAsync(TEntity entity);

		/// <summary>
		/// Updates an existing entity.
		/// </summary>
		/// <param name="entity">Entity</param>
		TEntity Update(TEntity entity);

		/// <summary>
		/// Updates an existing entity. 
		/// </summary>
		/// <param name="entity">Entity</param>
		Task<TEntity> UpdateAsync(TEntity entity);

		/// <summary>
		/// Updates an existing entity.
		/// </summary>
		/// <param name="id">Id of the entity</param>
		/// <param name="updateAction">Action that can be used to change values of the entity</param>
		/// <returns>Updated entity</returns>
		TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);

		/// <summary>
		/// Updates an existing entity.
		/// </summary>
		/// <param name="id">Id of the entity</param>
		/// <param name="updateAction">Action that can be used to change values of the entity</param>
		/// <returns>Updated entity</returns>
		Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);

		/// <summary>
		/// Deletes an entity.
		/// </summary>
		/// <param name="entity">Entity to be deleted</param>
		void Delete(TEntity entity);

		/// <summary>
		/// Deletes an entity.
		/// </summary>
		/// <param name="entity">Entity to be deleted</param>
		Task DeleteAsync(TEntity entity);

		/// <summary>
		/// Deletes an entity by primary key.
		/// </summary>
		/// <param name="id">Primary key of the entity</param>
		void Delete(TPrimaryKey id);

		/// <summary>
		/// Deletes an entity by primary key.
		/// </summary>
		/// <param name="id">Primary key of the entity</param>
		Task DeleteAsync(TPrimaryKey id);

		/// <summary>
		/// Deletes many entities by function.
		/// Notice that: All entities fits to given predicate are retrieved and deleted.
		/// This may cause major performance problems if there are too many entities with
		/// given predicate.
		/// </summary>
		/// <param name="predicate">A condition to filter entities</param>
		void Delete(Expression<Func<TEntity, bool>> predicate);

		/// <summary>
		/// Deletes many entities by function.
		/// Notice that: All entities fits to given predicate are retrieved and deleted.
		/// This may cause major performance problems if there are too many entities with
		/// given predicate.
		/// </summary>
		/// <param name="predicate">A condition to filter entities</param>
		Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

		/// <summary>
		/// Gets count of all entities in this repository.
		/// </summary>
		/// <returns>Count of entities</returns>
		int Count();

		/// <summary>
		/// Gets count of all entities in this repository.
		/// </summary>
		/// <returns>Count of entities</returns>
		Task<int> CountAsync();

		/// <summary>
		/// Gets count of all entities in this repository based on given <paramref name="predicate"/>.
		/// </summary>
		/// <param name="predicate">A method to filter count</param>
		/// <returns>Count of entities</returns>
		int Count(Expression<Func<TEntity, bool>> predicate);

		/// <summary>
		/// Gets count of all entities in this repository based on given <paramref name="predicate"/>.
		/// </summary>
		/// <param name="predicate">A method to filter count</param>
		/// <returns>Count of entities</returns>
		Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

	}
}