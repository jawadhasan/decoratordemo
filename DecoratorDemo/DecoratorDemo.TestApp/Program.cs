using DecoratorDemo.TestApp.CommandsExample;
using DecoratorDemo.TestApp.SandwichExample;
using System;

namespace DecoratorDemo.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //DecoratorExample1();
            //LoggingDecoratorExample();
            CachingDecoratorExample();
        }

        static void DecoratorExample1()
        {
            var sandwich = new DressingDecorator(
                                new MeatDecorator(
                                    new SimpeSandwich()));

            var result = sandwich.Make();

            Console.WriteLine(result);
        }

        static void LoggingDecoratorExample()
        {
            var backupCommand = new LoggingDecorator(new BackupCommand());
            var result = backupCommand.Execute();
            Console.WriteLine(result);

        }

      

        static void CachingDecoratorExample()
        {
            //var checkUpdatesCommand = new CachingDecorator(new CheckUpdatesCommand());

            //with logging and caching
            var checkUpdatesCommand = new LoggingDecorator(
             new CachingDecorator(
                 new CheckUpdatesCommand()));

            var loopCount = 0;
            while (loopCount < 5)
            {
                Console.WriteLine($"****************************************");
                Console.WriteLine($"LoopCount: {loopCount}");
                var updatesResult = checkUpdatesCommand.Execute();
                Console.WriteLine(updatesResult);
                loopCount++;
            }

        }
    }
}
