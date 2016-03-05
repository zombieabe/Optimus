using Machine.Fakes;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core.Specs.PrimeArrayBuilderSpecs
{
    public class when_generating_zero_primes : WithFakes
    {
        static IPrimeArrayBuilder primeArrayBuilder;
        static IPrimeGenerator primeGenerator;
        static uint numberOfPrimes;
        static Exception result;

        Establish context = () =>
        {
            numberOfPrimes = 0;
            primeGenerator = An<IPrimeGenerator>();
            primeArrayBuilder = new PrimeArrayBuilder(primeGenerator);
        };

        Because of = () =>
        {
            result = Catch.Exception(()=> primeArrayBuilder.GetPrimeMatrix(numberOfPrimes));
        };

        It should_not_generate_primes = () =>
        {
            primeGenerator.WasNotToldTo(x => x.GeneratePrimesArray(numberOfPrimes));
        };

        It should_throw_exception = () =>
        {
            result.ShouldNotBeNull();
        };

        
    }
}
