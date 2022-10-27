using Core.Api;
using Core.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Core.Tests.EntityFramework;

public class EmptyOptionsBuilder : IOptionsBuilder
{
    public DbContextOptions Build(DatabaseConfiguration configuration) => new DbContextOptionsBuilder().Options;
}
