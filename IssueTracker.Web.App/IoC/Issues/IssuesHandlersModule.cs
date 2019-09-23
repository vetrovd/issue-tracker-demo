namespace IssueTracker.Web.App.IoC.Issues
{
	using Autofac;
	using IssueTracker.Issues.Handlers.CommandHandlers;
	using MediatR.Extensions.Autofac.DependencyInjection;

	public class IssuesHandlersModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
		}
	}
}