using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SNDT.ClasesUtilizadas
{
    public class ArbolGeneral
    {
        private NodoGeneral raiz;
        private int nivel = 0;

        public int Nivel { get => nivel; set => nivel = value; }

        #region Constructores
        public ArbolGeneral(){ }

        public ArbolGeneral(string inNombre)
        {
            this.raiz = new NodoGeneral(new TipoDominio(inNombre));
        }
        public ArbolGeneral(NodoGeneral nodo)
        {
            this.raiz = nodo;
        }
        #endregion

        #region Metodos
        public TipoDominioAbstracto getDatoRaiz()
        {
            return this.raiz.Dato;
        }
        public ListaConArreglo getHijos()
        {
            return this.raiz.ListaHijos;
        }
        public void agregarHijo(ArbolGeneral hijo)
        {
            this.raiz.ListaHijos.agregar(hijo);
        }
        public void eliminarHijo(ArbolGeneral hijo)
        {
            this.raiz.ListaHijos.eliminar(hijo);
        }
        public bool esVacio()
        {
            return this.raiz == null;
        }
        public bool esHoja()
        {
            return this.raiz != null && this.getHijos().getTamanio() == 0;
        }
        public void recorridoPreOrden()
        {
            Console.WriteLine(this.getDatoRaiz().getNombre());
            if (esHoja())
            {
                if (this.Nivel != 0)
                {
                    Especie esp = (Especie)getDatoRaiz();
                    Console.Write(" \tMetabolismo: " + esp.getDatoMEspecie() + "\n\tSexualidad: " + esp.getDatosREspecie() + "\n");
                }
            }
            else
            {
                Recorredor rec = getHijos().Recorredor();
                rec.comenzar();
                while (rec.fin() == false)
                {
                    ((ArbolGeneral)rec.elemento()).recorridoPreOrden();
                    rec.proximo();
                }
            }
        }
        #endregion

    }
}
