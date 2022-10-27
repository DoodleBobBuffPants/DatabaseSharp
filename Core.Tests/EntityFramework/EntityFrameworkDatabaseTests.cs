using Autofac;
using Core.Api;
using Core.Api.Exceptions;
using Core.EntityFramework;
using NUnit.Framework;

namespace Core.Tests.EntityFramework;

public class EntityFrameworkDatabaseTests
{
    [Test]
    public void GetsDatabaseName()
    {
        var databaseName = GetSqliteDatabaseConfiguration().Connect().GetName();
        Assert.AreEqual("Microsoft.EntityFrameworkCore.Sqlite", databaseName);
    }

    [Test]
    public void failsOnEmptyConfiguration()
    {
        var e = Assert.Throws<NoDatabaseFoundException>(() => GetEmptyDatabaseConfiguration().Connect());
        Assert.That(e?.Message == $"No database found for the provided configuration:{Environment.NewLine}", $"Actual : {e?.Message}");
    }

    private DatabaseConfiguration GetSqliteDatabaseConfiguration()
    {
        var configuration = DatabaseConfiguration.Configure();
        configuration.ContainerBuilder.RegisterType<SqliteOptionsBuilder>().As<IOptionsBuilder>();
        return configuration.SetUrl("Filename=:memory:");
    }

    private DatabaseConfiguration GetEmptyDatabaseConfiguration()
    {
        var configuration = DatabaseConfiguration.Configure();
        configuration.ContainerBuilder.RegisterType<EmptyOptionsBuilder>().As<IOptionsBuilder>();
        return configuration;
    }
}
