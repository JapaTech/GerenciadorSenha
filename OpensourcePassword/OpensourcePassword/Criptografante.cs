using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OpensourcePassword
{
    public static class Criptografante
    {
        const int ivSize = 16;

        public static string Criptografar(string texto, byte[] chave)
        {
            using Aes aes = Aes.Create();
            aes.Key = chave;
            aes.IV = RandomNumberGenerator.GetBytes(ivSize);

            using var memoryStream = new MemoryStream();
            memoryStream.Write(aes.IV, 0, ivSize);

            using (var encryptor = aes.CreateEncryptor())
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            using (var streamWriter = new StreamWriter(cryptoStream))
            {
                streamWriter.Write(texto);
            }
            
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public static string Descriptografar(string textoCifrado, byte[] chave)
        {
            try
            {
                byte[] dadosDaCifra = Convert.FromBase64String(textoCifrado);

                if (dadosDaCifra.Length < ivSize)
                {
                    throw new InvalidOperationException("Cifra invalida");
                }

                byte[] iv = new byte[ivSize];
                byte[] dadosEncriptados = new byte[dadosDaCifra.Length - ivSize];

                Buffer.BlockCopy(dadosDaCifra, 0, iv, 0, ivSize);
                Buffer.BlockCopy(dadosDaCifra, ivSize, dadosEncriptados, 0, dadosEncriptados.Length);

                using var aes = Aes.Create();
                aes.Key = chave;
                aes.IV = iv;

                using MemoryStream memoryStream = new (dadosEncriptados);
                using var decriptador = aes.CreateDecryptor();
                using var cryptoStream = new CryptoStream(memoryStream, decriptador, CryptoStreamMode.Read);
                using var streamReader = new StreamReader(cryptoStream);

                return streamReader.ReadToEnd();
            }
            catch (CryptographicException ex)
            {

                throw new InvalidOperationException("Decriptação falhou", ex);
            }
        }
    }
}
