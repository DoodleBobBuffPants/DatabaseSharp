using Microsoft.EntityFrameworkCore;

namespace Core.Api;

public class EmptyOptionsBuilder : IOptionsBuilder
{
    public DbContextOptions Build(Configuration configuration) => new DbContextOptionsBuilder().Options;
}
