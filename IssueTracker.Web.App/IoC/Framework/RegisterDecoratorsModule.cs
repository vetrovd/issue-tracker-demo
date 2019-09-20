namespace IssueTracker.Web.App.IoC.Framework
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using Autofac;
	using AutoMapper;
	using IssueTracker.Framework.Abstractions.Domain;
	using IssueTracker.Framework.Decorators;
	using IssueTracker.Framework.Decorators.Interfaces;
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


			var mappingConfig = new MapperConfiguration(mc =>
			{
				//mc.AddProfile<MappingProfile>();
			});
			var mapper = mappingConfig.CreateMapper();
			builder.RegisterInstance(mapper).As<IMapper>().SingleInstance();


			builder.RegisterGenericDecorator(
				typeof(LogDecorator<,>),
				typeof(IRequestHandler<,>),
				context => context.ImplementationType.GetInterfaces().Contains(typeof(IWithLogging))
			);

			builder.RegisterGenericDecorator(
				typeof(ValidationDecorator<,>),
				typeof(IRequestHandler<,>),
				context => context.ImplementationType.GetInterfaces().Contains(typeof(IWithValidation))
			);

			var assembly = typeof(DomainModel).Assembly;
			builder.AddMediatR(assembly);
		}
	}
}