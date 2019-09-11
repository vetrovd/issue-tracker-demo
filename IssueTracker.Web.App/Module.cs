namespace IssueTracker.Web.App
{
	using System.Reflection;
	using Autofac;
	using IssueTracker.Features.Issues.Domain.Commands;
	using MediatR;

	public class Module : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
		}
	}
}