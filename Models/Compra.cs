namespace NeighborTrade.Models
{
    public class Compra
    {
        public int CompraID { get; set; } // PK
        public DateTime DataCompra { get; set; }
        public int CompradorID { get; set; } // FK - Utilizador
        public int AnuncioID { get; set; } // FK - Anuncio
        public StatusGeral Status { get; set; }

        public Compra(int compradorID, int anuncioID)
        {
            CompradorID = compradorID;
            AnuncioID = anuncioID;
            DataCompra = DateTime.Now;
            Status = StatusGeral.Pendente;
        }

        public void IniciarCompra()
        {
            Status = StatusGeral.EmProcesso;
            Console.WriteLine("Compra iniciada.");
        }

        public void ConcluirCompra()
        {
            Status = StatusGeral.Concluido;
            Console.WriteLine("Compra concluída com sucesso.");
        }

        public void CancelarCompra()
        {
            Status = StatusGeral.Cancelado;
            Console.WriteLine("Compra cancelada.");
        }

        public void ConfirmarRecebimento()
        {
            Status = StatusGeral.Finalizado;
            Console.WriteLine("Recebimento confirmado.");
        }
    }
