namespace IssueTracker.Framework.Abstractions.Data
{
	using System;
	using System.Threading.Tasks;
	using IssueTracker.Framework.Abstractions.Domain;

	public interface IUnitOfWork : IDisposable
	{
		IRepository<T> Repository<T>() where T : DomainModel;

		/// <summary>
		///     Saves all changes until now in this unit of work.
		///     This method may be called to apply changes whenever needed.
		///     Note that if this unit of work is transactional, saved changes are also rolled back if transaction is rolled back.
		///     No explicit call is needed to SaveChanges generally,
		///     since all changes saved at end of a unit of work automatically.
		/// </summary>
		void SaveChanges();

		/// <summary>
		///     Saves all changes until now in this unit of work.
		///     This method may be called to apply changes whenever needed.
		///     Note that if this unit of work is transactional, saved changes are also rolled back if transaction is rolled back.
		///     No explicit call is needed to SaveChanges generally,
		///     since all changes saved at end of a unit of work automatically.
		/// </summary>
		Task SaveChangesAsync();
	}
}