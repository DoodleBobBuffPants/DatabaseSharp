using Core.Api;

namespace Core.Modules;

public class CoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
            .Where(t => t.IsAssignableTo(typeof(Database)))
            .As<Database>();
    }
}
