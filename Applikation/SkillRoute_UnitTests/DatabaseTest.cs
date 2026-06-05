using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SkillRoute_BlazorApp.Infrastructure;

namespace SkillRoute_UnitTests;

public abstract class DatabaseTest : IDisposable
{
    private readonly SqliteConnection connection;
    protected readonly SkillRouteDbContext DbContext;

    protected DatabaseTest()
    {
        connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<SkillRouteDbContext>()
            .UseSqlite(connection)
            .Options;

        DbContext = new SkillRouteDbContext(options);
        DbContext.Database.EnsureCreated();
    }

    public void Dispose()
    {
        DbContext.Dispose();
        connection.Dispose();
    }
}