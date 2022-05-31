using Core.Api.Exceptions;

namespace Core.Api;

public abstract class Database
{
    internal static Database Connect(Configuration configuration, IEnumerable<Database> databases)
    {
        var database = databases
                .Where(d => d.IsConfigured(configuration))
                .Where(d => d.CanConnect(configuration))
                .FirstOrDefault();

        if (database == default) throw new NoDatabaseFoundException(configuration);

        database.Init(configuration);
        return database;
    }

    protected abstract void Init(Configuration configuration);

    protected abstract bool IsConfigured(Configuration configuration);

    protected abstract bool CanConnect(Configuration configuration);

    public abstract String getName();
}
