namespace IssueTracker.Web.App.IoC.Issues
{
	using Autofac;
	using IssueTracker.Issues.Domain.Issue;
	using MediatR.Extensions.Autofac.DependencyInjection;

	public class IssuesDomainModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			var issueDomain = typeof(Issue).Assembly;

			builder.AddMediatR(issueDomain);
			builder.RegisterAssemblyTypes(issueDomain).AsImplementedInterfaces();
		}
	}
}