using Machine.Fakes;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core.Specs.PrimeGeneratorSpecs
{
    public class when_generating_single_value_array : WithFakes
    {
        static IPrimeGenerator primeGenerator;
        static IPrimeChecker primeChecker;
        static IEnumerable<uint> result;
        static uint arrayLength;
        static uint expectedValue;

        Establish context = () =>
        {
            primeChecker = An<IPrimeChecker>();
            arrayLength = 1;
            expectedValue = 2;
            primeChecker.WhenToldTo(x => x.IsPrime(Param.IsAny<uint>())).Return(true);
            primeGenerator = new PrimeGenerator(primeChecker);
        };

        Because of = () =>
        {
            result = primeGenerator.GeneratePrimesArray(arrayLength);
        };

        It should_return_result_with_expected_count = () =>
        {
            result.Count().ShouldEqual(1);
        };

        It should_return_array_expected_first_value = () =>
        {
            result.FirstOrDefault().ShouldEqual(expectedValue);
        };

    }
}
