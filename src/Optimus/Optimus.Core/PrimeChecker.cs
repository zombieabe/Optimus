using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core
{
    public class PrimeChecker : IPrimeChecker
    {
        public bool IsPrime(uint numberToCheck)
        {
            if(numberToCheck == 0)
            {
                throw new ArgumentException("0 is not a prime");
            }

            var count = 2;
            bool result = true;

            while (count != numberToCheck)
            {
                if(numberToCheck%count == 0)
                {
                    result = false;
                    break;
                }
                count++;
            }

            return result;
        }
    }
}
