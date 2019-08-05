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

            ListaConArreglo mueva = new ListaConArreglo();
            bool das = mueva.esVacia();
            mueva.agregar(1);
            mueva.agregar(2);
            mueva.agregar(3);
            if (mueva.incluye(2))
            {
                Console.WriteLine("func");
            }

            mueva.eliminar(2);
            mueva.agregar(4);
            int i = (int)mueva.elemento(1);

            Recorredor rec = mueva.Recorredor();


            List<string> nombre = new List<string>();
            nombre.Add("a");
            nombre.Add("b");

            //foreach (string item in nombre)
            //{
            //    item = "d";
            //}

            //Crea instancia del Arbol Principal que se usa durante todo el programac
            ArbolGeneral arbolGeneral = new ArbolGeneral("Dominio");
            arbolGeneral.Nivel = 0;
            Menu objMenu = new Menu();
            //Pasamos el objeto Arbol creado a una clase "Menu"
            objMenu.inicio(arbolGeneral);
            Console.ReadKey();
        }
    }
}
