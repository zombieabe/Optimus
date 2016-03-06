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
            var halfValue = Math.Abs(numberToCheck / 2)+1;
            //only check up to half, as there is no way a number
            //can be divisible by a number greater that half
            while (count != halfValue)
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
