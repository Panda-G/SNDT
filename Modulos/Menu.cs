﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNDT.ClasesUtilizadas;
using System.Threading;

namespace SNDT.Modulos
{
    public class Menu
    {
        private ArbolGeneral ArbolPrincipal;

        //"inicio" contiene la primer vista del programa, mostrando los modulos disponibles
        public void inicio(ArbolGeneral inArbolGeneral)
        {
            this.ArbolPrincipal = inArbolGeneral;
            bool salirMenu = false;
            do
            {
                #region Menu
                menuMostrarTitulo(" ");
                Console.WriteLine("\t1. Modulo de Administracion\n" +
                                  "\t2. Modulo de Consultas\n" +
                                  "\t3. Salir\n");
                Console.Write("\nOpcion: "); string opcion = Console.ReadLine();
                #endregion

                #region Opciones
                switch (opcion)
                {
                    case "1":
                        SubMenuAdministracion administracion = new SubMenuAdministracion();
                        administracion.initAdmin(inArbolGeneral);
                        break;
                    case "2":
                        SubMenuConsulta consultas = new SubMenuConsulta();
                        consultas.initConsulta(inArbolGeneral);
                        break;
                    case "3":
                        salirMenu = true;
                        Console.WriteLine("Presione una tecla para salir...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        Console.ReadKey();
                        break;
                } 
                #endregion

            } while (!salirMenu);
        }

        #region Metodos
        public static void menuMostrarTitulo(string espacio)
        {
            Console.Clear();
            Console.Write("\n [  [ [Sistema de Nombres de Dominio Taxonómico (SNDT)] ]  ]\n " +
                          "\n[=> Menu > " + espacio + "\n\n");
        }

        public static char obtenerRespusta()
        {
            try
            {
                Console.Write("¿Desea respetir proceso? (s/n): ");
                return Convert.ToChar(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Write("Opcion no valida, presione una tecla para salir...");
                Console.ReadKey();
                return 'n';
            }

        }
        public static void estadoDeInsercion(bool estado)
        {
            if (estado)
            {
                Console.Write("\n\nDetalle:\tEl dominio Taxonomico se ha ingresado correctamente.\n");
                Thread.Sleep(800);
            }
            else
            {
                Console.Write("\n\nDetalle:\tHa ocurrido un error al agregar el nuevo Dominio.\n");
                Thread.Sleep(800);
            }
        }
        public static char repetirOperacion()
        {
            try
            {
                Console.Write("¿Desea respetir proceso? (s/n): ");
                return Convert.ToChar(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Write("Opcion no valida, presione una tecla para salir...");
                Console.ReadKey();
                return 'n';
            }

        }
        #endregion

    }
}

