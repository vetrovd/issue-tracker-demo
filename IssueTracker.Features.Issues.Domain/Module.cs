namespace IssueTracker.Features.Issues.Domain
{
	using System.Reflection;
	using Autofac;
	using FluentValidation;
	using IssueTracker.Features.Issues.Domain.Queries;
	using IssueTracker.Features.Issues.Domain.Validators;
	using MediatR.Extensions.Autofac.DependencyInjection;

	public class Module: Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.AddMediatR(typeof(Module).Assembly);
			builder.RegisterAssemblyTypes(typeof(Module).GetTypeInfo().Assembly).AsImplementedInterfaces();
		}
	}
}