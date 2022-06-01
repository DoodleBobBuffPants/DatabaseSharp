using Core.Api.Exceptions;
using Core.Modules;

namespace Core.Api;

public class Configuration : IDisposable
{
    private readonly IDictionary<string, string> configuration = new Dictionary<string, string>();
    public readonly ContainerBuilder builder = new ContainerBuilder();
    private IContainer? services;

    private Configuration()
    {
        builder.RegisterModule<CoreModule>();
        builder.RegisterInstance(this).As<Configuration>();
    }

    public static Configuration Configure() => new Configuration();

    public Configuration Set(string key, string value)
    {
        configuration.Add(key, value);
        return this;
    }

    public string Get(string key)
    {
        if (!configuration.ContainsKey(key)) throw new NoParameterFoundException(key);
        return configuration[key];
    }

    public Database Connect()
    {
        services = builder.Build();
        return Database.Connect(services.Resolve<Configuration>(), services.Resolve<IEnumerable<Database>>());
    }

    public void Dispose() => services?.Dispose();

    public override string? ToString() => string.Join(Environment.NewLine, configuration.Select(kv => $"{kv.Key} => {kv.Value}"));
}
