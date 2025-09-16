using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OpensourcePassword.Menus
{
    internal class LerArquivo : Menu
    {
        public override void Mostrar()
        {
            EscreverTitulo("Ler Arquivo");

            Console.WriteLine("Digite o caminho do arquivo de leitura");
            string caminhoArquivo = Console.ReadLine();

            Console.WriteLine("1-Digitar chave no console");
            Console.WriteLine("2-Digitar caminho de um arquivo com chave");
            int escolha = int.Parse(Console.ReadLine());
            byte[] chave = null;
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Digite a chave:");
                    string chaveEscrita = Console.ReadLine();
                    chave = CarregarChaveDoInput(chaveEscrita);
                    Console.WriteLine("Chave carregada com sucesso!");
                    break;
                case 2:
                    Console.WriteLine("Digite o caminho do arquivo:");
                    string caminho = Console.ReadLine();
                    chave = CarregarChaveDoArquivo(caminho);
                    Console.WriteLine("Chave carregada com sucesso!");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
            Ler(caminhoArquivo, chave);
        }

        public void Ler(string caminhoArquivo, byte[]chave)
        {
            string texto = File.ReadAllText(caminhoArquivo);
            string leitura = Criptografante.Descriptografar(texto, chave);
            Console.WriteLine(leitura);
        }

        public byte[] CarregarChaveDoInput(string chaveEscrita)
        {
            byte[] chaveBytes = Convert.FromHexString(chaveEscrita);
            return chaveBytes;
        }

        public byte[] CarregarChaveDoArquivo(string caminho)
        {
            return File.ReadAllBytes(caminho);
        }
    }
}
