// See https://aka.ms/new-console-template for more information
using OpensourcePassword;
using OpensourcePassword.Modelos;

GerenciadorSenha gerenciadorSenha ;

Console.WriteLine("Você deseja: ");
Console.WriteLine("1-Criar novo arquivo de criptografia");
Console.WriteLine("2-Ler arquivo de criptografia existente");
Console.WriteLine("3-Editar arqivo de criptografia");
int	 escolha = int.Parse(Console.ReadLine());


switch (escolha)
{
	case 1:
        CriaArquivorSenha();
        break;
    case 2:
		var menuLerArquivo = new OpensourcePassword.Menus.LerArquivo();
		menuLerArquivo.Mostrar();
		break;
    default:
		break;
}

void CriaArquivorSenha()
{
    Console.WriteLine("Digite o caminho para salvar o arquivo");
    string caminho = Console.ReadLine();
    Console.WriteLine("Digite o nome do arquivo");
    string nomeDoArquivo = Console.ReadLine();
    byte[] chave = GerenciadorChave.GerarChaveAletoria();
    gerenciadorSenha = new GerenciadorSenha(chave, caminho, nomeDoArquivo);
    AdicionarSenha();
}

void AdicionarSenha()
{
    bool adicionarNovo = true;

    while (adicionarNovo)
    {
        Console.WriteLine("----Novo serviço----");
        Console.Write("Digite o nome do serviço: ");
        string nomeServico = Console.ReadLine();

        Console.Write("Digite o nome do usuário: ");
        string nomeUsuario = Console.ReadLine();

        Console.Write("Digite o email: ");
        string email = Console.ReadLine();

        Console.Write("Digite a senha: ");
        string senha = Console.ReadLine();

        bool casdratoRealizado = false;

        while (!casdratoRealizado)
        {
            casdratoRealizado = gerenciadorSenha.CadastrarNovoServico(nomeServico, nomeUsuario, email, senha);

            if (!casdratoRealizado)
            {
                Console.WriteLine("Digite 'sim' para corrigir as informações");
                string corrigir = Console.ReadLine().ToLower();
                if (corrigir != "sim")
                {
                    return;
                }
            }
        }

        Console.WriteLine("Digite 'sim' para adicionar uma nova senha");
        Console.WriteLine("Ou Digite qualquer outra coisa para salvar");
        string resposta = Console.ReadLine().ToLower();

        adicionarNovo = resposta == "sim";
    }

    gerenciadorSenha.Salvar();
    Console.WriteLine("Saindo...");
}
