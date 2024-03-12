using FlyApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlyApp.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Flight> Flights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // using var physicalConnection = new SqliteConnection("Filename=app.db");
        // physicalConnection.Open();
        //
        // optionsBuilder.UseSqlite(physicalConnection);
        // optionsBuilder.UseSqlite("Data Source=app.db;");
        
        // تنظیم مسیر و نام فایل دیتابیس
        var dbPath = Path.Combine(Environment.CurrentDirectory, "app.db");

        // استفاده از SQLite به عنوان پرووایدر پایگاه داده
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}