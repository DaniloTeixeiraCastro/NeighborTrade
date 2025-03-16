namespace NeighborTrade.Models
{
    public class Troca
    {
        public int TrocaID { get; set; }
        public int ItemAnunciante { get; set; } // FK para Anuncio
        public int ItemComprador { get; set; } // FK para Anuncio
        public int? ItemDiferenteComprador { get; set; } // FK opcional para outro Anuncio
        public StatusGeral Status { get; set; }

        public Troca(int itemAnunciante, int itemComprador, int? itemDiferenteComprador = null)
        {
            ItemAnunciante = itemAnunciante;
            ItemComprador = itemComprador;
            ItemDiferenteComprador = itemDiferenteComprador;
            Status = StatusGeral.Pendente; // Status inicial ao criar uma troca
        }

        public void IniciarTroca()
        {
            Console.WriteLine("Troca iniciada entre os itens.");
            Status = StatusGeral.EmAndamento;
        }

        public void ConfirmarTroca()
        {
            if (Status == StatusGeral.EmAndamento)
            {
                Status = StatusGeral.Aprovado;
                Console.WriteLine("Troca confirmada com sucesso!");
            }
            else
            {
                Console.WriteLine("A troca não pode ser confirmada neste estado.");
            }
        }

        public void RejeitarTroca()
        {
            Status = StatusGeral.Rejeitado;
            Console.WriteLine("Troca rejeitada.");
        }

        public void ProporOutraTroca(int novoItemComprador, int? novoItemDiferenteComprador = null)
        {
            ItemComprador = novoItemComprador;
            ItemDiferenteComprador = novoItemDiferenteComprador;
            Status = StatusGeral.Pendente;
            Console.WriteLine("Nova proposta de troca enviada.");
        }
    }
}
