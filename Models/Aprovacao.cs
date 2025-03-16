namespace NeighborTrade.Models
{
    public class Aprovacao
    {
        public int AprovacaoID { get; set; } // Primary Key
        public string Comentario { get; set; }
        public DateTime DataSubmissao { get; private set; }
        public DateTime? DataAprovacao { get; private set; }
        public StatusGeral Status { get; private set; }
        public int UtilizadorID { get; set; } // Foreign Key para o utilizador

        public Aprovacao(int utilizadorID, string comentario)
        {
            UtilizadorID = utilizadorID;
            Comentario = comentario;
            DataSubmissao = DateTime.Now;
            Status = StatusGeral.Pendente;
        }

        public void AtribuirModerador(int moderadorID)
        {
            Console.WriteLine($"Aprovação atribuída ao moderador ID: {moderadorID}");
        }

        public void SubmeterParaAprovacao()
        {
            if (Status != StatusGeral.Pendente)
            {
                throw new InvalidOperationException("Apenas aprovações pendentes podem ser submetidas.");
            }
            Status = StatusGeral.EmAndamento;
            Console.WriteLine("Aprovação submetida para análise.");
        }

        public void SolicitarAlteracoes(string novoComentario)
        {
            if (Status != StatusGeral.EmAndamento)
            {
                throw new InvalidOperationException("Alterações só podem ser solicitadas para aprovações em andamento.");
            }
            Comentario = novoComentario;
            Status = StatusGeral.Rejeitado;
            Console.WriteLine("Alterações solicitadas.");
        }

        public void DecidirAprovacao(bool aprovar)
        {
            if (Status != StatusGeral.EmAndamento)
            {
                throw new InvalidOperationException("A decisão só pode ser tomada para aprovações em andamento.");
            }

            Status = aprovar ? StatusGeral.Aprovado : StatusGeral.Rejeitado;
            DataAprovacao = aprovar ? DateTime.Now : (DateTime?)null;

            if (aprovar)
            {
                Console.WriteLine("Aprovação concedida.");
            }
            else
            {
                Console.WriteLine("Aprovação rejeitada.");
            }
        }
    }
}
