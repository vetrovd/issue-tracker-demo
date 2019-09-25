namespace IssueTracker.App
{
	using System.Reflection;
	using Autofac;
	using IssueTracker.App.IoC;
	using IssueTracker.App.IoC.Framework;
	using IssueTracker.App.IoC.Infrastructure;
	using IssueTracker.Contexts.Core.WebApi.Middleware.Exceptions;
	using IssueTracker.Contexts.Identity.Domain;
	using IssueTracker.Infrastructure.Data.Context;
	using IssueTracker.Contexts.Issues.WebApi;
	using IssueTracker.Users.WebApi;
	using Microsoft.AspNetCore.Authentication.Cookies;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Swashbuckle.AspNetCore.Swagger;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		private IContainer ApplicationContainer { get; set; }


		public void ConfigureServices(IServiceCollection services)
		{

			services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>();

			services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedEmail = true);
			services.AddAuthorization(ConfigurePolicy.AddPolicy);
			services.AddAuthentication().AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

			services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}); });
			services.ConfigureSwaggerGen(options => { options.CustomSchemaIds(x => x.FullName); });

			services.AddLogging();

			services
				.AddMvc()
				.AddApplicationPart(typeof(IssueController).GetTypeInfo().Assembly)
				.AddApplicationPart(typeof(MembersController).GetTypeInfo().Assembly)
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterBuildCallback(c => ApplicationContainer = c);

			builder.RegisterModule(new RegisterDecoratorsModule());
			builder.RegisterModule(new InfrastructureModule());

			builder.RegisterModule(new WebAppModule());
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseExceptionHandler("/error");

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
				app.UseHttpsRedirection();
			}

			app.UseHttpStatusCodeExceptionMiddleware();

			app.UseMvc();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Issue tracker API");
				c.RoutePrefix = "apidoc";
			});

			var dbContext = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
			dbContext.Database.Migrate();
		}
	}
}