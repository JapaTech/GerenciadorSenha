using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OpensourcePassword
{
    public static class GerenciadorChave
    {
        public static byte[] GerarChaveAletoria()
        {
            var chave = RandomNumberGenerator.GetBytes(32);
            string chaveHex = Convert.ToHexString(chave);
            Console.WriteLine("Guarde sua chave. Sem ela você não acessará seu arquivo");
            EscreverTextos.EscreverEntreCaracteres('!', chaveHex);
            Console.WriteLine("\n");
            EscreverTextos.PressioneQualquerTecla("Pressione uma tecla");
            EscreverTextos.PressioneQualquerTecla("\n!- Se você guardou sua chave, pressione uma tecla para continuar -!");

            return chave;
        }

        public static void SalvarChave(byte[] chave, string caminho)
        {
            Console.WriteLine("A chave foi salva em: ");
            File.WriteAllBytes(caminho, chave);
            Console.WriteLine("==============================================");
            Console.WriteLine(caminho);
            Console.WriteLine("==============================================");
        }

        public static byte[] CarregarChave(string caminho)
        {
            return File.ReadAllBytes(caminho);
        }
    }
}
