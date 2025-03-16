namespace NeighborTrade.Models
{
    public class Pagamento
    {
        public int PagamentoID { get; set; } // PK
        public int UtilizadorID { get; set; } // FK - Utilizador
        public int CompraID { get; set; } // FK - Compra
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public TipoPagamento MetodoPagamento { get; set; }
        public StatusGeral Status { get; set; }

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
            // Simula uma operação assíncrona
            await Task.Delay(100);
            Status = StatusGeral.Concluido;
            // Substituir por um mecanismo de logging apropriado
            Console.WriteLine("Pagamento efetuado com sucesso.");
        }

        /// <summary>
        /// Reembolsa o pagamento de forma assíncrona.
        /// </summary>
        public async Task ReembolsarPagamentoAsync()
        {
            if (Status == StatusGeral.Concluido)
            {
                // Simula uma operação assíncrona
                await Task.Delay(100);
                Status = StatusGeral.Reembolsado;
                // Substituir por um mecanismo de logging apropriado
                Console.WriteLine("Pagamento reembolsado.");
            }
            else
            {
                // Substituir por um mecanismo de logging apropriado
                Console.WriteLine("O pagamento não pode ser reembolsado.");
            }
        }
    }
}
