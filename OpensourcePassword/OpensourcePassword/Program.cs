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
    Console.WriteLine("Digite o nome do serviço");
    string nomeServico = Console.ReadLine();
    Console.WriteLine("Digite o nome do usuário");
    string nomeUsuario = Console.ReadLine();
    Console.WriteLine("Digite o email");
    string email = Console.ReadLine();
    Console.WriteLine("Digite a senha");
    string senha = Console.ReadLine();
    gerenciadorSenha.CadastrarNovoServico(nomeServico, nomeUsuario, email, senha);

    Console.WriteLine("Digite 1 para adicionar uma nova senha");
    Console.WriteLine("Digite qualquer outra coisa para salvar");
    string resposta = Console.ReadLine();
    if (resposta == "1")
    {
        AdicionarSenha();
    }
    else
    {
        gerenciadorSenha.Salvar();
        Console.WriteLine("Saindo...");
    }
}