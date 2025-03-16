namespace NeighborTrade.Models
{
    public class Pagamento
    {
        public int PagamentoID { get; set; } // PK
        public int UtilizadorID { get; set; } // FK - Utilizador
        public int CompraID { get; set; } // FK - Compra
        public float Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public TipoPagamento MetodoPagamento { get; set; }
        public StatusGeral Status { get; set; }

        public Pagamento(int utilizadorID, int compraID, float valor, TipoPagamento metodoPagamento)
        {
            UtilizadorID = utilizadorID;
            CompraID = compraID;
            Valor = valor;
            DataPagamento = DateTime.Now;
            MetodoPagamento = metodoPagamento;
            Status = StatusGeral.Pendente;
        }

        public void EfetuarPagamento()
        {
            Status = StatusGeral.Concluido;
            Console.WriteLine("Pagamento efetuado com sucesso.");
        }

        public void ReembolsarPagamento()
        {
            if (Status == StatusGeral.Concluido)
            {
                Status = StatusGeral.Reembolsado;
                Console.WriteLine("Pagamento reembolsado.");
            }
            else
            {
                Console.WriteLine("O pagamento não pode ser reembolsado.");
            }
        }

        public static void ListarPagamentos(List<Pagamento> pagamentos)
        {
            foreach (var pagamento in pagamentos)
            {
                Console.WriteLine($"ID: {pagamento.PagamentoID}, Valor: {pagamento.Valor}, Status: {pagamento.Status}, Data: {pagamento.DataPagamento}");
            }
        }
    }
