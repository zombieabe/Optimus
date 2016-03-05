using Machine.Fakes;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core.Specs.PrimeCheckerSpecs
{
    public class when_checking_zero_is_prime : WithFakes
    {
        static IPrimeChecker checker;
        static Exception result;

        Establish context = () =>
        {
            checker = new PrimeChecker();
        };

        Because of = () =>
        {
            result =  Catch.Exception(()=> checker.IsPrime(0));
        };

        It should_throw_exception = () =>
        {
            result.ShouldNotBeNull();
        };
    }
}
