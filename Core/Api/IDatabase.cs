using Core.Api.Exceptions;

namespace Core.Api;

public interface IDatabase : IDisposable
{
    internal static IDatabase Connect(Configuration configuration, IEnumerable<IDatabase> databases)
    {
        var database = databases
                .Where(d => d.IsConfigured())
                .Where(d => d.CanConnect())
                .FirstOrDefault();

        if (database == default) throw new NoDatabaseFoundException(configuration);

        return database;
    }

    public bool IsConfigured();

    public bool CanConnect();

    public String GetName();
}
