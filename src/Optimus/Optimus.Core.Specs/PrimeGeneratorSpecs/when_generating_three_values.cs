using Machine.Fakes;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core.Specs.PrimeGeneratorSpecs
{
    public class when_generating_three_values : WithFakes
    {
        static IPrimeGenerator primeGenerator;
        static IPrimeChecker primeChecker;
        static uint[] result;
        static uint[] firstThree;
        static uint arrayLength;

        Establish context = () =>
        {
            primeChecker = An<IPrimeChecker>();
            firstThree = new uint[] { 2, 3, 4 };
            arrayLength = 3;

            primeChecker.WhenToldTo(x => x.IsPrime(Param.IsAny<uint>())).Return(true);
            primeGenerator = new PrimeGenerator(primeChecker);
        };

        Because of = () =>
        {
            result = primeGenerator.GeneratePrimesArray(arrayLength).ToArray();
        };

        It array_should_match = () =>
        {
            for(int i = 0;i<arrayLength;i++)
            {
                result[i].ShouldEqual(firstThree[i]);
            }
        };

    }
}
