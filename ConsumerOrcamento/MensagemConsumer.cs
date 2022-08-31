using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace ConsumerOrcamento
{
    public class MensagemConsumer : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;
        private readonly ConsumerContext context;
        

        public MensagemConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            this.context = new ConsumerContext();
        }

        private const string Orcamento = "messages";

        public MensagemConsumer()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 49158,
                UserName = "guest",
                Password = "guest"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(
                queue: Orcamento,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {
                var contentArray = ea.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var message = JsonSerializer.Deserialize<OrcamentoRequest>(contentString);

                Console.WriteLine($"Id {message.Id}, Vendedor {message.Vendedor}, Produto{message.Produto}, Quantidade{message.QuantidadeProduto}, Valor Total{message.ValorTotal}");

            };

            _channel.BasicConsume(Orcamento, true, consumer);




            return Task.CompletedTask;
        }
    }
}
