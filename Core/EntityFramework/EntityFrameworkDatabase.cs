using Core.Api;
using Microsoft.EntityFrameworkCore;

namespace Core.EntityFramework;

public class EntityFrameworkDatabase : DbContext, IDatabase
{
    private readonly DatabaseConfiguration _configuration;

    public EntityFrameworkDatabase(DatabaseConfiguration configuration, IOptionsBuilder builder) : base(builder.Build(configuration)) => _configuration = configuration;

    public bool IsConfigured() => _configuration.IsConfigured();

    public bool CanConnect() => Database.CanConnect();

    public String GetName() => Database.ProviderName ?? "";
}
