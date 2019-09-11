using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IssueTracker.Web.App
{
	using System.Reflection;
	using Autofac;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var issuesWebApiAssembly = typeof(Features.Issues.WebApi.Module).GetTypeInfo().Assembly;

			services
				.AddMvc()
				.AddApplicationPart(issuesWebApiAssembly)
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddLogging();
		}

		// ConfigureContainer is where you can register things directly
		// with Autofac. This runs after ConfigureServices so the things
		// here will override registrations made in ConfigureServices.
		// Don't build the container; that gets done for you. If you
		// need a reference to the container, you need to use the
		// "Without ConfigureContainer" mechanism shown later.
		public void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterModule(new Core.Handlers.Module());

			builder.RegisterModule(new Features.Issues.Domain.Module());
			builder.RegisterModule(new Features.Issues.Handlers.Module());
			builder.RegisterModule(new Features.Issues.WebApi.Module());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			// app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}