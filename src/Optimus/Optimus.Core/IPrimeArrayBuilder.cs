using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core
{
    public interface IPrimeArrayBuilder
    {
        float?[,] GetPrimeMatrix(uint numberOfPrimes);
    }
}
