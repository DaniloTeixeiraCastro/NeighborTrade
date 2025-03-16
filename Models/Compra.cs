namespace NeighborTrade.Models
{
    public class Compra
    {
        public int CompraID { get; set; } // Primary Key
        public DateTime DataCompra { get; private set; }
        public int CompradorID { get; private set; } // Foreign Key para Utilizador
        public int AnuncioID { get; private set; } // Foreign Key para Anuncio
        public StatusGeral Status { get; private set; }

        // Construtor
        public Compra(int compradorID, int anuncioID)
        {
            if (compradorID <= 0 || anuncioID <= 0)
            {
                throw new ArgumentException("IDs do comprador e do anúncio devem ser válidos.");
            }

            CompradorID = compradorID;
            AnuncioID = anuncioID;
            DataCompra = DateTime.Now;
            Status = StatusGeral.Pendente;
        }

        // Métodos de comportamento
        public void IniciarCompra()
        {
            if (Status != StatusGeral.Pendente)
            {
                throw new InvalidOperationException("Apenas compras pendentes podem ser iniciadas.");
            }

            Status = StatusGeral.EmProcesso;
            Console.WriteLine("Compra iniciada.");
        }

        public void ConcluirCompra()
        {
            if (Status != StatusGeral.EmProcesso)
            {
                throw new InvalidOperationException("Apenas compras em processo podem ser concluídas.");
            }

            Status = StatusGeral.Concluido;
            Console.WriteLine("Compra concluída com sucesso.");
        }

        public void CancelarCompra()
        {
            if (Status == StatusGeral.Finalizado || Status == StatusGeral.Concluido)
            {
                throw new InvalidOperationException("Compras já concluídas ou finalizadas não podem ser canceladas.");
            }

            Status = StatusGeral.Cancelado;
            Console.WriteLine("Compra cancelada.");
        }

        public void ConfirmarRecebimento()
        {
            if (Status != StatusGeral.Concluido)
            {
                throw new InvalidOperationException("Apenas compras concluídas podem ser confirmadas como recebidas.");
            }

            Status = StatusGeral.Finalizado;
            Console.WriteLine("Recebimento confirmado.");
        }
    }
}
