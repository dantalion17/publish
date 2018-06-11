using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ThinksProject.DataClasses;

namespace ThinksProject.Data
{
	public class DataDbContext : DbContext
	{
		private readonly IConfiguration _configuration;

		public DataDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
		{
			_configuration = configuration;
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<PostInformation> PostInformations { get; set; }
		public DbSet<UserSetting> UserSettings { get; set; }
		public DbSet<ActiveList> ActiveLists { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.Entity<PostInformation>()
           .HasOne(p => p.Posts)
           .WithOne(t => t.PostInformation)
           .OnDelete(DeleteBehavior.Cascade);
            
            base.OnModelCreating(builder);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgresConnection"),
				m => m.MigrationsAssembly("ThinksProject"));
		}
	}
}
