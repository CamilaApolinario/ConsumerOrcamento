using ConsumerOrcamento;

class Program
{
    private static void Main(string[] args)
    {
        var consumer = new MensagemConsumer();
        consumer.StartAsync(new CancellationToken());

        Console.WriteLine("Mensagem consumida com sucesso");
    }
}