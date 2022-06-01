using Microsoft.EntityFrameworkCore;

namespace Core.Api;

public class EntityFrameworkDatabase : DbContext, IDatabase
{
    private readonly Configuration configuration;

    public EntityFrameworkDatabase(Configuration configuration, IOptionsBuilder builder) : base(builder.Build(configuration)) => this.configuration = configuration;

    public bool IsConfigured() => configuration.ContainsKey(DefaultConfigurationExtensions.URL);

    public bool CanConnect() => Database.CanConnect();

    public String GetName() => Database.ProviderName ?? "";
}
