namespace IssueTracker.Infrastructure.Data.Context
{
	using IssueTracker.Identity.Domain;
	using IssueTracker.Issues.Domain.Issue;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	public class ApplicationDbContext : IdentityDbContext<User, Role, int>
	{
		public DbSet<Issue> Issues { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseNpgsql("Host=localhost;Database=dve_test;Username=postgres;Password=root");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Issue>().ToTable("Issue");
			
			modelBuilder.Entity<Issue>().Property(issue => issue.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<Issue>().HasKey(p => p.Id).HasName("project_pkey");

			modelBuilder.Entity<Issue>().OwnsOne(issue => issue.Name);
			modelBuilder.Entity<Issue>().OwnsOne(issue => issue.Description);
			modelBuilder.Entity<Issue>().OwnsOne(issue => issue.Status);
		}
	}
}