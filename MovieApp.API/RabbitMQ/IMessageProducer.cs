namespace MovieApp.API.RabbitMQ
{
    public interface IMessageProducer
    {
        void SendMessage<T> (T message);
    }
}
