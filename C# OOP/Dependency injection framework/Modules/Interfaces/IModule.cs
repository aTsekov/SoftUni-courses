namespace Dependency_injection_framework.Modules.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IModule
    {
        void Configure();
        Type GetMapping(Type currentInterface, object attribute);
        object GetInstance(Type type);
        void SetInstance(Type implementation, object instance);
    }
}
