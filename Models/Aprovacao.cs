namespace NeighborTrade.Models
{
    public class Aprovacao
    {
        public int AprovacaoID { get; set; } // PK
        public string Comentario { get; set; }
        public DateTime DataSubmissao { get; set; }
        public DateTime? DataAprovacao { get; set; }
        public StatusGeral Status { get; set; }
        public int UtilizadorID { get; set; } // FK - Utilizador

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
            Status = StatusGeral.EmAndamento;
            Console.WriteLine("Aprovação submetida para análise.");
        }

        public void SolicitarAlteracoes(string novoComentario)
        {
            Comentario = novoComentario;
            Status = StatusGeral.Rejeitado;
            Console.WriteLine("Alterações solicitadas.");
        }

        public void DecidirAprovacao(bool aprovar)
        {
            if (aprovar)
            {
                Status = StatusGeral.Aprovado;
                DataAprovacao = DateTime.Now;
                Console.WriteLine("Aprovação concedida.");
            }
            else
            {
                Status = StatusGeral.Rejeitado;
                Console.WriteLine("Aprovação rejeitada.");
            }
        }
    }
}
