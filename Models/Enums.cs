namespace NeighborTrade.Models
{
    public enum StatusGeral
    {
        Ativo,
        Inativo,
        Pendente,
        Rejeitado,
        Aprovado,
        EmAndamento,
        Concluido,
        Cancelado,
        Finalizado,
        EmProcesso,
        Reembolsado,
        Suspenso
    }

    public enum TipoUtilizador
    {
        Cliente,
        PrestadorServico,
        Administrador
    }
    public enum TipoCategoria
    {
        Eletronicos,
        Imoveis,
        Veiculos,
        Servicos,
        Outros
    }
    public enum TipoPagamento
    {
        CartaoCredito,
        CartaoDebito,
        Transferencia,
        MBWay,
    }
    public enum TipoReclamacao
    {
        ProdutoNaoConforme,
        ProdutoDanificado,
        ProdutoNaoRecebido,
        ProdutoDiferenteDoAnunciado,
        Outro
    }

    public enum StatusMensagem
    {
        Enviada,
        Recebida,
        Lida
    }

    public enum NotaAvaliacao
    {
        Nota1,
        Nota2,
        Nota3,
    }

    public enum TipoNotificacao
    {
        Aprovacao,
        Reclamacao,
        Pagamento,
        Mensagem,
        Avaliacao
    }
}
