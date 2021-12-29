using System;
using System.Threading.Tasks;

namespace DecoratorDemo.TestApp.CommandsExample
{
    public interface ICommand
    {
        public string Execute();
    }
    public class BackupCommand : ICommand
    {
        public string Execute()
        {
            Console.WriteLine($"Starting {nameof(BackupCommand)}");

            //... DOING WORK HERE
            Task.Delay(2000).Wait();

            return $"{nameof(BackupCommand)} Completed";
        }
    }
    public class DownloadDataCommand : ICommand
    {
        public string Execute()
        {
            Console.WriteLine($"Starting {nameof(DownloadDataCommand)}");

            //... DOING WORK HERE
            Task.Delay(5000).Wait();

            return $"{nameof(DownloadDataCommand)} Completed";           
        }
    }
    public class CheckUpdatesCommand : ICommand
    {
        public string Execute()
        {

            Console.WriteLine($"Starting {nameof(CheckUpdatesCommand)}");

            //... DOING WORK HERE
            Task.Delay(5000).Wait();

            return $"{nameof(CheckUpdatesCommand)} Completed";
        }
    }
}
