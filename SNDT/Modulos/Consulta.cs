﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace SNDT
{
    public static class Consulta
    {
        private static ArbolGeneral arbolConsulta;

        public static void inicioConsulta(ArbolGeneral arbol)
        {
            arbolConsulta = arbol;

            if (!arbolConsulta.esHoja())
            {

                bool salirMenuConsulta = false;
                do
                {
                    #region  Menu.Consultas
                    Menu.menuMostrarTitulo("Módulo de Consultas");
                    Console.WriteLine("\t1. Ver datos de especie\n" +
                                      "\t2. Ingrese una Clase\n" +
                                      "\t3. Ingrese profundidad\n" +
                                      "\t4. Salir\n");
                    Console.Write("Opcion: "); string opcion = Console.ReadLine();
                    #endregion

                    #region Opciones
                    char resp = ' ';

                    switch (opcion)
                    {
                        #region 1- Ver datos de especie seleccionada
                        case "1":
                            do
                            {
                                Menu.menuMostrarTitulo("Módulo de Consultas > Datos Especie");
                                Console.WriteLine("Ingrese el nombre de la Especie que desea conocer.\n");
                                Console.Write(">Especie: "); string especieBusqueda = Console.ReadLine();
                                //buscarCategoria29(this.arbolConsulta, especieBusqueda);
                                if (!existeEspecie(arbolConsulta, especieBusqueda))
                                {
                                    Console.WriteLine("\nLa Especie ingresada '{0}' no existe.\n\nPulse una tecla para salir...", especieBusqueda);
                                }
                                Console.ReadKey();
                                resp = Menu.repetirOperacion();
                            } while (char.ToLower(resp) == 's');
                            break;
                        #endregion

                        #region 2- Ver las especies de una clase
                        case "2":
                            do
                            {
                                Menu.menuMostrarTitulo("Módulo de Consultas > Especies de Clase");
                                Console.WriteLine(">Clase: "); string claseBusqueda = Console.ReadLine();
                                if (!existeClase(arbolConsulta, claseBusqueda))
                                {
                                    Console.WriteLine("\nLa Clase ingresada '{0}' no existe.\n\nPulse una tecla para salir...", claseBusqueda);
                                }
                                Console.ReadKey();
                                resp = Menu.repetirOperacion();
                            } while (char.ToLower(resp) == 's');
                            break;
                        #endregion

                        #region 3- Ver las categorias existentes en una profundidad

                        case "3":
                            do
                            {
                                int[] numeros = { 1, 2, 3, 4, 5, 6, 7 };
                                Menu.menuMostrarTitulo("Módulo de Consultas > Categorias por Profundidad");
                                Console.WriteLine(">Profundidad: ");
                                try
                                {
                                    int profundidad = Convert.ToInt16(Console.ReadLine());
                                    proCategorias(arbolConsulta, profundidad);
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("El valor ingresado no es un numero ");
                                }
                                Console.ReadKey();
                                resp = Menu.repetirOperacion();
                            } while (char.ToLower(resp) == 's');
                            break;
                        #endregion

                        case "4":
                            salirMenuConsulta = true;
                            Console.WriteLine("Regresando al Menu.");
                            Thread.Sleep(400);
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            Console.ReadKey();
                            break;

                    }
                    #endregion

                } while (!salirMenuConsulta);
            }
            else
            {
                Console.Write("\n\nDetalle:\tEl Sistema Taxonomico no posee datos.\n");
                Console.ReadKey();
            }
        }

        #region Metodos

        public static void proCategorias(ArbolGeneral enArbol, int profundidad)
        {
            if (enArbol.esHoja() || enArbol.NivelNodo == profundidad)
            {
                Console.WriteLine("> {0}", enArbol.getDatoRaiz().Nombre);
            }
            else
            {
                Recorredor rec = enArbol.getListaHijos().getRecorredor();
                rec.comenzar();
                while (!rec.esFin())
                {
                    proCategorias((ArbolGeneral)rec.obtenerElemento(), profundidad);
                    rec.proximo();
                }
            }
        }

        public static bool existeEspecie(ArbolGeneral enArbol, string especieBusqueda)
        {
            if (enArbol.esHoja())
            {
                if (enArbol.getDatoRaiz().Nombre == especieBusqueda)
                {
                    Console.WriteLine("Especie: {0} " +
                                      "\n\tMetabolismo: {1}" +
                                      "\n\tReproduccion: {2}",
                    especieBusqueda,
                    ((Especie)enArbol.getDatoRaiz()).Dato.Metabolismo,
                    ((Especie)enArbol.getDatoRaiz()).Dato.Reproduccion);
                    return true;
                }
                return false;
            }
            else
            {
                Recorredor rec = enArbol.getListaHijos().getRecorredor();
                rec.comenzar();
                while (!rec.esFin())
                {
                    if (existeEspecie((ArbolGeneral)rec.obtenerElemento(), especieBusqueda))
                        return true;
                    rec.proximo();
                }
                return false;
            }
        }

        public static bool existeClase(ArbolGeneral enArbol, string enClase)
        {
            if (enArbol.NivelNodo == 3)
            {
                if (enArbol.getDatoRaiz().Nombre == enClase)
                {
                    metBuscarEspecieClase(enArbol);
                    return true;
                }
                return false;
            }
            else
            {
                Recorredor rec = enArbol.getListaHijos().getRecorredor();
                rec.comenzar();
                while (!rec.esFin())
                {
                    if (existeClase((ArbolGeneral)rec.obtenerElemento(), enClase))
                        return true;
                    rec.proximo();
                }
                return false;
            }
        }

        public static void metBuscarEspecieClase(ArbolGeneral enArbol)
        {
            if (enArbol.esHoja())
            {
                Console.WriteLine("\n>Especie: ({0})" +
                                        "\n\t>Metabolismo: {1}" +
                                        "\n\t>Reproduccion: {2}",
                  ((Especie)enArbol.getDatoRaiz()).Nombre,
                  ((Especie)enArbol.getDatoRaiz()).Dato.Metabolismo,
                  ((Especie)enArbol.getDatoRaiz()).Dato.Reproduccion);
            }
            else
            {
                Recorredor rec = enArbol.getListaHijos().getRecorredor();
                //Recorredor rec = new Recorredor(inArbol.getHijos());
                rec.comenzar();
                while (!rec.esFin())
                {
                    metBuscarEspecieClase((ArbolGeneral)rec.obtenerElemento());
                    rec.proximo();
                }
            }
        }
        #endregion

    }
}
