using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNDT
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crea instancia del Arbol Principal que se usa durante todo el programac
            ArbolGeneral arbolPrincipal = new ArbolGeneral("Dominio") { NivelNodo = 0 };
            //Pasamos nuestro Arbol (con el que trabajaremos) a clase "Menu"
            Menu.inicio(arbolPrincipal);
            Console.ReadKey();
        }
    }
}
