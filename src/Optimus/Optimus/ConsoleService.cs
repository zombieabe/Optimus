using Optimus.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus
{
    public class ConsoleService : IConsole
    {
        public string Readline()
        {
            return Console.ReadLine();
        }
        public void ReadKey()
        {
            Console.ReadKey();
        }
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
