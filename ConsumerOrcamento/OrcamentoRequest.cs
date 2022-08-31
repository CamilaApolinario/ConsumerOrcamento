namespace ConsumerOrcamento
{
    public class OrcamentoRequest
    {
        public int Id { get; set; }
        public Vendedor? Vendedor { get; set; }
        public Produto? Produto { get; set; }
        public int QuantidadeProduto { get; set; }
        public double ValorTotal { get; set; }
    }

    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}

