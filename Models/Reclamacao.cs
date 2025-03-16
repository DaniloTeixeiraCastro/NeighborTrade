namespace NeighborTrade.Models
{
    public class Reclamacao
    {
        public int ReclamacaoID { get; set; } // Primary Key
        public int CompraID { get; private set; } // Foreign Key para Compra
        public string Motivo { get; private set; }
        public DateTime DataSubmissao { get; private set; }
        public DateTime? DataAprovacao { get; private set; }
        public StatusGeral Status { get; private set; }
        public TipoReclamacao Tipo { get; private set; }
        public int AprovacaoID { get; private set; } // Foreign Key para Aprovacao

        public Reclamacao(int compraID, string motivo, TipoReclamacao tipo, int aprovacaoID)
        {
            if (string.IsNullOrWhiteSpace(motivo))
            {
                throw new ArgumentException("O motivo da reclamação não pode estar vazio.", nameof(motivo));
            }

            CompraID = compraID;
            Motivo = motivo;
            Tipo = tipo;
            AprovacaoID = aprovacaoID;
            DataSubmissao = DateTime.Now;
            Status = StatusGeral.Pendente;
        }

        public void RegistarReclamacao()
        {
            if (Status != StatusGeral.Pendente)
            {
                throw new InvalidOperationException("Apenas reclamações pendentes podem ser registadas.");
            }

            Status = StatusGeral.EmAndamento;
            Console.WriteLine("Reclamação registada e em análise.");
        }

        public void DecidirReclamacao(bool aprovar)
        {
            if (Status != StatusGeral.EmAndamento)
            {
                throw new InvalidOperationException("A decisão só pode ser tomada para reclamações em andamento.");
            }

            Status = aprovar ? StatusGeral.Aprovado : StatusGeral.Rejeitado;
            DataAprovacao = aprovar ? DateTime.Now : (DateTime?)null;

            Console.WriteLine(aprovar ? "Reclamação aprovada." : "Reclamação rejeitada.");
        }

        public void AtribuirModerador(int moderadorID)
        {
            if (Status != StatusGeral.Pendente)
            {
                throw new InvalidOperationException("Apenas reclamações pendentes podem ser atribuídas a um moderador.");
            }

            Console.WriteLine($"Reclamação atribuída ao moderador ID: {moderadorID}");
        }

        public void SolicitarEvidencias()
        {
            if (Status != StatusGeral.EmAndamento)
            {
                throw new InvalidOperationException("Evidências só podem ser solicitadas para reclamações em andamento.");
            }

            Console.WriteLine("Solicitação de evidências enviada ao reclamante.");
        }
    }
}
