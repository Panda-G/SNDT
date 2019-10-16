using System;
using System.Linq;
using System.Threading;

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
                            if (esCorrecto(nombreDominio))
                            {
                                arbolAdmin = insetarDominioArbol(enArbol, nombreDominio, 0);

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
                                //arbolAdmin = insetarDominioArbol(enArbol, colaCategoria, nivel);

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
                            if (esCorrecto(nombreDominio))
                            {
                                if (arbolAdmin.Raiz.ListaHijos.tamanioLista == 0)
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
        public static ArbolGeneral insetarDominioArbol(ArbolGeneral arbol, string[] dominio, int nivel)
        {
            if (nivel <= 7)
            {
                arbol.NivelNodo = nivel;
                if (nivel == 7)
                {
                    if (arbol.Raiz.ListaHijos.nuevoIncluye(dominio[6]) == -1)
                        arbol.agregarHijo(new ArbolGeneral(dominio[6], solicitarEspecie(dominio[6])) { NivelNodo = nivel }); ;
                }
                else
                {
                    arbol.agregarHijo(new ArbolGeneral(dominio[nivel]));
                    Recorredor recorrerArbol = arbol.Raiz.ListaHijos.Recorredor;
                    recorrerArbol.comenzar();
                    while (!recorrerArbol.esFin())
                    {
                        if (dominio[nivel] == (recorrerArbol.obtenerElemento()).Raiz.Dato.Nombre)
                            insetarDominioArbol(recorrerArbol.obtenerElemento(), dominio, ++nivel);
                        recorrerArbol.proximo();
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
                if (arbol.Raiz.Dato.Nombre == especieDatos[6])
                {
                    Console.WriteLine("Especie [{0}] encontrada.", especieDatos[6]);
                    return true;
                }
                return false;
            }
            else
            {
                Recorredor recorrerArbol = arbol.Raiz.ListaHijos.Recorredor;
                recorrerArbol.comenzar();
                while (recorrerArbol.esFin() == false)
                {
                    if (eliminarRecorrido(recorrerArbol.obtenerElemento(), especieDatos))
                    {
                        arbol.eliminarHijo(recorrerArbol.obtenerElemento());
                    }
                    recorrerArbol.proximo();
                }
                if (arbol.Raiz.ListaHijos.tamanioLista == 0)
                    return true;
                return false;
            }
        }
        //Comprueba las categorias ingresadas
        public static bool esCorrecto(string[] entradaDominio)
        {
            if (entradaDominio.Count() == 7)
            {
                if (!(entradaDominio.Contains("") || entradaDominio.Contains(" ")))
                    return true;
                Console.WriteLine("Categoria(s) ingresada(s) no validas.");
                return false;
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
        #endregion
    }
}
