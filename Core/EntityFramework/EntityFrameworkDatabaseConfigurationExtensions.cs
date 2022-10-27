using Autofac.Core;
using Core.Api;

namespace Core.EntityFramework;

public static class EntityFrameworkDatabaseConfigurationExtensions
{
    private const string Url = "url";

    public static DatabaseConfiguration SetUrl(this DatabaseConfiguration configuration, string value) => configuration.Set(Url, value);

    public static string GetUrl(this DatabaseConfiguration configuration) => configuration.Get(Url);

    public static bool IsConfigured(this DatabaseConfiguration configuration) => configuration.Exists(Url) && configuration.ContainerBuilder.ComponentRegistryBuilder.IsRegistered(new TypedService(typeof(IOptionsBuilder)));
}
