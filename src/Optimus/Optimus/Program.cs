using Optimus.Core;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = Registry.LoadContainer();
            var application = container.GetInstance<IOptimusApplication>();
            application.RunApplication();
        }
    }
}
