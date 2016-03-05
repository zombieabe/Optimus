using Machine.Fakes;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core.Specs.PrimeArrayBuilderSpecs
{
    public class when_generating_single_prime : WithFakes
    {
        static IPrimeArrayBuilder primeArrayBuilder;
        static IPrimeGenerator primeGenerator;
        static uint numberOfPrimes;
        static float?[,] result;

        Establish context = () =>
        {
            primeGenerator = An<IPrimeGenerator>();
            numberOfPrimes = 1;
            primeGenerator.WhenToldTo(x => x.GeneratePrimesArray(numberOfPrimes)).Return(new uint[1] { 2 });
            primeArrayBuilder = new PrimeArrayBuilder(primeGenerator);
        };

        Because of = () =>
        {
            result = primeArrayBuilder.GetPrimeMatrix(numberOfPrimes);
        };

        It should_return_two_by_two_array = () =>
        {
            result.GetLength(0).ShouldEqual(2);
            result.GetLength(1).ShouldEqual(2);
        };

        It should_generate_primes = () =>
        {
            primeGenerator.WasToldTo(x => x.GeneratePrimesArray(numberOfPrimes));
        };

        It should_return_expected_result = () =>
        {
            result[0, 0].ShouldBeNull();
            result[1, 0].ShouldEqual<float?>(2);
            result[0, 1].ShouldEqual<float?>(2);
            result[1, 1].ShouldEqual<float?>(4);
        };

        
    }
}
