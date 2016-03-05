
using Machine.Fakes;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core.Specs.PrimeCheckerSpecs
{
    public class checking_one_hundreth_prime : WithFakes
    {
        static IPrimeChecker checker;
        static uint input;
        static bool result;

        Establish context = () =>
        {
            input = 541;
            checker = new PrimeChecker();
        };

        Because of = () =>
        {
            result = checker.IsPrime(input);
        };

        It should_have_only_false_results = () =>
        {
            result.ShouldBeTrue();
        };
    }
}
