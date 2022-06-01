namespace Core.Api;

public static class DefaultConfigurationExtensions
{
    public const string URL = "url";

    public static Configuration Url(this Configuration configuration, string value) => configuration.Set(URL, value);

    public static string GetUrl(this Configuration configuration) => configuration.Get(URL);
}
