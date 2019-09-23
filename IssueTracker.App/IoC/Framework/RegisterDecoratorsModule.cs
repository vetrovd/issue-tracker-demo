namespace IssueTracker.App.IoC.Framework
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using Autofac;
	using AutoMapper;
	using FluentValidation;
	using IssueTracker.Framework.Abstractions.Handlers;
	using IssueTracker.Framework.Decorators;
	using IssueTracker.Framework.Decorators.Interfaces;
	using IssueTracker.Issues.Handlers;
	using MediatR;
	using MediatR.Extensions.Autofac.DependencyInjection;
	using Module = Autofac.Module;

	public class RegisterDecoratorsModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			var assemblies = Directory
				.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
				.Where(filePath => Path.GetFileName(filePath).StartsWith("IssueTracker"))
				.Select(Assembly.LoadFrom)
				.ToArray();


			var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile<MappingProfile>(); });
			var mapper = mappingConfig.CreateMapper();
			builder.RegisterInstance(mapper).As<IMapper>().SingleInstance();

			//register SaveChanges (+ publishing events) for all commands
			builder.RegisterGenericDecorator(
				typeof(SaveChangesDecorator<,>),
				typeof(IRequestHandler<,>),
				context => context.ImplementationType.GetInterfaces().Contains(typeof(IWithSaveChanges))
			);

			//register logging only for handlers with IWithLogging
			builder.RegisterGenericDecorator(
				typeof(LogDecorator<,>),
				typeof(IRequestHandler<,>),
				context => context.ImplementationType.GetInterfaces().Contains(typeof(IWithLogging))
			);

			//register validation for every query/command
			builder.RegisterGenericDecorator(
				typeof(ValidationDecorator<,>),
				typeof(IRequestHandler<,>)
			);



			builder.AddMediatR(assemblies);

			builder.RegisterGeneric(typeof(AbstractValidator<>)).AsSelf().InstancePerLifetimeScope();

			// builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces().InstancePerLifetimeScope();

			//builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
		}
	}
}