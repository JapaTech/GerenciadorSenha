using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpensourcePassword.Utils
{
    public static class EscreverTextos
    {
        public static void PressioneQualquerTecla(string texto = "Pressione qualquer tecla para continuar...")
        {            
            Console.WriteLine(texto);
            Console.ReadKey();
        }

        public static void EscreverEntreCaracteres(char c, string texto)
        {
            for (int i = 0; i < texto.Length + 4; i++)
            {
                Console.Write(c);
            }
            Console.WriteLine();
            Console.WriteLine(texto);
            for (int i = 0; i < texto.Length + 4; i++)
            {
                Console.Write(c);
            }
        }
    }
}
