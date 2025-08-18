using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Create DB and seed data
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.EnsureCreated();
                if (!db.Items.Any())
                {
                    db.Items.AddRange(
                        new WebApi.Models.Item { Name = "Notebook", IsComplete = false },
                        new WebApi.Models.Item { Name = "Buy milk", IsComplete = true },
                        new WebApi.Models.Item { Name = "Read docs", IsComplete = false }
                    );
                    db.SaveChanges();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}