namespace IssueTracker.Framework.Abstractions.Security
{
	using System.Threading.Tasks;
	using IssueTracker.Framework.Abstractions.Domain;
	using MediatR;

	public interface IPermissionManager
	{
		Task<bool> IsPermittedAsync<TOut> (IRequest<TOut> request);
	}
}