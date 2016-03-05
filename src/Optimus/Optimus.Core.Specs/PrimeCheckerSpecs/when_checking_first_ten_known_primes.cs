using Machine.Fakes;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core.Specs.PrimeCheckerSpecs
{
    public class when_checking_first_ten_known_primes : WithFakes
    {
        static IPrimeChecker checker;
        static uint[] knownPrimes = new uint[10]{2,3,5,7,11,13,17,19,23,29};
        static bool result;

        Establish context = () =>
        {
            result = true;
            checker = new PrimeChecker();
        };

        Because of = () =>
        {
            for (var i= 0; i < knownPrimes.Length; i++)
            {
                result &= checker.IsPrime(knownPrimes[i]);
            }
        };

        It should_return_true = () =>
        {
            result.ShouldBeTrue();
        };
    }
}
