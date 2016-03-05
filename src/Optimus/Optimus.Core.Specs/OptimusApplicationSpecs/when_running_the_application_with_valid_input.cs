using Machine.Fakes;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core.Specs.OptimusApplicationSpecs
{
    public class when_running_the_application_with_valid_input : WithFakes
    {
        static IOptimusApplication application;
        static IPrimeArrayBuilder primeArrayBuilder;
        static IConsole console;

        Establish context = () =>
        {
            console = An<IConsole>();
            primeArrayBuilder = An<IPrimeArrayBuilder>();
            primeArrayBuilder.WhenToldTo(x => x.GetPrimeMatrix(1)).Return(new float?[2, 2] { { null,2 }, { 2, 4 } });
            console.WhenToldTo(x => x.Readline()).Return("1");
            application = new OptimusApplication(console, primeArrayBuilder);
        };

        Because of = () =>
        {
            application.RunApplication();
        };

        It should_display_start_up_message_ = () =>
        {
            console.WasToldTo(x => x.WriteLine("To view matrix please enter a number greater than zero and press enter.\r\nTo quit type 'q' and press enter"));
        };

        It should_read_console_input = () =>
        {
            console.WasToldTo(x => x.Readline());
        };

        It should_get_prime_array = () =>
        {
            primeArrayBuilder.WasToldTo(x => x.GetPrimeMatrix(Param.IsAny<uint>()));
        };

        It should_write_matrix_to_console = () =>
        {
            console.WasToldTo(x => x.WriteLine("|       |     2 |"));
            console.WasToldTo(x => x.WriteLine("|     2 |     4 |"));
        };


        It should_pause  = () =>
        {
            console.ReadKey();
        };

        It should_not_display_error_message = () =>
        {
            console.WasNotToldTo(x => x.WriteLine("Invalid Input"));
        };
    }
}
