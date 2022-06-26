using System;
using TaskTimer.Models;

namespace TaskTimer.Data
{
	public static class SeedData
	{

       
		
		public static async void EnsurePopulated(MauiAppBuilder builder)
        {


			AppDbContext context = builder.Services.BuildServiceProvider().CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any())
            {
				await context.Categories.AddRangeAsync(
					new Category { Name = "Medicatie" },
					new Category { Name = "Poetsen"}
					);
            }

			await context.SaveChangesAsync();

            if (!context.Tasks.Any())
            {
				await context.Tasks.AddRangeAsync(
					new Models.Task { Name = "Praktijk poetsen", Category = context.Categories.First(x => x.Name.Equals("Poetsen")) }
					);
            }

			await context.SaveChangesAsync();


		}
	}
}

