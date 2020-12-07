using JKang.EventBus.AmazonSns;

namespace BlazingPizza2020.EventBus.Handlers
{
    [AmazonSnsTopic("Se termino de prepar los pedidos")]
    public class MessageSent
    {
        public MessageSent(string message) => Message = message;

        public string Message { get; }
    }
}