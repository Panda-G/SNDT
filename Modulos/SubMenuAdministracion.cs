using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SNDT.ClasesUtilizadas;
using System.Collections;

namespace SNDT.Modulos
{
    public class SubMenuAdministracion
    {
        ArbolGeneral arbolAdmin;

        public void initAdmin(ArbolGeneral arbol)
        {
            this.arbolAdmin = arbol;

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
                char resp = ' ';
                switch (opcion)
                {
                    #region 1- Ingresar cadena completa
                    case "1":
                        do
                        {
                            Menu.menuMostrarTitulo("Módulo de Administración > Dominio completo");
                            Console.WriteLine("\tIngresar nombre de Dominio Taxonomico:\n");

                            string cadena = Console.ReadLine();
                            string[] nDominio = cadena.Split('.');
                            Cola<string> objCola = new Cola<string>();
                            if (this.Validar(arbol, objCola, nDominio))
                            {
                                int nivel = 0;
                                this.arbolAdmin = insetarDominioArbol(arbol, objCola, nivel);

                                Console.Write("\n\nDetalle:\tEl dominio Taxonomico se ha ingresado correctamente.\n");
                                Thread.Sleep(800);
                            }
                            resp = Menu.obtenerRespusta();
                        } while (char.ToLower(resp) == 's');
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
                                    cola.encolar(categoria);
                                else
                                {
                                    Console.WriteLine("\nCategoria(s) ingresada(s) no validas.");
                                    cateValida = false;
                                }
                            }
                            if (cateValida == true)
                            {
                                int nivel = 0;
                                this.arbolAdmin = insetarDominioArbol(arbol, cola, nivel);

                                Console.Write("\n\nDetalle:\tEl dominio Taxonomico se ha ingresado correctamente.\n");
                                Thread.Sleep(800);
                            }
                            resp = Menu.obtenerRespusta();
                        } while (char.ToLower(resp) == 's');
                        break;
                    #endregion

                    #region 3- Eliminar Especie
                    case "3":
                        do
                        {
                            Menu.menuMostrarTitulo(" Eliminar 'Especie'");
                            Console.Write("\nEspecie: "); string nombreEspecie = Console.ReadLine();
                            if (this.arbolAdmin.getHijos().getTamanio() == 0)
                            {
                                Console.WriteLine("El arbol no pose datos.");
                            }
                            else if (!SubMenuConsulta.existeEspecie(this.arbolAdmin, nombreEspecie))
                            {
                                Console.WriteLine("Especie '{0}' no se encuentra en el Sistema.", nombreEspecie);
                            }
                            else eliminarRecorrido(this.arbolAdmin, nombreEspecie);
                            resp = Menu.obtenerRespusta();
                        } while (char.ToLower(resp) == 's');
                        break;
                    #endregion

                    case "4":
                        salirMenuAdmin = true;
                        Console.WriteLine("Regresando al Menu.");
                        Thread.Sleep(400);
                        break;
                    case "5":
                        this.arbolAdmin.recorridoPreOrden();
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
        public ArbolGeneral insetarDominioArbol(ArbolGeneral arbol, Cola<string> cola, int nivel)
        {
            if (!cola.esVacia())
            {
                arbol.setnivel(nivel);
                if (existeCategoria(arbol, cola.tope()))
                {
                    Recorredor rec = new Recorredor(arbol.getHijos());
                    rec.comenzar();
                    while (!rec.fin())
                    {
                        if (!cola.esVacia() && ((ArbolGeneral)rec.elemento()).getDatoRaiz().getNombre() == cola.tope())
                        {
                            cola.desencolar();
                            insetarDominioArbol((ArbolGeneral)rec.elemento(), cola, ++nivel);
                        }
                        rec.proximo();
                    }
                }
                else
                {
                    if (cola.getNumeroElementos() == 1)
                    {
                        string[] especie = metIngresarDatosEspecie(cola.tope());
                        ArbolGeneral arbolEspecie = new ArbolGeneral(new NodoGeneral(new Especie(cola.desencolar(), especie[0], especie[1])));
                        arbolEspecie.setnivel(7);
                        arbol.agregarHijo(arbolEspecie);
                    }
                    else
                    {
                        arbol.agregarHijo(new ArbolGeneral(new NodoGeneral(new TipoDominio(cola.desencolar()))));
                        Recorredor rec = new Recorredor(arbol.getHijos());
                        rec.comenzar();
                        while (!rec.fin())
                        {
                            if (cola.getAnterior() == ((ArbolGeneral)rec.elemento()).getDatoRaiz().getNombre())
                                insetarDominioArbol((ArbolGeneral)rec.elemento(), cola, ++nivel);
                            rec.proximo();
                        }
                    }
                }
            }
            return arbol;
        }
        //Cumple la funcion de solicitar los datos de la especie 
        public string[] metIngresarDatosEspecie(string inEspecie)
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
        public bool eliminarRecorrido(ArbolGeneral arbol, string inEspecie)
        {
            if (arbol.esHoja())
            {
                if (arbol.getDatoRaiz().getNombre() == inEspecie)
                {
                    Console.WriteLine("Especie [{0}] encontrada.", inEspecie);
                    return true;
                }
                return false;
            }
            else
            {
                Recorredor rec = new Recorredor(arbol.getHijos());
                rec.comenzar();
                while (rec.fin() == false)
                {
                    if (eliminarRecorrido(((ArbolGeneral)rec.elemento()), inEspecie))
                    {
                        arbol.eliminarHijo(((ArbolGeneral)rec.elemento()));
                    }
                    rec.proximo();
                }
                if (arbol.getHijos().getTamanio() == 0)
                    return true;
                return false;
            }
        }
        //Comprueba las categorias ingresadas
        public bool Validar(ArbolGeneral arbol, Cola<string> cola, string[] entrada)
        {
            if (entrada.Count() == 7)
            {
                if (!(entrada.Contains("") || entrada.Contains(" ")))
                {
                    foreach (var item in entrada) { cola.encolar(item); }
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
            Recorredor rec = new Recorredor(arbol.getHijos());
            rec.comenzar();
            while (!rec.fin())
            {
                if (((ArbolGeneral)rec.elemento()).getDatoRaiz().getNombre() == inCola)
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
