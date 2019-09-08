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

            bool salirAdministracion = false;
            do
            {
                #region Menu.Administracion
                Menu.mostrarTitulo("Módulo de Administración");
                Console.WriteLine("\t1. Ingresar nombre de dominio Taxonómico.\n" +
                                  "\t2. Ingresar nombre por cada Categoria Taxonómico.\n" +
                                  "\t3. Eliminar Especie.\n" +
                                  "\t4. Salir.\n");
                Console.Write("Opcion: "); string opcion = Console.ReadLine();
                #endregion

                #region Opciones
                switch (opcion)
                {
                    #region 1- Ingresar cadena completa en una linea
                    case "1":
                        do
                        {
                            Menu.mostrarTitulo("Módulo de Administración > Dominio completo");
                            Console.WriteLine("\tIngresar nombre de Dominio Taxonomico:\n");

                            string[] nombreDominio = Console.ReadLine().Split('.');
                            Cola<string> colaCategoria = new Cola<string>();
                            if (Validar(colaCategoria, nombreDominio))
                            {
                                arbolAdmin = insetarDominioArbol(enArbol, colaCategoria, 0);

                                Menu.agregadoCorrecto(true);
                            }
                        } while (Menu.repetirOperacion() == 's');
                        break;
                    #endregion

                    #region 2- Ingresar cadena por categorias
                    case "2":
                        do
                        {
                            string[] categorias = new string[] { "Reino", "Filo", "Clase", "Orden", "Familia", "Genero", "Especie" };
                            Cola<string> colaCategoria = new Cola<string>();
                            bool esCorrecto = true;
                            for (int i = 0; i < categorias.Count() && esCorrecto == true; i++)
                            {
                                Menu.mostrarTitulo("Módulo de Administración > Por categoria");
                                Console.WriteLine("\tIngresar nombre de Dominio Taxonomico\n ");
                                Console.WriteLine(categorias[i] + ": ");
                                string nuevaCategoria = Console.ReadLine();
                                if (nuevaCategoria != "" && nuevaCategoria != " ")
                                    colaCategoria.encolarElemento(nuevaCategoria);
                                else
                                {
                                    Menu.agregadoCorrecto(true);
                                }
                            }
                            if (esCorrecto == true)
                            {
                                int nivel = 0;
                                arbolAdmin = insetarDominioArbol(enArbol, colaCategoria, nivel);

                                Menu.agregadoCorrecto(true);
                            }
                        } while (Menu.repetirOperacion() == 's');
                        break;
                    #endregion

                    #region 3- Eliminar Especie
                    case "3":
                        do
                        {
                            Menu.mostrarTitulo(" Eliminar 'Especie'");
                            Console.Write("\nPara eliminar una Especie, debe ingresar su dominio taxonomico correspondiente:\n");

                            string[] nombreDominio = Console.ReadLine().Split('.');
                            Cola<string> colaCategoria = new Cola<string>();
                            if (Validar(colaCategoria, nombreDominio))
                            {
                                if (arbolAdmin.getListaHijos().tamanioLista() == 0)
                                {
                                    Console.WriteLine("El arbol no pose datos.");
                                }
                                else if (eliminarRecorrido(arbolAdmin, nombreDominio))
                                {
                                    Console.WriteLine("Especie '[{0}]' eliminada con exito", nombreDominio[6]);
                                }
                                else
                                {
                                    Console.WriteLine("Especie '{0}' no se encuentra en el Sistema.", nombreDominio[6]);
                                }
                            }
                        } while (Menu.repetirOperacion() == 's');
                        break;
                    #endregion

                    case "4":
                        salirAdministracion = true;
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

            } while (!salirAdministracion);
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
                        string[] especie = solicitarEspecie(cola.tope());
                        ArbolGeneral arbolEspecie = new ArbolGeneral(cola.desencolar(), especie) { NivelNodo = 7 };
                        arbol.agregarHijo(arbolEspecie);
                    }
                    else
                    {
                        arbol.agregarHijo(new ArbolGeneral(cola.desencolar()));
                        Recorredor recorrerArbol = arbol.getListaHijos().getRecorredor();
                        recorrerArbol.comenzar();
                        while (!recorrerArbol.esFin())
                        {
                            if (cola.obtenerAnterior() == (recorrerArbol.obtenerElemento()).getDatoRaiz().Nombre)
                                insetarDominioArbol(recorrerArbol.obtenerElemento(), cola, ++nivel);
                            recorrerArbol.proximo();
                        }
                    }
                }
            }
            return arbol;
        }
        //Cumple la funcion de solicitar los datos de la especie 
        public static string[] solicitarEspecie(string especie)
        {

            #region Secccion Metabolismo
            string seleccionMetabolismo, seleccionReproduccion;
            bool esFin = false;
            string[] especieDatos = new string[2];
            do
            {
                Menu.mostrarTitulo("Modulo Administracion > Especie (Metabolismo) ");
                Console.WriteLine("Elija opción correspondiente al Metabolismo de [{0}]\n " +
                                        "\t<1> Anabolico \n" +
                                        "\t<2> Catabolico\n", especie);
                Console.Write("Opción: "); seleccionMetabolismo = Console.ReadLine();
                switch (seleccionMetabolismo)
                {
                    case "1":
                        especieDatos[0] = "Anabolico";
                        esFin = true;
                        break;
                    case "2":
                        especieDatos[0] = "Catabolico";
                        esFin = true;
                        break;
                    default:
                        Console.WriteLine("\nVolver a intentar.");
                        Console.ReadKey();
                        break;
                }
            } while (!esFin);
            #endregion

            #region  Seccion Reproduccion
            esFin = false;
            do
            {
                Menu.mostrarTitulo("Modulo Administracion > Especie (Reproduccion)");
                Console.WriteLine("Elija opción correspondiente al Metabolismo de [{0}]\n " +
                                        "\t<1> Asexual \n" +
                                        "\t<2> Sexual\n", especie);
                Console.Write("Opción: "); seleccionReproduccion = Console.ReadLine();
                switch (seleccionReproduccion)
                {
                    case "1":
                        especieDatos[1] = "Asexual";
                        esFin = true;
                        break;
                    case "2":
                        especieDatos[1] = "Sexual";
                        esFin = true;
                        break;
                    default:
                        Console.WriteLine("\nVolver a intentar.");
                        Console.ReadKey();
                        break;
                }
            } while (!esFin);
            #endregion

            return especieDatos;

        }
        //Eliminar la especie, indicada como parametro, del arbol
        public static bool eliminarRecorrido(ArbolGeneral arbol, string[] especieDatos)
        {
            if (arbol.esHoja())
            {
                if (arbol.getDatoRaiz().Nombre == especieDatos[6])
                {
                    Console.WriteLine("Especie [{0}] encontrada.", especieDatos[6]);
                    return true;
                }
                return false;
            }
            else
            {
                Recorredor recorrerArbol = arbol.getListaHijos().getRecorredor();
                recorrerArbol.comenzar();
                while (recorrerArbol.esFin() == false)
                {
                    if (eliminarRecorrido(recorrerArbol.obtenerElemento(), especieDatos))
                    {
                        arbol.eliminarHijo(recorrerArbol.obtenerElemento());
                    }
                    recorrerArbol.proximo();
                }
                if (arbol.getListaHijos().tamanioLista() == 0)
                    return true;
                return false;
            }
        }
        //Comprueba las categorias ingresadas
        public static bool Validar(Cola<string> cola, string[] entradaDominio)
        {
            if (entradaDominio.Count() == 7)
            {
                if (!(entradaDominio.Contains("") || entradaDominio.Contains(" ")))
                {
                    foreach (var item in entradaDominio) { cola.encolarElemento(item); }
                    return true;
                }
                Console.WriteLine("Categoria(s) ingresada(s) no validas."); return false;
            }
            else if (entradaDominio.Count() < 7)
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
        public static bool existeCategoria(ArbolGeneral arbol, string colaEntrada)
        {
            Recorredor recorrerArbol = arbol.getListaHijos().getRecorredor();
            recorrerArbol.comenzar();
            while (!recorrerArbol.esFin())
            {
                if (recorrerArbol.obtenerElemento().getDatoRaiz().Nombre == colaEntrada)
                {
                    return true;
                }
                recorrerArbol.proximo();
            }
            return false;
        }
        #endregion
    }
}
