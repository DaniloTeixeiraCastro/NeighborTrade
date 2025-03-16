namespace NeighborTrade.Models
{
    public class Reclamacao
    {
        public int ReclamacaoID { get; set; } // PK
        public int CompraID { get; set; } // FK - Compra
        public string Motivo { get; set; }
        public DateTime DataSubmissao { get; set; }
        public DateTime? DataAprovacao { get; set; }
        public StatusGeral Status { get; set; }
        public TipoReclamacao Tipo { get; set; }
        public int AprovacaoID { get; set; } // FK - Aprovacao

        public Reclamacao(int compraID, string motivo, TipoReclamacao tipo, int aprovacaoID)
        {
            CompraID = compraID;
            Motivo = motivo;
            Tipo = tipo;
            AprovacaoID = aprovacaoID;
            DataSubmissao = DateTime.Now;
            Status = StatusGeral.Pendente;
        }

        public void RegistarReclamacao()
        {
            Status = StatusGeral.EmAndamento;
            Console.WriteLine("Reclamação registada e em análise.");
        }

        public void DecidirReclamacao(bool aprovar)
        {
            if (aprovar)
            {
                Status = StatusGeral.Aprovado;
                DataAprovacao = DateTime.Now;
                Console.WriteLine("Reclamação aprovada.");
            }
            else
            {
                Status = StatusGeral.Rejeitado;
                Console.WriteLine("Reclamação rejeitada.");
            }
        }

        public void AtribuirModerador(int moderadorID)
        {
            Console.WriteLine($"Reclamação atribuída ao moderador ID: {moderadorID}");
        }

        public void SolicitarEvidencias()
        {
            Console.WriteLine("Solicitação de evidências enviada ao reclamante.");
        }
    }
