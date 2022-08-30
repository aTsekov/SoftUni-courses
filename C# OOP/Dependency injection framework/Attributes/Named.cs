namespace Dependency_injection_framework.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field)]
    public class Named :Attribute
    {
        public Named( string name)
        {
            this.Name = name;
        }

        public string Name { get;}
    }
}
