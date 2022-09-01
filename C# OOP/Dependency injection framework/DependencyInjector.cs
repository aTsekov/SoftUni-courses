namespace TinyDIFramework
{
    using Dependency_injection_framework.Modules.Interfaces;
    using TinyDIFramework.Injectors;

    public class DInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}