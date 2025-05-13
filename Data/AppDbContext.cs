using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;
using UI.Data.Models;

namespace UI.Data;

public class AppDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={GetDatabasePath()}");
    }

    public static string GetDatabasePath()
    {
        // Get platform-specific application data folder
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var appName = Assembly.GetEntryAssembly()?.GetName().Name ?? "Axonflow";
        
        // Create application-specific folder if it doesn't exist
        var appFolder = Path.Combine(appData, appName);
        Directory.CreateDirectory(appFolder);
        return Path.Combine(appFolder, "app.db");
    }
}