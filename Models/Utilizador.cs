using System.Security.Cryptography;
using System.Text;

namespace NeighborTrade.Models
{
    public class Utilizador
    {
        public int UtilizadorID { get; set; } // Primary Key
        public string Nome { get; set; } = string.Empty;
        public string SenhaHash { get; private set; }
        public string EmailHash { get; private set; } = string.Empty; // Inicializando com valor padrão
        public string Endereco { get; set; } = string.Empty; // Garantir inicialização por segurança
        public StatusGeral Status { get; private set; }
        public TipoUtilizador Tipo { get; set; }
        public string ComprovativoResidencia { get; set; } = string.Empty; // URL do comprovativo
        public string ComprovativoCC { get; set; } = string.Empty; // URL do comprovativo de CC
        public int AprovacaoID { get; set; } // Foreign Key para Aprovacao

        // Método para registar um novo utilizador
        public void RegistarUtilizador(string senha, string email)
        {
            if (string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("A senha e o email não podem estar vazios.");
            }

            SenhaHash = HashSHA256(senha);
            EmailHash = HashSHA256(email);
            Status = StatusGeral.Pendente;
            Console.WriteLine("Utilizador registado com sucesso e aguardando aprovação.");
        }

        // Método para login do utilizador
        public bool LoginUtilizador(string senha, string email)
        {
            if (string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("A senha e o email não podem estar vazios.");
            }

            return SenhaHash == HashSHA256(senha) && EmailHash == HashSHA256(email);
        }

        // Método para recuperar senha (simulação)
        public string RecuperarSenha()
        {
            return "Um link de recuperação foi enviado para o seu e-mail registrado.";
        }

        // Método para aprovar um utilizador
        public void AprovarUtilizador()
        {
            if (Status != StatusGeral.Pendente)
            {
                throw new InvalidOperationException("Apenas utilizadores pendentes podem ser aprovados.");
            }

            Status = StatusGeral.Ativo;
            Console.WriteLine("Utilizador aprovado com sucesso.");
        }

        // Método para editar perfil
        public void EditarPerfil(string nome, string endereco)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(endereco))
            {
                throw new ArgumentException("Nome e endereço não podem estar vazios.");
            }

            Nome = nome;
            Endereco = endereco;
            Console.WriteLine("Perfil editado com sucesso.");
        }

        // Método para gerar hash SHA-256
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
