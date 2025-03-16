namespace NeighborTrade.Models
{
    public class Anuncio
    {
        public int AnuncioID { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<string> Imagens { get; set; } = new List<string>();
        public float Preco { get; set; }
        public StatusGeral Status { get; set; }
        public TipoCategoria Categoria { get; set; }
        public int AprovacaoID { get; set; } // FK para Aprovacao
        public DateTime DataPublicacao { get; set; }

        public Anuncio()
        {
            DataPublicacao = DateTime.Now; // Define a data ao criar um anúncio
        }

        public void CriarAnuncio()
        {
            if (!ValidarAnuncio())
            {
                throw new InvalidOperationException("Erro: Anúncio inválido. Verifique os campos obrigatórios.");
            }
            Console.WriteLine("Anúncio criado com sucesso!");
        }

        public void SubmeterAnuncio()
        {
            if (!ValidarAnuncio())
            {
                throw new InvalidOperationException("Erro: Anúncio inválido. Não pode ser submetido.");
            }
            Status = StatusGeral.Pendente;
            Console.WriteLine("Anúncio submetido para aprovação.");
        }

        public void EliminarAnuncio()
        {
            Console.WriteLine("Anúncio eliminado.");
        }

        public void EditarAnuncio(string novoTitulo, string novaDescricao, float novoPreco)
        {
            Titulo = novoTitulo;
            Descricao = novaDescricao;
            Preco = novoPreco;

            if (!ValidarAnuncio())
            {
                throw new InvalidOperationException("Erro: Alterações tornaram o anúncio inválido.");
            }

            Console.WriteLine("Anúncio editado com sucesso.");
        }

        private bool ValidarAnuncio()
        {
            return !string.IsNullOrWhiteSpace(Titulo) &&
                   !string.IsNullOrWhiteSpace(Descricao) &&
                   Preco > 0;
        }

        public static List<Anuncio> ListarAnuncios()
        {
            return new List<Anuncio>(); // Simulação de uma lista vazia, depois pode integrar com BD
        }
    }
}
