using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core
{
    public class PrimeArrayBuilder : IPrimeArrayBuilder
    {
        IPrimeGenerator primeGenerator;

        public PrimeArrayBuilder(IPrimeGenerator primeGenerator)
        {
            this.primeGenerator = primeGenerator;
        }

        public float?[,] GetPrimeMatrix(uint numberOfPrimes)
        {
            if(numberOfPrimes == 0)
            {
                throw new ArgumentException("number of primes can't be 0");
            }

            var arraySize = numberOfPrimes + 1;
            var matrix = new float?[arraySize, arraySize];
            var primes = primeGenerator.GeneratePrimesArray(numberOfPrimes);

            for (int i = 0; i<arraySize;i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    var xAxis = i == 0 ? 1 : primes[i - 1];
                    var yAxis = j == 0 ? 1 : primes[j - 1];
                    matrix[i, j] = xAxis * yAxis;
                }
            }

            matrix[0, 0] = null;

            return matrix;
        }
    }
}
