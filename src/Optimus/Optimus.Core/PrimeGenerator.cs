using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core
{
    public class PrimeGenerator : IPrimeGenerator
    {

        IPrimeChecker checker;

        public PrimeGenerator(IPrimeChecker checker)
        {
            this.checker = checker;
        }

        public uint[] GeneratePrimesArray(uint arrayLength)
        {
            if (arrayLength == 0)
            {
                throw new ArgumentException("arrayLength cannot be less than 1");
            }

            IList<uint> results = new List<uint>();
            uint count = 1;

            while (results.Count < arrayLength)
            {
                count++;
                if(checker.IsPrime(count))
                {
                    results.Add(count);
                }
            }
            
            return results.ToArray();
        }
    }
}
