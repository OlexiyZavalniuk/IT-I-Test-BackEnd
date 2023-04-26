using Microsoft.EntityFrameworkCore;
using System;

using Models;

namespace DB
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Book> Books { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>().HasData(
				new Book
				{
					Id = 1,
					Title = "Kobzar",
					Description = "Description",
					Pages = 234,
					Date = new DateTime(1992, 2, 18)
				},
				new Book
				{
					Id = 2,
					Title = "Harry Potter",
					Description = "Description",
					Pages = 435,
					Date = new DateTime(2008, 7, 21)
				},
				new Book
				{
					Id = 3,
					Title = "Sapiens. Brief history of human",
					Description = "Description",
					Pages = 549,
					Date = new DateTime(2019, 10, 8)
				});
		}
	}
}
