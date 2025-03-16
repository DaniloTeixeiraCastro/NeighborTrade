# NeighborTrade

NeighborTrade é um marketplace local criado para facilitar a troca e venda de produtos entre residentes de uma comunidade. Inspirado por plataformas como OLX, este projeto é voltado exclusivamente para um ambiente comunitário, garantindo segurança e proximidade.

## Funcionalidades

- **Cadastro e Gerenciamento de Utilizadores**  
  Os utilizadores podem registar-se, enviar comprovativos de residência e completar seus perfis. A aprovação é gerida por moderadores.

- **Criação e Gerenciamento de Anúncios**  
  Publicação de anúncios para venda ou troca de produtos, com suporte para imagens e descrição detalhada.

- **Trocas e Compras**  
  Negociações entre utilizadores para trocas diretas ou compras seguras através de métodos integrados de pagamento.

- **Avaliações e Reclamações**  
  Possibilidade de avaliar transações e apresentar reclamações, aumentando a transparência e confiança na comunidade.

- **Sistema de Notificações**  
  Utilizadores recebem notificações relacionadas a atividades importantes, como mensagens, atualizações de status e propostas.

## Tecnologias Utilizadas

- **Back-end**:  
  - C# e .NET 7.0
- **Banco de Dados** (a integrar):  
  - SQL Server
- **Autenticação e Segurança**:  
  - Hash de senhas e emails utilizando SHA-256

## Estrutura do Projeto

### Classes Principais
1. **`Anuncio`**  
   Gerencia os anúncios criados pelos utilizadores.
2. **`Utilizador`**  
   Controla o cadastro, autenticação e aprovação de utilizadores.
3. **`Compra`**  
   Representa a compra de um produto dentro da plataforma.
4. **`Troca`**  
   Facilita a negociação e a troca de produtos entre utilizadores.
5. **`Mensagem`**  
   Sistema interno de mensagens para comunicação entre utilizadores.
6. **`Avaliacao`**  
   Permite avaliações para medir a qualidade da transação.
7. **`Reclamacao`**  
   Sistema de resolução de conflitos através de moderação.
8. **`Pagamento`**  
   Gerencia os pagamentos e reembolsos entre utilizadores.
9. **`Notificacao`**  
   Mantém os utilizadores informados sobre atividades importantes.

## Funcionalidades Futuras

- **API RESTful** para integração com aplicações front-end.
- Integração com serviços de notificação via e-mail.
- Relatórios detalhados para análise de atividades da comunidade.
- Aplicação móvel para Android e iOS.

## Como Contribuir

1. Faça um fork do repositório.
2. Crie uma branch com a sua feature: `git checkout -b minha-feature`.
3. Faça o commit das suas alterações: `git commit -m 'Adicionar nova feature'`.
4. Envie para a sua branch: `git push origin minha-feature`.
5. Crie um Pull Request.

## Licença

Este projeto está sob a licença **MIT** - veja o arquivo [LICENSE](LICENSE) para detalhes.

---

Trabalhamos para criar uma comunidade mais conectada e segura. Feedback e contribuições são muito bem-vindos!
