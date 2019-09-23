namespace IssueTracker.App.IoC.Infrastructure
{
	using Autofac;
	using IssueTracker.Framework.Abstractions.Data;
	using IssueTracker.Infrastructure.Data.Context;
	using IssueTracker.Infrastructure.Data.Repository;
	using IssueTracker.Infrastructure.Data.UoW;

	public class InfrastructureModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			/*builder.RegisterGeneric(typeof(ApplicationRepository<>))
				.As(typeof(IRepository<>))
				.InstancePerLifetimeScope();*/

			builder.RegisterType<UnitOfWork>().AsImplementedInterfaces().InstancePerLifetimeScope();
			//builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
		}
	}
}