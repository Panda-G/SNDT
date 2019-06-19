using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SNDT.ClasesUtilizadas;
using SNDT.Modulos;

namespace SNDT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ");
            //Crea instancia del Arbol Principal que se usa durante todo el programac
            ArbolGeneral arbolGeneral = new ArbolGeneral(new NodoGeneral(new TipoDominio("Dominio")));
            arbolGeneral.setnivel(0);
            Menu objMenu = new Menu();
            //Pasamos el objeto Arbol creado a una clase "Menu"
            objMenu.inicio(arbolGeneral);
            Console.ReadKey();
        }
    }
}
