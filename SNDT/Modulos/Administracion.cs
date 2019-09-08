using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace SNDT
{
    public static class Administracion
    {
        private static ArbolGeneral arbolAdmin;
        public static void inicioAdmin(ArbolGeneral enArbol)
        {
            arbolAdmin = enArbol;

            bool salirMenuAdmin = false;
            do
            {
                #region Menu.Administracion
                Menu.menuMostrarTitulo("Módulo de Administración");
                Console.WriteLine("\t1. Ingresar nombre de dominio Taxonómico.\n" +
                                  "\t2. Ingresar nombre por cada Categoria Taxonómico.\n" +
                                  "\t3. Eliminar Especie.\n" +
                                  "\t4. Salir.\n");
                Console.Write("Opcion: "); string opcion = Console.ReadLine();
                #endregion

                #region Opciones
                switch (opcion)
                {
                    #region 1- Ingresar cadena completa
                    case "1":
                        do
                        {
                            Menu.menuMostrarTitulo("Módulo de Administración > Dominio completo");
                            Console.WriteLine("\tIngresar nombre de Dominio Taxonomico:\n");

                            string[] nombreDominio = Console.ReadLine().Split('.');
                            Cola<string> objCola = new Cola<string>();
                            if (Validar(objCola, nombreDominio))
                            {
                                int nivel = 0;
                                arbolAdmin = insetarDominioArbol(enArbol, objCola, nivel);

                                Console.Write("\n\nDetalle:\tEl dominio Taxonomico se ha ingresado correctamente.\n");
                                Thread.Sleep(800);
                            }
                        } while (Menu.repetirOperacion() == 's');
                        break;
                    #endregion

                    #region 2- Ingresar cadena por categorias
                    case "2":
                        do
                        {
                            string[] categorias = new string[] { "Reino", "Filo", "Clase", "Orden", "Familia", "Genero", "Especie" };
                            Cola<string> cola = new Cola<string>();
                            bool cateValida = true;
                            for (int i = 0; i < categorias.Count() && cateValida == true; i++)
                            {
                                Menu.menuMostrarTitulo("Módulo de Administración > Por categoria");
                                Console.WriteLine("\tIngresar nombre de Dominio Taxonomico\n ");
                                Console.WriteLine(categorias[i] + ": ");
                                string categoria = Console.ReadLine();
                                if (categoria != "" && categoria != " ")
                                    cola.encolarElemento(categoria);
                                else
                                {
                                    Console.WriteLine("\nCategoria(s) ingresada(s) no validas.");
                                    cateValida = false;
                                }
                            }
                            if (cateValida == true)
                            {
                                int nivel = 0;
                                arbolAdmin = insetarDominioArbol(enArbol, cola, nivel);

                                Console.Write("\n\nDetalle:\tEl dominio Taxonomico se ha ingresado correctamente.\n");
                                Thread.Sleep(800);
                            }
                        } while (Menu.repetirOperacion() == 's');
                        break;
                    #endregion

                    #region 3- Eliminar Especie
                    case "3":
                        do
                        {
                            Menu.menuMostrarTitulo(" Eliminar 'Especie'");
                            Console.Write("\nPara eliminar una Especie, debe ingresar su dominio taxonomico correspondiente:\n");

                            string[] nDominio = Console.ReadLine().Split('.');
                            Cola<string> cola = new Cola<string>();
                            if (Validar(cola, nDominio))
                            {
                                if (arbolAdmin.getListaHijos().obtenerTamanio() == 0)
                                {
                                    Console.WriteLine("El arbol no pose datos.");
                                }
                                else if (eliminarRecorrido(arbolAdmin, nDominio))
                                {
                                    Console.WriteLine("Especie '[{0}]' eliminada con exito", nDominio[6]);
                                }
                                else
                                {
                                    Console.WriteLine("Especie '{0}' no se encuentra en el Sistema.", nDominio[6]);
                                }
                            }
                        } while (Menu.repetirOperacion() == 's');
                        break;
                    #endregion

                    case "4":
                        salirMenuAdmin = true;
                        Console.WriteLine("Regresando al Menu.");
                        Thread.Sleep(400);
                        break;
                    case "5":
                        arbolAdmin.recorridoPreOrden();
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        Console.ReadKey();
                        break;
                }
                #endregion

            } while (!salirMenuAdmin);
        }

        #region Metodos
        //Se encargarga de insertar el dominio al arbol
        public static ArbolGeneral insetarDominioArbol(ArbolGeneral arbol, Cola<string> cola, int nivel)
        {
            if (!cola.esVacia())
            {
                arbol.NivelNodo = nivel;
                if (existeCategoria(arbol, cola.tope()))
                {
                    Recorredor rec = arbol.getListaHijos().getRecorredor();
                    rec.comenzar();
                    while (!rec.esFin())
                    {
                        if (!cola.esVacia() && rec.obtenerElemento().getDatoRaiz().Nombre == cola.tope())
                        {
                            cola.desencolar();
                            insetarDominioArbol(rec.obtenerElemento(), cola, ++nivel);
                        }
                        rec.proximo();
                    }
                }
                else
                {
                    if (cola.obtenerCantidad() == 1)
                    {
                        string[] especie = metIngresarDatosEspecie(cola.tope());
                        ArbolGeneral arbolEspecie = new ArbolGeneral(cola.desencolar(), especie);
                        arbolEspecie.NivelNodo= 7;
                        arbol.agregarHijo(arbolEspecie);
                    }
                    else
                    {
                        arbol.agregarHijo(new ArbolGeneral(cola.desencolar()));
                        Recorredor rec = arbol.getListaHijos().getRecorredor();
                        rec.comenzar();
                        while (!rec.esFin())
                        {
                            if (cola.obtenerAnterior() == (rec.obtenerElemento()).getDatoRaiz().Nombre)
                                insetarDominioArbol(rec.obtenerElemento(), cola, ++nivel);
                            rec.proximo();
                        }
                    }
                }
            }
            return arbol;
        }
        //Cumple la funcion de solicitar los datos de la especie 
        public static string[] metIngresarDatosEspecie(string inEspecie)
        {

            #region Secccion Metabolismo
            string opm = "0", opr = "0";
            bool fin = false;
            string[] especie = new string[2];
            do
            {
                Menu.menuMostrarTitulo("Modulo Administracion > Especie (Metabolismo) ");
                Console.WriteLine("Elija opción correspondiente al Metabolismo de [{0}]\n " +
                                        "\t<1> Anabolico \n" +
                                        "\t<2> Catabolico\n", inEspecie);
                Console.Write("Opción: "); opm = Console.ReadLine();
                switch (opm)
                {
                    case "1":
                        especie[0] = "Anabolico";
                        fin = true;
                        break;
                    case "2":
                        especie[0] = "Catabolico";
                        fin = true;
                        break;
                    default:
                        Console.WriteLine("\nVolver a intentar.");
                        Console.ReadKey();
                        break;
                }
            } while (!fin);
            #endregion

            #region  Seccion Reproduccion
            fin = false;
            do
            {
                Menu.menuMostrarTitulo("Modulo Administracion > Especie (Reproduccion)");
                Console.WriteLine("Elija opción correspondiente al Metabolismo de [{0}]\n " +
                                        "\t<1> Asexual \n" +
                                        "\t<2> Sexual\n", inEspecie);
                Console.Write("Opción: "); opr = Console.ReadLine();
                switch (opr)
                {
                    case "1":
                        especie[1] = "Asexual";
                        fin = true;
                        break;
                    case "2":
                        especie[1] = "Sexual";
                        fin = true;
                        break;
                    default:
                        Console.WriteLine("\nVolver a intentar.");
                        Console.ReadKey();
                        break;
                }
            } while (!fin);
            #endregion

            return especie;

        }
        //Eliminar la especie, indicada como parametro, del arbol
        public static bool eliminarRecorrido(ArbolGeneral arbol, string[] inEspecie)
        {
            if (arbol.esHoja())
            {
                if (arbol.getDatoRaiz().Nombre == inEspecie[6])
                {
                    Console.WriteLine("Especie [{0}] encontrada.", inEspecie[6]);
                    return true;
                }
                return false;
            }
            else
            {
                Recorredor rec = arbol.getListaHijos().getRecorredor();
                rec.comenzar();
                while (rec.esFin() == false)
                {
                    if (eliminarRecorrido(rec.obtenerElemento(), inEspecie))
                    {
                        arbol.eliminarHijo(rec.obtenerElemento());
                    }
                    rec.proximo();
                }
                if (arbol.getListaHijos().obtenerTamanio() == 0)
                    return true;
                return false;
            }
        }
        //Comprueba las categorias ingresadas
        public static bool Validar(Cola<string> cola, string[] entrada)
        {
            if (entrada.Count() == 7)
            {
                if (!(entrada.Contains("") || entrada.Contains(" ")))
                {
                    foreach (var item in entrada) { cola.encolarElemento(item); }
                    return true;
                }
                Console.WriteLine("Categoria(s) ingresada(s) no validas."); return false;
            }
            else if (entrada.Count() < 7)
            {
                Console.WriteLine("\nFalta(n) Categoria(s), intentar nuevamente.");
                Thread.Sleep(800); return false;
            }
            else
            {
                Console.WriteLine("\nLas Categoria(s) ingresada(s) supera el limite (7)");
                Thread.Sleep(800); return false;
            }
        }
        //Retorna True, si la categoria ya existe, y False en caso contrario
        public static bool existeCategoria(ArbolGeneral arbol, string inCola)
        {
            Recorredor rec = arbol.getListaHijos().getRecorredor();
            rec.comenzar();
            while (!rec.esFin())
            {
                if (rec.obtenerElemento().getDatoRaiz().Nombre == inCola)
                {
                    return true;
                }
                rec.proximo();
            }
            return false;
        }

        #endregion

    }
}
