using Machine.Fakes;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core.Specs.PrimeGeneratorSpecs
{
    public class when_generating_with_value_of_zero : WithFakes
    {
        static IPrimeGenerator primeGenerator;
        static IPrimeChecker primeChecker;
        static Exception result;

        static uint arrayLength;

        Establish context = () =>
        {
            arrayLength = 0;
            primeGenerator = new PrimeGenerator(primeChecker);
        };

        Because of = () =>
        {
            result = Catch.Exception(() => primeGenerator.GeneratePrimesArray(arrayLength));
        };

        It should_throw_exception = () =>
        {
            result.ShouldNotBeNull();
        };

        It should_throw_argument_exception = () =>
        {
            result.ShouldBeAssignableTo<ArgumentException>();
        };
    }
}
