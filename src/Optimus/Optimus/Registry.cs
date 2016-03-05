using Optimus.Core;
using StructureMap;
using StructureMap.Graph;

namespace Optimus
{
    public class Registry
    {
        public static IContainer LoadContainer()
        {
            IContainer container = new Container(x =>
            {
                x.Scan(conventions =>
                {
                    conventions.TheCallingAssembly();
                    conventions.AssembliesFromApplicationBaseDirectory(filter => filter.FullName.StartsWith("Optimus"));
                    conventions.WithDefaultConventions();
                });
                x.For<IConsole>().Use<ConsoleService>();
            });
            return container;
        }
    }
}
