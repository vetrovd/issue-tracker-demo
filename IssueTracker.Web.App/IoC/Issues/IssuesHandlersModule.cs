namespace IssueTracker.Web.App.IoC.Issues
{
	using Autofac;
	using IssueTracker.Issues.Handlers.CommandHandlers;
	using MediatR.Extensions.Autofac.DependencyInjection;

	public class IssuesHandlersModule: Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			var issueHandlers = typeof(CreateIssueHandler).Assembly;

			builder.AddMediatR(issueHandlers);

			builder.RegisterAssemblyTypes(issueHandlers).AsImplementedInterfaces();
		}
	}
}