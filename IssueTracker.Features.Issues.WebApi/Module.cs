namespace IssueTracker.Features.Issues.WebApi
{
	using System.Reflection;
	using Autofac;
	using MediatR;
	using MediatR.Extensions.Autofac.DependencyInjection;

	public class Module : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.AddMediatR(typeof(Module).Assembly);
		}
	}
}