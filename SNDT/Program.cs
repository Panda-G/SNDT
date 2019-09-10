using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNDT
{
    class Program
    {
        static void Main(string[] args)
        {
            otroMetodo();
            //Crea instancia del Arbol Principal que se usa durante todo el programac
            ArbolGeneral arbolPrincipal = new ArbolGeneral("Dominio") { NivelNodo = 0 };
            //Pasamos nuestro Arbol (con el que trabajaremos) a clase "Menu"
            Menu.inicio(arbolPrincipal);
            Console.ReadKey();
        }

        private static void otroMetodo()
        {
            ArrayList nuevo = new ArrayList();
            nuevo.Add(2);
            nuevo.Add(10);
            nuevo.Add(5);
            var pos = nuevo.IndexOf(10);//retorna la posicion del elemento si es econtrado, en caso contrario -1
            var existe = nuevo.Contains(5); //retorna true si existe el elemento
            Console.WriteLine("mes " + existe + pos);
            Console.WriteLine(nuevo[pos]);

            string a = null;
            bool s = !String.IsNullOrWhiteSpace(a);//retorna true si "", " " o null...

            string[] arreglo = { "", " " };
            bool estado = arreglo.Contains(" ");
            var cantidad = arreglo.Count();

            Console.WriteLine("   ");
        }
    }
}
