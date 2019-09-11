using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace IssueTracker.Web.App
{
	using Autofac.Extensions.DependencyInjection;

	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost
				.CreateDefaultBuilder(args)
				.ConfigureServices(services => services.AddAutofac())
				.ConfigureLogging((hostingContext, logging) =>
				{
					logging.AddConsole(options => options.IncludeScopes = true);
				})
				.UseStartup<Startup>()
				.CaptureStartupErrors(true);
	}
}