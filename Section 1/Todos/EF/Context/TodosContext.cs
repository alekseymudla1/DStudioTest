using EF.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.Context
{
	public class TodosContext : DbContext
	{
		public TodosContext(DbContextOptions<TodosContext> options)
			: base(options)
		{
		}

		public DbSet<Todo> Todos { get; set; }

		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Todo>().ToTable("Todo");
			//modelBuilder.Entity<User>().ToTable("User");
		}

	}
}
