using Autofac;
using Core.Api;
using NUnit.Framework;

namespace Core.Tests.Databases;

public class EntityFrameworkDatabaseTests
{
    [Test]
    public void GetsDatabaseName()
    {
        var databaseName = GetDefaultConfiguration().Connect().GetName();
        Assert.AreEqual("Microsoft.EntityFrameworkCore.Sqlite", databaseName);
    }

    private Configuration GetDefaultConfiguration()
    {
        var configuration = Configuration.Configure();
        configuration.builder.RegisterType<EntityFrameworkDatabase>().As<IDatabase>();
        configuration.builder.RegisterType<SqliteOptionsBuilder>().As<IOptionsBuilder>();
        return configuration.Url("Filename=:memory:");
    }
}
