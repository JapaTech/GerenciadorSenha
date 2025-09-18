using OpensourcePassword.Modelos;
using System.Text.Json;


namespace OpensourcePassword
{
    public class GerenciadorSenha
    {
        List<DadosDoServico> dados = new List<DadosDoServico>();
        private readonly string nomeDoArquivo;
        private readonly string caminhoCompleto;
        private byte[] chave;

        public GerenciadorSenha(byte[] chave, string caminhoCompleto, string nomeDoArquivo)
        {
            this.nomeDoArquivo = nomeDoArquivo;
            this.chave = chave;
            this.caminhoCompleto = caminhoCompleto;
        }

        public bool CadastrarNovoServico(string nomeServico, string usuario, string email, string senha)
        {
            DadosDoServico novoServico = new DadosDoServico
            {
                Servico = nomeServico,
                NomeUsuario = usuario,
                Email = email,
                Password = senha
            };

            Console.WriteLine("Verifique as informações");
            Console.WriteLine(novoServico);

            Console.WriteLine("Digite 'sim' se as informações estiverem corretas");
            string resposta = Console.ReadLine().ToLower();

            if (resposta == "sim" || resposta == "s")
            {
                dados.Add(novoServico);
                Console.WriteLine("Serviço adicionado com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Operação cancelada. Serviço não adicionado.");
                //***Adicionar lógica para corrigir as informações
                return false;
            }
        }

        public void Salvar()
        {
            //StringBuilder sb = new StringBuilder();
            //foreach (var servico in dados)
            //{
            //    sb.AppendLine($"Serviço: {servico.Servico}");
            //    sb.AppendLine($"Usuário: {servico.NomeUsuario}");
            //    sb.AppendLine($"Email: {servico.Email}");
            //    sb.AppendLine($"Senha: {servico.Password}");
            //    sb.AppendLine("==============================================");
            //}
            //string textoParaSalvar = sb.ToString();
            string textoParaSalvar = JsonSerializer.Serialize(dados, new JsonSerializerOptions { WriteIndented = true});
            string textoCriptografado = Criptografante.Criptografar(textoParaSalvar, chave);
            File.WriteAllText(Path.Combine(caminhoCompleto, nomeDoArquivo), textoCriptografado);
            Console.WriteLine("Arquivo salvo com sucesso!");
        }

        public string PesquisarSenha(string nomeServico)
        {
            var servico = dados.FirstOrDefault(s => s.Servico.Equals(nomeServico, StringComparison.OrdinalIgnoreCase));
            if (servico != null)
            {
                return servico.Password;
            }
            else
            {
                return "Serviço não encontrado.";
            }
        }
    }
}
