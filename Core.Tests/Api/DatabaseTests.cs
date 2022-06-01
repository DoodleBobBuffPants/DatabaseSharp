using Autofac;
using Core.Api;
using Core.Api.Exceptions;
using NUnit.Framework;

namespace Core.Tests.Api;

public class DatabaseTests
{
    [Test]
    public void failsOnIncompleteConfiguration()
    {
        var e = Assert.Throws<NoDatabaseFoundException>(() => GetDefaultConfiguration().Connect());
        Assert.That(e?.Message == $"No database found for the provided configuration:{Environment.NewLine}", $"Expected : {e?.Message}");
    }

    private Configuration GetDefaultConfiguration()
    {
        var configuration = Configuration.Configure();
        configuration.builder.RegisterType<EntityFrameworkDatabase>().As<IDatabase>();
        configuration.builder.RegisterType<EmptyOptionsBuilder>().As<IOptionsBuilder>();
        return configuration;
    }
}
