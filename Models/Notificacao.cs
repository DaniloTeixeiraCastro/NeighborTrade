namespace NeighborTrade.Models
{
    public class Notificacao
    {
        public int NotificacaoID { get; set; } // PK
        public int UtilizadorID { get; set; } // FK - Utilizador
        public string Mensagem { get; set; }
        public DateTime DataNotificacao { get; set; }
        public bool Lida { get; set; }
        public TipoNotificacao ReferenciaTipo { get; set; }
        public int ReferenciaID { get; set; } // ID do item relacionado à notificação (ex: Anúncio, Compra, etc.)

        public Notificacao(int utilizadorID, string mensagem, TipoNotificacao referenciaTipo, int referenciaID)
        {
            UtilizadorID = utilizadorID;
            Mensagem = mensagem;
            ReferenciaTipo = referenciaTipo;
            ReferenciaID = referenciaID;
            DataNotificacao = DateTime.Now;
            Lida = false;
        }

        public void EnviarNotificacao()
        {
            Console.WriteLine($"Notificação enviada para o utilizador {UtilizadorID}: {Mensagem}");
        }

        public void ReceberNotificacao()
        {
            Console.WriteLine($"Utilizador {UtilizadorID} recebeu a notificação: {Mensagem}");
        }

        public void MarcarComoLida()
        {
            Lida = true;
            Console.WriteLine($"Notificação {NotificacaoID} marcada como lida.");
        }
    }
