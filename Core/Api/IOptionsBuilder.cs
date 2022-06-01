using Microsoft.EntityFrameworkCore;

namespace Core.Api;

public interface IOptionsBuilder
{
    public DbContextOptions Build(Configuration configuration);
}
