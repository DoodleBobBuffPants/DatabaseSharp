using Core.Modules;
using Microsoft.Extensions.Logging;

namespace Core;

public class Program
{
    public static void Main(string[] args)
    {
        using var services = Build();
        var logger = services.Resolve<ILogger<Program>>();
        logger.LogInformation("Good morning world!");
    }

    private static IContainer Build()
    {
        var builder = new ContainerBuilder();
        builder.RegisterModule<CoreModule>();
        return builder.Build();
    }
}
