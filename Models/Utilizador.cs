using System.Security.Cryptography;
using System.Text;

namespace NeighborTrade.Models
{
    public class Utilizador
    {
        public int UtilizadorID { get; set; }
        public string Nome { get; set; }
        public string SenhaHash { get; private set; }
        public string EmailHash { get; private set; } = string.Empty; // Inicializando com valor padrão
        public required string Endereco { get; set; }
        public StatusGeral Status { get; set; }
        public TipoUtilizador Tipo { get; set; }
        public string ComprovativoResidencia { get; set; } = string.Empty; // URL do comprovativo
        public string ComprovativoCC { get; set; } = string.Empty; // URL do comprovativo de CC
        public int AprovacaoID { get; set; } // FK para Aprovacao

        // Método para registar um novo utilizador
        public void RegistarUtilizador(string senha, string email)
        {
            this.SenhaHash = HashSHA256(senha);
            this.EmailHash = HashSHA256(email);
            this.Status = StatusGeral.Pendente;
        }

        // Método para login do utilizador
        public bool LoginUtilizador(string senha, string email)
        {
            return SenhaHash == HashSHA256(senha) && EmailHash == HashSHA256(email);
        }

        // Método para recuperar senha (simulação de envio de link)
        public string RecuperarSenha()
        {
            return "Um link de recuperação foi enviado para seu e-mail.";
        }

        // Método para aprovar um utilizador
        public void AprovarUtilizador()
        {
            this.Status = StatusGeral.Ativo;
        }

        // Método para editar perfil
        public void EditarPerfil(string nome, string endereco)
        {
            this.Nome = nome;
            this.Endereco = endereco;
        }

        // Método para gerar hash SHA-256 para senha e email
        private string HashSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
