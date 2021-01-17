using artilectBigBro.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace artilectBigBro.Data
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public DbSet<Interest> Interests { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<Machine> Machines { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Badge> Badges { get; set; }
        public DbSet<Message> Messages { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne<User>(um => um.Sender)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.UserId);
        }*/
    }
}
