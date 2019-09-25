namespace IssueTracker.Contexts.Core.Abstractions.Security
{
	using System.Threading.Tasks;
	using IssueTracker.Contexts.Core.Abstractions.Domain;
	using MediatR;

	public interface IPermissionManager
	{
		Task<bool> IsPermittedAsync<TOut> (IRequest<TOut> request);
	}
}