using Autofac;
using Core.Modules;
using Microsoft.Extensions.Logging;

using var container = BuildContainer();
var logger = container.Resolve<ILogger<Program>>();
logger.LogInformation("Good morning world!");

static IContainer BuildContainer()
{
    var builder = new ContainerBuilder();
    builder.RegisterModule<CoreModule>();
    return builder.Build();
}
