using Autofac;
using Core.Api.Exceptions;
using Core.Modules;

namespace Core.Api;

public class DatabaseConfiguration : IDisposable
{
    public readonly ContainerBuilder ContainerBuilder = new ContainerBuilder();
    private readonly IDictionary<string, string> _configuration = new Dictionary<string, string>();
    private IContainer? _container;

    private DatabaseConfiguration()
    {
        ContainerBuilder.RegisterModule<CoreModule>();
        ContainerBuilder.RegisterInstance(this).As<DatabaseConfiguration>();
    }

    public static DatabaseConfiguration Configure() => new DatabaseConfiguration();

    public DatabaseConfiguration Set(string key, string value)
    {
        _configuration.Add(key, value);
        return this;
    }

    public string Get(string key)
    {
        if (!Exists(key)) throw new OptionNotFoundException(key);
        return _configuration[key];
    }

    public bool Exists(string key) => _configuration.ContainsKey(key);

    public IDatabase Connect()
    {
        _container = ContainerBuilder.Build();
        return IDatabase.Connect(_container.Resolve<DatabaseConfiguration>(), _container.Resolve<IEnumerable<IDatabase>>());
    }

    public void Dispose() => _container?.Dispose();

    public override string ToString() => string.Join(Environment.NewLine, _configuration.Select(kv => $"{kv.Key} => {kv.Value}"));
}
