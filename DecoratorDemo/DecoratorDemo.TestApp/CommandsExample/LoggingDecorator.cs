using System.Diagnostics;

namespace DecoratorDemo.TestApp.CommandsExample
{
    public class LoggingDecorator : ICommand
    {
        private readonly ICommand _innerCommand;

        public LoggingDecorator(ICommand command)
        {
            _innerCommand = command;
        }
        public string Execute()
        {
            //e.g. log how often a method was called, how long it took, parameters and/or response

            var sw = Stopwatch.StartNew();

            var result = _innerCommand.Execute(); //actual result

            sw.Stop();
            var elapsedms = sw.ElapsedMilliseconds;

            return $"{result} => took {elapsedms} ms"; //changing the result if we want
        }
    }
}
