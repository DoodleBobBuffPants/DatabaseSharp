using Core.Api;
using Microsoft.EntityFrameworkCore;

namespace Core.EntityFramework;

public interface IOptionsBuilder
{
    public DbContextOptions Build(DatabaseConfiguration configuration);
}
