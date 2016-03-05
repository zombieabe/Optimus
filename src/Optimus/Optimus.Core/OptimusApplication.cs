using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core
{
    public class OptimusApplication : IOptimusApplication
    {
        IConsole console;
        IPrimeArrayBuilder primeArrayBuilder;
        private readonly string startMessage = "To view matrix please enter a number greater than zero and press enter.\r\nTo quit type 'q' and press enter";

        public OptimusApplication(IConsole console, IPrimeArrayBuilder primeArrayBuilder)
        {
            this.console = console;
            this.primeArrayBuilder = primeArrayBuilder;
        }

        public void RunApplication()
        {
            console.WriteLine(startMessage);
            var input = console.Readline();
            if (string.Equals(input, "q", StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }
            uint number = 0;
            uint.TryParse(input, out number);
            if (number != 0)
            {
                var matrix = primeArrayBuilder.GetPrimeMatrix(number);
                for(int i = 0, c = matrix.GetLength(0); i < c; i++)
                {
                    string line = "|";

                    for (int j = 0, v = matrix.GetLength(1); j < v; j++)
                    {
                        var matrixValue = matrix[i, j] == null ? " " : matrix[i, j].ToString();
                        line += $"{matrixValue} |".PadLeft(8,' ');
                    }

                    console.WriteLine(line);
                }
                console.ReadKey();
            }
            else
            {
                console.WriteLine("Invalid Input");
            }
        }
    }
}
