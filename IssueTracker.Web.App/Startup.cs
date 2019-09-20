namespace IssueTracker.Web.App
{
	using System.Reflection;
	using Autofac;
	using IssueTracker.Infrastructure.Data.Context;
	using IssueTracker.Issues.WebApi;
	using IssueTracker.Web.App.IoC;
	using IssueTracker.Web.App.IoC.Framework;
	using IssueTracker.Web.App.IoC.Infrastructure;
	using IssueTracker.Web.App.IoC.Issues;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Swashbuckle.AspNetCore.Swagger;
	using Module = IssueTracker.Users.WebApi.Module;

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
			services
				.AddMvc()
				.AddApplicationPart(typeof(IssueController).GetTypeInfo().Assembly)
				.AddApplicationPart(typeof(Module).GetTypeInfo().Assembly)
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddEntityFrameworkNpgsql()
				.AddDbContext<ApplicationDbContext>()
				.BuildServiceProvider();

			// Register the Swagger generator, defining 1 or more Swagger documents
			services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}); });

			services.ConfigureSwaggerGen(options => { options.CustomSchemaIds(x => x.FullName); });
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
			builder.RegisterBuildCallback(c => ApplicationContainer = c);

			builder.RegisterModule(new RegisterDecoratorsModule());
			builder.RegisterModule(new InfrastructureModule());

			builder.RegisterModule(new IssuesDomainModule());
			builder.RegisterModule(new IssuesHandlersModule());

			builder.RegisterModule(new WebAppModule());
			//builder.RegisterModule(new Issues.Handlers.Module());
			//builder.RegisterModule(new);

			builder.Register(c => ApplicationContainer).As<IContainer>().SingleInstance();
		}

		private IContainer ApplicationContainer { get; set; }

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

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Issue tracker API");
				c.RoutePrefix = "apidoc";
			});

			var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
			context.Database.Migrate();
		}
	}
}