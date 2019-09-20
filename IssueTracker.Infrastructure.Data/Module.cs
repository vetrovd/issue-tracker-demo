namespace IssueTracker.Infrastructure.Data
{
	using System.Reflection;
	using Autofac;

	public class Module : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(Module).GetTypeInfo().Assembly)
				.PublicOnly()
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}
	}
}