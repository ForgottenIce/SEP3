using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace EfcEmployeeDataAccess; 

public class DataContext : DbContext {
	public DbSet<Employee> Employees { get; set; }
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
		optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/data.db");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.Entity<Employee>().HasIndex(e => e.Username).IsUnique();
		modelBuilder.Entity<Employee>().HasKey(e => e.Id);
	}
}