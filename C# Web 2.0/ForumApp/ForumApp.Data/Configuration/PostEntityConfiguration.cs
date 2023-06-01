using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApp.Data.DataModels;
using ForumApp.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Data.Configuration
{
	public class PostEntityConfiguration :IEntityTypeConfiguration<Post>
	{
		//In this class we configure the seeding of the data. TO keep it clean we placed the Seeder with the data in a separate class
		private readonly PostSeeder seeder; //Inject the PostSeeder class which contains the GeneratePosts method

		public PostEntityConfiguration()
		{
			this.seeder = new PostSeeder();
		}
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.HasData(this.seeder.GeneratePosts());
		}
	}
}
