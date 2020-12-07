using JKang.EventBus.AmazonSns;

namespace BlazingPizza2020.EventBus.Handlers
{
    [AmazonSnsTopic("Se Confirmo el pedido ahora el pedido esta en cosina")]
    public class MessageSent
    {
        public MessageSent(string message) => Message = message;

        public string Message { get; }
    }
}