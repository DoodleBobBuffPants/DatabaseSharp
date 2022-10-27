using Core.Api.Exceptions;

namespace Core.Api;

public interface IDatabase : IDisposable
{
    internal static IDatabase Connect(DatabaseConfiguration configuration, IEnumerable<IDatabase> databases)
    {
        var database = databases.FirstOrDefault(d => d.IsConfigured() && d.CanConnect());
        if (database == default) throw new NoDatabaseFoundException(configuration);
        return database;
    }

    public bool IsConfigured();

    public bool CanConnect();

    public String GetName();
}
