using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace BlazingPizza2020.EventBus.Handlers
{
    public class SentEventHandler : IEventHandler<MessageSent>
    {
        private readonly IMemoryCache _cache;

        public SentEventHandler(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task HandleEventAsync(MessageSent @event)
        {
            if (_cache.TryGetValue("messages", out List<string> messages))
            {
                messages.Add(@event.Message);
            }
            else
            {
                messages = new List<string> { @event.Message };
            }
            _cache.Set("messages", messages);

            return Task.CompletedTask;
        }
    }
}
