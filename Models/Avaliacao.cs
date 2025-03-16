using System;
namespace NeighborTrade.Models
{
    public class Avaliacao
    {
        public int AvaliacaoID { get; set; } // Primary Key
        public int AprovacaoID { get; private set; } // Foreign Key para Aprovacao
        public int AnuncioID { get; private set; } // Foreign Key para Anuncio
        public NotaAvaliacao Nota { get; private set; }
        public string Comentario { get; private set; }
        public DateTime DataAvaliacao { get; private set; }

        public Avaliacao(int aprovacaoID, int anuncioID, NotaAvaliacao nota, string comentario)
        {
            if (string.IsNullOrWhiteSpace(comentario))
            {
                throw new ArgumentException("O comentário não pode estar vazio.", nameof(comentario));
            }

            AprovacaoID = aprovacaoID;
            AnuncioID = anuncioID;
            Nota = nota;
            Comentario = comentario;
            DataAvaliacao = DateTime.Now;
        }

        // Métodos de comportamento
        public void AvaliarTransacao()
        {
            Console.WriteLine($"Avaliação para Anúncio {AnuncioID}: Nota {Nota}, Comentário: {Comentario}");
        }

        public void RegistarAvaliacao()
        {
            Console.WriteLine($"Avaliação {AvaliacaoID} registrada em {DataAvaliacao}.");
        }

        public void EditarAvaliacao(NotaAvaliacao novaNota, string novoComentario)
        {
            if (string.IsNullOrWhiteSpace(novoComentario))
            {
                throw new ArgumentException("O novo comentário não pode estar vazio.", nameof(novoComentario));
            }

            Nota = novaNota;
            Comentario = novoComentario;
            Console.WriteLine($"Avaliação {AvaliacaoID} editada com sucesso.");
        }

        public void EliminarAvaliacao()
        {
            Console.WriteLine($"Avaliação {AvaliacaoID} eliminada.");
            // Adicionar lógica de remoção no futuro, se integrar com BD
        }
    }
}
