using Core.Api.Exceptions;
using Core.Modules;

namespace Core.Api;

public class Configuration
{
    private readonly IDictionary<string, string> configuration = new Dictionary<string, string>();
    public readonly ContainerBuilder builder = new ContainerBuilder();

    private Configuration() => builder.RegisterModule<CoreModule>();

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

    public Database Connect() => Database.Connect(this, builder.Build().Resolve<IEnumerable<Database>>());

    public static Configuration Configure() => new Configuration();

    public override string? ToString() => string.Join(Environment.NewLine, configuration.Select(kv => $"{kv.Key} => {kv.Value}"));
}
