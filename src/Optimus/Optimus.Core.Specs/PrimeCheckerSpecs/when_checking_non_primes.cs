using Machine.Fakes;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core.Specs.PrimeCheckerSpecs
{
    public class when_checking_first_ten : WithFakes
    {
        static IPrimeChecker checker;
        static uint[] knownPrimes = new uint[10]{4,6,8,9,10,12,14,15,16,18};
        static bool[] results;

        Establish context = () =>
        {
            results = new bool[10] {true,true,true,true,true,true,true,true,true,true };
            checker = new PrimeChecker();
        };

        Because of = () =>
        {
            for (var i= 0; i < knownPrimes.Length; i++)
            {
                results[i] = checker.IsPrime(knownPrimes[i]);
            }
        };

        It should_have_only_false_results = () =>
        {
            results.ShouldNotContain(true);
        };
    }
}
