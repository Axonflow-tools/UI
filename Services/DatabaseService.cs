using Microsoft.EntityFrameworkCore;
using UI.Data;

namespace UI.Services;

public static class DatabaseService
{
    private static AppDbContext? _db;
    
    public static AppDbContext Db 
    {
        get
        {
            if (_db == null)
            {
                _db = new AppDbContext();
            }
            return _db;
        }
    }
    public static void InitializeDatabase()
    {
        using var context = new AppDbContext();
        
        // Apply pending migrations (creates DB if it doesn't exist)
        context.Database.Migrate();

    }
}