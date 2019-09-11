namespace IssueTracker.Core.Handlers
{
	using Autofac;
	using IssueTracker.Core.Handlers.Abstractions;
	using IssueTracker.Core.Handlers.Decorators;

	public class Module : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterGenericDecorator(
				typeof(LogDecorator<,>),
				typeof(QueryHandler<,>));

			builder.RegisterGenericDecorator(
				typeof(ValidationDecorator<,>),
				typeof(QueryHandler<,>));
		}
		
	}
}