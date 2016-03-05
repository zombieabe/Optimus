using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core
{
    public interface IConsole
    {
        string Readline();
        void ReadKey();
        void WriteLine(string line);
    }
}
