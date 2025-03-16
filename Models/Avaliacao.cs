namespace NeighborTrade.Models
public class Avaliacao
{
    public int AvaliacaoID { get; set; } // PK
    public int AprovacaoID { get; set; } // FK - Aprovacao
    public int AnuncioID { get; set; } // FK - Anuncio
    public NotaAvaliacao Nota { get; set; }
    public string Comentario { get; set; }
    public DateTime DataAvaliacao { get; set; }

    public Avaliacao(int aprovacaoID, int anuncioID, NotaAvaliacao nota, string comentario)
    {
        AprovacaoID = aprovacaoID;
        AnuncioID = anuncioID;
        Nota = nota;
        Comentario = comentario;
        DataAvaliacao = DateTime.Now;
    }

    public void AvaliarTransacao()
    {
        Console.WriteLine($"Avaliação para Anúncio {AnuncioID}: Nota {Nota}, Comentário: {Comentario}");
    }

    public void RegistarAvaliacao()
    {
        Console.WriteLine($"Avaliação {AvaliacaoID} registrada.");
    }

    public void EditarAvaliacao(NotaAvaliacao novaNota, string novoComentario)
    {
        Nota = novaNota;
        Comentario = novoComentario;
        Console.WriteLine($"Avaliação {AvaliacaoID} editada.");
    }

    public void EliminarAvaliacao()
    {
        Console.WriteLine($"Avaliação {AvaliacaoID} eliminada.");
    }
}
