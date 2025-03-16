namespace NeighborTrade.Models
{
    public class Mensagem
    {
        public int MensagemID { get; set; } // Primary Key
        public string Conteudo { get; private set; }
        public DateTime DataHora { get; private set; }
        public int RemetenteID { get; private set; } // Foreign Key para Utilizador
        public int DestinatarioID { get; private set; } // Foreign Key para Utilizador
        public StatusMensagem Status { get; private set; }

        public Mensagem(int remetenteID, int destinatarioID, string conteudo)
        {
            if (string.IsNullOrWhiteSpace(conteudo))
            {
                throw new ArgumentException("O conteúdo da mensagem não pode estar vazio.", nameof(conteudo));
            }

            RemetenteID = remetenteID;
            DestinatarioID = destinatarioID;
            Conteudo = conteudo;
            DataHora = DateTime.Now;
            Status = StatusMensagem.NaoLida;
        }

        public void EnviarMensagem()
        {
            if (Status != StatusMensagem.NaoLida)
            {
                throw new InvalidOperationException("A mensagem já foi enviada ou está num estado inválido.");
            }

            Console.WriteLine($"Mensagem enviada de {RemetenteID} para {DestinatarioID}: {Conteudo}");
            Status = StatusMensagem.Enviada;
        }

        public void EliminarMensagem()
        {
            if (Status == StatusMensagem.Eliminada)
            {
                throw new InvalidOperationException("A mensagem já foi eliminada.");
            }

            Console.WriteLine($"Mensagem {MensagemID} eliminada.");
            Status = StatusMensagem.Eliminada;
        }

        public static void VerConversa(int usuario1ID, int usuario2ID, List<Mensagem> mensagens)
        {
            if (mensagens == null || mensagens.Count == 0)
            {
                Console.WriteLine("Nenhuma mensagem encontrada.");
                return;
            }

            var conversa = mensagens.FindAll(m =>
                (m.RemetenteID == usuario1ID && m.DestinatarioID == usuario2ID) ||
                (m.RemetenteID == usuario2ID && m.DestinatarioID == usuario1ID));

            Console.WriteLine($"Conversa entre {usuario1ID} e {usuario2ID}:");
            if (conversa.Count == 0)
            {
                Console.WriteLine("Não há mensagens nesta conversa.");
            }
            else
            {
                foreach (var msg in conversa)
                {
                    Console.WriteLine($"[{msg.DataHora}] {msg.RemetenteID}: {msg.Conteudo} (Status: {msg.Status})");
                }
            }
        }

        public void MarcarComoLida()
        {
            if (Status != StatusMensagem.Enviada)
            {
                throw new InvalidOperationException("Somente mensagens enviadas podem ser marcadas como lidas.");
            }

            Status = StatusMensagem.Lida;
            Console.WriteLine($"Mensagem {MensagemID} marcada como lida.");
        }
    }
}
