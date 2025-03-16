namespace NeighborTrade.Models
{
    public class Pagamento
    {
        public int PagamentoID { get; set; } // Primary Key
        public int UtilizadorID { get; private set; } // Foreign Key para Utilizador
        public int CompraID { get; private set; } // Foreign Key para Compra
        public decimal Valor { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public TipoPagamento MetodoPagamento { get; private set; }
        public StatusGeral Status { get; private set; }

        public Pagamento(int utilizadorID, int compraID, decimal valor, TipoPagamento metodoPagamento)
        {
            if (utilizadorID <= 0) throw new ArgumentException("UtilizadorID deve ser maior que zero.");
            if (compraID <= 0) throw new ArgumentException("CompraID deve ser maior que zero.");
            if (valor <= 0) throw new ArgumentException("Valor deve ser maior que zero.");

            UtilizadorID = utilizadorID;
            CompraID = compraID;
            Valor = valor;
            DataPagamento = DateTime.Now;
            MetodoPagamento = metodoPagamento;
            Status = StatusGeral.Pendente;
        }

        /// <summary>
        /// Efetua o pagamento de forma assíncrona.
        /// </summary>
        public async Task EfetuarPagamentoAsync()
        {
            if (Status != StatusGeral.Pendente)
            {
                throw new InvalidOperationException("O pagamento já foi processado ou está num estado inválido.");
            }

            // Simula uma operação assíncrona
            await Task.Delay(100);
            Status = StatusGeral.Concluido;
            Console.WriteLine("Pagamento efetuado com sucesso.");
        }

        /// <summary>
        /// Reembolsa o pagamento de forma assíncrona.
        /// </summary>
        public async Task ReembolsarPagamentoAsync()
        {
            if (Status != StatusGeral.Concluido)
            {
                throw new InvalidOperationException("Somente pagamentos concluídos podem ser reembolsados.");
            }

            // Simula uma operação assíncrona
            await Task.Delay(100);
            Status = StatusGeral.Reembolsado;
            Console.WriteLine("Pagamento reembolsado com sucesso.");
        }
    }
}
