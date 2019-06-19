using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNDT.ClasesUtilizadas;
using System.Threading;
using System.Collections;

namespace SNDT.Modulos
{
    public class SubMenuConsulta
    {
        ArbolGeneral arbolConsulta;

        public void initConsulta(ArbolGeneral arbol)
        {
            this.arbolConsulta = arbol;

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
                                if (!existeEspecie(this.arbolConsulta, especieBusqueda))
                                {
                                    Console.WriteLine("\nLa Especie ingresada '{0}' no existe.\n\nPulse una tecla para salir...", especieBusqueda);
                                }
                                Console.ReadKey();
                                resp = Menu.obtenerRespusta();
                            } while (char.ToLower(resp) == 's');
                            break;
                        #endregion

                        #region 2- Ver las especies de una clase
                        case "2":
                            do
                            {
                                Menu.menuMostrarTitulo("Módulo de Consultas > Especies de Clase");
                                Console.WriteLine(">Clase: "); string claseBusqueda = Console.ReadLine();
                                if (!existeClase(this.arbolConsulta, claseBusqueda))
                                {
                                    Console.WriteLine("\nLa Clase ingresada '{0}' no existe.\n\nPulse una tecla para salir...", claseBusqueda);
                                }
                                Console.ReadKey();
                                resp = Menu.obtenerRespusta();
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
                                    proCategorias(this.arbolConsulta, profundidad);
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("El valor ingresado no es un numero ");
                                }
                                Console.ReadKey();
                                resp = Menu.obtenerRespusta();
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

        public void proCategorias(ArbolGeneral inArbol, int profundidad)
        {
            if (inArbol.esHoja() || inArbol.getnivel() == profundidad)
            {
                Console.WriteLine("> {0}", inArbol.getDatoRaiz().getNombre());
            }
            else
            {
                Recorredor rec = new Recorredor(inArbol.getHijos());
                rec.comenzar();
                while (!rec.fin())
                {
                    proCategorias((ArbolGeneral)rec.elemento(), profundidad);
                    rec.proximo();
                }
            }
        }

        public static bool existeEspecie(ArbolGeneral inArbol, string especieBusqueda)
        {
            if (inArbol.esHoja())
            {
                if (inArbol.getDatoRaiz().getNombre() == especieBusqueda)
                {
                    Console.WriteLine("Especie: {0} " +
                                      "\n\tMetabolismo: {1}" +
                                      "\n\tReproduccion: {2}",
                    especieBusqueda,
                    ((Especie)inArbol.getDatoRaiz()).getDatoMEspecie(),
                    ((Especie)inArbol.getDatoRaiz()).getDatosREspecie());
                    return true;
                }
                return false;
            }
            else
            {
                Recorredor rec = new Recorredor(inArbol.getHijos());
                rec.comenzar();
                while (!rec.fin())
                {
                    if (existeEspecie((ArbolGeneral)rec.elemento(), especieBusqueda))
                        return true;
                    rec.proximo();
                }
                return false;
            }
        }

        public bool existeClase(ArbolGeneral inArbol, string inClase)
        {
            if (inArbol.getnivel() == 3)
            {
                if (inArbol.getDatoRaiz().getNombre() == inClase)
                {
                    metBuscarEspecieClase(inArbol);
                    return true;
                }
                return false;
            }
            else
            {
                Recorredor rec = new Recorredor(inArbol.getHijos());
                rec.comenzar();
                while (!rec.fin())
                {
                    if (existeClase((ArbolGeneral)rec.elemento(), inClase))
                        return true;
                    rec.proximo();
                }
                return false;
            }
        }

        public void metBuscarEspecieClase(ArbolGeneral inArbol)
        {
            if (inArbol.esHoja())
            {
                Console.WriteLine("\n>Especie: ({0})" +
                                        "\n\t>Metabolismo: {1}" +
                                        "\n\t>Reproduccion: {2}",
                  ((Especie)inArbol.getDatoRaiz()).getNombre(),
                  ((Especie)inArbol.getDatoRaiz()).getDatoMEspecie(),
                  ((Especie)inArbol.getDatoRaiz()).getDatosREspecie());
            }
            else
            {
                Recorredor rec = new Recorredor(inArbol.getHijos());
                rec.comenzar();
                while (!rec.fin())
                {
                    metBuscarEspecieClase((ArbolGeneral)rec.elemento());
                    rec.proximo();
                }
            }
        } 
        #endregion

    }
}
