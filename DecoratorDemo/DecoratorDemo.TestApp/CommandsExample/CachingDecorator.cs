using Microsoft.Extensions.Caching.Memory;
using System;

namespace DecoratorDemo.TestApp.CommandsExample
{
    public class CachingDecorator: ICommand
    {
        private readonly ICommand _innerCommand;
        private IMemoryCache _cache;
        public CachingDecorator(ICommand command)
        {
            _innerCommand = command;

            _cache = new MemoryCache(new MemoryCacheOptions
            {
               
            });
        }

        public string Execute()
        {
            var serverLocation = $"server-1";

            //Start by defining a cache-key
            var cacheKey = $"checkUpdates::{serverLocation}";

            //check the cache to see if we have data for this server/location
            if(_cache.TryGetValue<string>(cacheKey, out var currentUpdate))
            {
                Console.WriteLine("from cache");
                return currentUpdate;
            }
            else //if cachek-key is not found
            {
                //Get updates from inner object
                var result = _innerCommand.Execute(); //actual command

                // add this to cache
                _cache.Set<string>(cacheKey, result, TimeSpan.FromMinutes(1));

                return $"{result}";

            }
        }
    }
}
