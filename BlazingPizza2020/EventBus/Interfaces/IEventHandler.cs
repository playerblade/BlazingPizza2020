using System.Threading.Tasks;

namespace BlazingPizza2020.EventBus.Handlers
{
    public interface IEventHandler<T>
    {
        public Task HandleEventAsync(MessageSent @event);
    }
}