﻿using Machine.Fakes;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core.Specs.PrimeCheckerSpecs
{
    public class when_checking_two_is_prime : WithFakes
    {
        static IPrimeChecker checker;
        static bool result;

        Establish context = () =>
        {
            checker = new PrimeChecker();
        };

        Because of = () =>
        {
            result = checker.IsPrime(2);
        };

        It should_return_true = () =>
        {
            result.ShouldBeTrue();
        };
    }
}
