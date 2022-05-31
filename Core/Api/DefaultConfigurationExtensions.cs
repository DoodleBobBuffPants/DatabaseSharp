namespace Core.Api;

public static class DefaultConfigurationExtensions
{
    public const string URL = "url";
    public const string USERNAME = "username";
    public const string PASSWORD = "password";

    public static Configuration Url(this Configuration configuration, string value) => configuration.Set(URL, value);

    public static string GetUrl(this Configuration configuration) => configuration.Get(URL);

    public static Configuration Username(this Configuration configuration, string value) => configuration.Set(USERNAME, value);

    public static string GetUsername(this Configuration configuration) => configuration.Get(USERNAME);

    public static Configuration Password(this Configuration configuration, string value) => configuration.Set(PASSWORD, value);

    public static string GetPassword(this Configuration configuration) => configuration.Get(PASSWORD);
}
