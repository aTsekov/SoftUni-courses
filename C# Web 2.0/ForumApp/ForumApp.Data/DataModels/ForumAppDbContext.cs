
using ForumApp.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data.DataModels
{
	public class ForumAppDbContext :DbContext
	{
		public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
			:base(options) // With this CTOR we will be able to inject the options in the DB context in the DI in the programs class.
		{
		}

		public DbSet<Post> Posts { get; init; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new PostEntityConfiguration()); //Apply the configuration created to the seeding of the DB
			
			base.OnModelCreating(modelBuilder);
		}
	}
}
