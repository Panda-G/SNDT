using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SNDT
{
    public class ArbolGeneral
    {
        private NodoGeneral raiz;
        private int nivelNodo = 0;
        public NodoGeneral Raiz { get => raiz; set => raiz = value; }
        public int NivelNodo { get => nivelNodo; set => nivelNodo = value; }

        #region Constructores
        public ArbolGeneral(string categoria)
        {
            this.Raiz = new NodoGeneral(new TipoDominio(categoria));
        }
        public ArbolGeneral (string categoria, string[] datoEspecie)
        {
            Especie categoriaEspecie = new Especie(categoria, datoEspecie[0], datoEspecie[1]);
            this.Raiz = new NodoGeneral(categoriaEspecie);
        }
        #endregion

        #region Metodos
        public TipoDominioAbstracto getDatoRaiz()
        {
            return this.Raiz.Dato;
        }
        public ListaConArreglo getListaHijos()
        {
            return this.Raiz.ListaHijos;
        }
        public void agregarHijo(ArbolGeneral hijo)
        {
            this.Raiz.ListaHijos.agregar(hijo, Raiz.ListaHijos.obtenerTamanio());
        }

        public void eliminarHijo(ArbolGeneral hijo)
        {
            this.Raiz.ListaHijos.eliminar(hijo);
        }
        public bool esVacio()
        {
            return this.Raiz == null;
        }
        public bool esHoja()
        {
            return this.Raiz != null && this.getListaHijos().obtenerTamanio() == 0;
        }
        public void recorridoPreorden()
        {
            Console.WriteLine(getDatoRaiz().Nombre);
            if (esHoja())
            {
                if (this.NivelNodo != 0)
                {
                    Especie esp = (Especie)getDatoRaiz();
                    Console.Write(" \tMetabolismo: " + esp.Dato.Metabolismo + 
                                 "\n\tReproduccion: " + esp.Dato.Reproduccion + "\n");
                }
            }
            else
            {
                Recorredor recorrer = this.getListaHijos().getRecorredor();
                recorrer.comenzar();
                while (recorrer.fin() == false)
                {
                    ((ArbolGeneral)recorrer.elemento()).recorridoPreorden();
                    recorrer.proximo();
                }
            }
        }
        #endregion

    }
}
