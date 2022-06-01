using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Api;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Core.Modules;

public class CoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Populate(GetServices());
        builder.RegisterType<EntityFrameworkDatabase>().As<IDatabase>();
    }

    private ServiceCollection GetServices()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(builder => builder.AddConsole());
        return serviceCollection;
    }
}
