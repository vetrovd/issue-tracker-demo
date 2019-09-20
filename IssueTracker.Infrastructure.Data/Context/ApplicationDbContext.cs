namespace IssueTracker.Infrastructure.Data.Context
{
	using IssueTracker.Identity.Domain;
	using IssueTracker.Issues.Domain.Issue;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	public class ApplicationDbContext : IdentityDbContext<User, Role, int>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Issue> Issues { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Database=dve_test;Username=postgres;Password=root");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Issue>().ToTable("Issue");

			modelBuilder.Entity<Issue>().Property(issue => issue.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<Issue>().HasKey(p => p.Id).HasName("project_pkey");

			modelBuilder.Entity<Issue>().OwnsOne(issue => issue.Name, name =>
				{
					name.Property(n => n.Value);
				});
			
			modelBuilder.Entity<Issue>().OwnsOne(issue => issue.Description, description =>
				{
					description.Property(d => d.Value);
				});

			modelBuilder.Entity<Issue>().OwnsOne(issue => issue.Status, status =>
			{
				// status.Property(s => s.)
			});
		}
	}
}