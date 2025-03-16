namespace NeighborTrade.Models
{
    public class Troca
    {
        public int TrocaID { get; set; } // Primary Key
        public int ItemAnunciante { get; private set; } // Foreign Key para Anuncio
        public int ItemComprador { get; private set; } // Foreign Key para Anuncio
        public int? ItemDiferenteComprador { get; private set; } // Foreign Key opcional
        public StatusGeral Status { get; private set; }

        public Troca(int itemAnunciante, int itemComprador, int? itemDiferenteComprador = null)
        {
            if (itemAnunciante <= 0 || itemComprador <= 0)
            {
                throw new ArgumentException("Os IDs dos itens do anunciante e comprador devem ser válidos.");
            }

            ItemAnunciante = itemAnunciante;
            ItemComprador = itemComprador;
            ItemDiferenteComprador = itemDiferenteComprador;
            Status = StatusGeral.Pendente; // Status inicial
        }

        public void IniciarTroca()
        {
            if (Status != StatusGeral.Pendente)
            {
                throw new InvalidOperationException("Apenas trocas pendentes podem ser iniciadas.");
            }

            Status = StatusGeral.EmAndamento;
            Console.WriteLine("Troca iniciada entre os itens.");
        }

        public void ConfirmarTroca()
        {
            if (Status != StatusGeral.EmAndamento)
            {
                throw new InvalidOperationException("A troca só pode ser confirmada se estiver em andamento.");
            }

            Status = StatusGeral.Aprovado;
            Console.WriteLine("Troca confirmada com sucesso!");
        }

        public void RejeitarTroca()
        {
            if (Status == StatusGeral.Aprovado)
            {
                throw new InvalidOperationException("Uma troca já aprovada não pode ser rejeitada.");
            }

            Status = StatusGeral.Rejeitado;
            Console.WriteLine("Troca rejeitada.");
        }

        public void ProporOutraTroca(int novoItemComprador, int? novoItemDiferenteComprador = null)
        {
            if (Status == StatusGeral.Aprovado || Status == StatusGeral.Rejeitado)
            {
                throw new InvalidOperationException("Não é possível propor outra troca para uma já concluída.");
            }

            ItemComprador = novoItemComprador;
            ItemDiferenteComprador = novoItemDiferenteComprador;
            Status = StatusGeral.Pendente;
            Console.WriteLine("Nova proposta de troca enviada.");
        }
    }
}
