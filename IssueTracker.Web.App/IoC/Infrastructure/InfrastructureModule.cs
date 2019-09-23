namespace IssueTracker.Web.App.IoC.Infrastructure
{
	using Autofac;
	using IssueTracker.Framework.Abstractions.Data;
	using IssueTracker.Infrastructure.Data.Context;
	using IssueTracker.Infrastructure.Data.Repository;

	public class InfrastructureModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterGeneric(typeof(ApplicationRepository<>))
				.As(typeof(IRepository<>))
				.InstancePerDependency();
		}
	}
}