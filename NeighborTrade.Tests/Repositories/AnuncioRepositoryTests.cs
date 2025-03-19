using System;
using Xunit;
using NeighborTrade.Models;  // Importa o modelo Anuncio

namespace NeighborTrade.Tests.Repositories
{
    public class AnuncioRepositoryTests
    {
        [Fact]
        public void Anuncio_DeveSerValido_SeTodosOsCamposForemPreenchidos()
        {
            var anuncio = new Anuncio
            {
                Titulo = "Produto A",
                Descricao = "Descrição do produto",
                Preco = 100
            };

            Assert.True(anuncio.ValidarAnuncio());
        }

        [Fact]
        public void CriarAnuncio_DeveLancarExcecao_SeInvalido()
        {
            var anuncio = new Anuncio
            {
                Titulo = "",
                Descricao = "Descrição válida",
                Preco = 100
            };

            Assert.Throws<InvalidOperationException>(() => anuncio.CriarAnuncio());
        }
    }
}
