using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpensourcePassword.Utils
{
    public static class TipoDeArquivo
    {
        public static string TransformaArquivoEmOpsafe(string nomeDoArquivo)
        {
            if (nomeDoArquivo.Contains('.'))
            {
                var stringParaRemover = nomeDoArquivo.Split('.');
                nomeDoArquivo = stringParaRemover[0];
                
            }
            return nomeDoArquivo + ".opsafe";
        }

        public static bool EhArquivoOpsafe(string nomeDoArquivo)
        {
            return nomeDoArquivo.EndsWith(".opsafe", StringComparison.OrdinalIgnoreCase);
        }

    }
}
