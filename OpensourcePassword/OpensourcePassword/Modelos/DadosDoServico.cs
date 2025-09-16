using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpensourcePassword.Modelos
{
    public record DadosDoServico
    {
        public string Servico { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"Serviço: {Servico}\nUsuário: {NomeUsuario}\nEmail: {Email}\nSenha: {Password}\n==============================================";
        }
    }
}
