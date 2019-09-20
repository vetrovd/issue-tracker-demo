namespace IssueTracker.Infrastructure.Data.Context
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Design;


		public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
		{
			public ApplicationDbContext CreateDbContext(string[] args)
			{
				var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
				optionsBuilder.UseNpgsql("Host=localhost;Database=dve_test;Username=postgres;Password=root");

				return new ApplicationDbContext(optionsBuilder.Options);
			}
		}
}