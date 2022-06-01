using Microsoft.EntityFrameworkCore;

namespace Core.Api;

public class SqliteOptionsBuilder : IOptionsBuilder
{
    public DbContextOptions Build(Configuration configuration) => new DbContextOptionsBuilder().UseSqlite(configuration.GetUrl()).Options;
}
