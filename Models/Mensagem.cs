namespace NeighborTrade.Models
{
    public class Mensagem
    {
        public int MensagemID { get; set; } // PK
        public string Conteudo { get; set; }
        public DateTime DataHora { get; set; }
        public int RemetenteID { get; set; } // FK - Utilizador
        public int DestinatarioID { get; set; } // FK - Utilizador
        public StatusMensagem Status { get; set; }

        public Mensagem(int remetenteID, int destinatarioID, string conteudo)
        {
            RemetenteID = remetenteID;
            DestinatarioID = destinatarioID;
            Conteudo = conteudo;
            DataHora = DateTime.Now;
            Status = StatusMensagem.NaoLida;
        }

        public void EnviarMensagem()
        {
            Console.WriteLine($"Mensagem enviada de {RemetenteID} para {DestinatarioID}: {Conteudo}");
            Status = StatusMensagem.Enviada;
        }

        public void EliminarMensagem()
        {
            Console.WriteLine($"Mensagem {MensagemID} eliminada.");
            Status = StatusMensagem.Eliminada;
        }

        public static void VerConversa(int usuario1ID, int usuario2ID, List<Mensagem> mensagens)
        {
            var conversa = mensagens.FindAll(m =>
                (m.RemetenteID == usuario1ID && m.DestinatarioID == usuario2ID) ||
                (m.RemetenteID == usuario2ID && m.DestinatarioID == usuario1ID));

            Console.WriteLine($"Conversa entre {usuario1ID} e {usuario2ID}:");
            foreach (var msg in conversa)
            {
                Console.WriteLine($"[{msg.DataHora}] {msg.RemetenteID}: {msg.Conteudo} (Status: {msg.Status})");
            }
        }
    }
}
