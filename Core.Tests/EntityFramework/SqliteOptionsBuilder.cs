using Core.Api;
using Core.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Core.Tests.EntityFramework;

public class SqliteOptionsBuilder : IOptionsBuilder
{
    public DbContextOptions Build(DatabaseConfiguration configuration) => new DbContextOptionsBuilder().UseSqlite(configuration.GetUrl()).Options;
}
