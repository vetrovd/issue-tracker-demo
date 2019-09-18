namespace IssueTracker.Web.App.IoC.Infrastructure
{
	using Autofac;
	using IssueTracker.Framework.Abstractions.Data;
	using IssueTracker.Infrastructure.Data;
	using IssueTracker.Infrastructure.Data.Context;

	public class InfrastructureModule: Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			var assembly = typeof(ApplicationDbContext).Assembly;

			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().InstancePerDependency();



			builder.RegisterGeneric(typeof(ApplicationRepository<>))
				.As(typeof(IRepository<>))
				.InstancePerDependency();
		}
	}
}