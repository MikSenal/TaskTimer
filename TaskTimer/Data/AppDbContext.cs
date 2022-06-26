using System;
using Microsoft.EntityFrameworkCore;
using TaskTimer.Models;

namespace TaskTimer.Data
{
	public class AppDbContext : DbContext
    {

        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }



        public AppDbContext()
    {
        SQLitePCL.Batteries_V2.Init();

        this.Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "tasks.db3");

        optionsBuilder
            .UseSqlite($"Filename={dbPath}");
    }
}
}

