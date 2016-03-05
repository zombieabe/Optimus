using Machine.Fakes;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core.Specs.OptimusApplicationSpecs
{
    public class when_running_the_application_with_invalid_input : WithFakes
    {
        static IOptimusApplication application;
        static IPrimeArrayBuilder primeArrayBuilder;
        static IConsole console;

        Establish context = () =>
        {
            console = An<IConsole>();
            primeArrayBuilder = An<IPrimeArrayBuilder>();
            console.WhenToldTo(x => x.Readline()).Return("0");
            application = new OptimusApplication(console, primeArrayBuilder);
        };

        Because of = () =>
        {
            application.RunApplication();
        };

        It should_display_start_up_message_= () =>
        {
            console.WasToldTo(x => x.WriteLine("To view matrix please enter a number greater than zero and press enter.\r\nTo quit type 'q' and press enter"));
        };

        It should_read_console_input = () =>
        {
            console.WasToldTo(x => x.Readline());
        };

        It should_not_get_prime_array = () =>
        {
            primeArrayBuilder.WasNotToldTo(x => x.GetPrimeMatrix(Param.IsAny<uint>()));
        };

        It should_display_error_message = () =>
        {
            console.WasToldTo(x => x.WriteLine("Invalid Input"));
        };
    }
}
