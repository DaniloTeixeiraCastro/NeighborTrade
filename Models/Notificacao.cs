namespace NeighborTrade.Models
{
    public class Notificacao
    {
        public int NotificacaoID { get; set; } // Primary Key
        public int UtilizadorID { get; private set; } // Foreign Key para Utilizador
        public string Mensagem { get; private set; }
        public DateTime DataNotificacao { get; private set; }
        public bool Lida { get; private set; }
        public TipoNotificacao ReferenciaTipo { get; private set; }
        public int ReferenciaID { get; private set; } // ID do item relacionado à notificação

        public Notificacao(int utilizadorID, string mensagem, TipoNotificacao referenciaTipo, int referenciaID)
        {
            if (string.IsNullOrWhiteSpace(mensagem))
            {
                throw new ArgumentException("A mensagem da notificação não pode estar vazia.", nameof(mensagem));
            }

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
}
