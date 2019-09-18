namespace IssueTracker.Users.WebApi
{
	using Autofac;
	using MediatR.Extensions.Autofac.DependencyInjection;

	public class Module : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.AddMediatR(typeof(Module).Assembly);
		}
	}
}