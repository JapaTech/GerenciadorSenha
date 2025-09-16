using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpensourcePassword.Menus
{
    abstract class Menu
    {
        public void EscreverTitulo(string titulo)
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine(titulo);
            Console.WriteLine("==============================================");
        }

        public abstract void Mostrar();
        
    }
}
