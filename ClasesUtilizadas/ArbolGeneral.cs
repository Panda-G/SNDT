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

        #region Constructores
        public ArbolGeneral(){ }

        public ArbolGeneral(TipoDominio dato)
        {
            this.raiz = new NodoGeneral(dato);
        }
        public ArbolGeneral(NodoGeneral nodo)
        {
            this.raiz = nodo;
        }
        #endregion

        #region Metodos
        public NodoGeneral getRaiz()
        {
            return raiz;
        }
        public void setRaiz(NodoGeneral _raiz)
        {
            this.raiz = _raiz;
        }
        public TipoDominioAbstracto getDatoRaiz()
        {
            return this.raiz.getDato();
        }
        public ListaConArreglo getHijos()
        {
            ListaConArreglo temp = new ListaConArreglo();
            temp = this.raiz.getHijos();
            return temp;
        }
        public void agregarHijo(ArbolGeneral hijo)
        {
            this.raiz.getHijos().agregar(hijo);

        }
        public void eliminarHijo(ArbolGeneral hijo)
        {
            this.raiz.getHijos().eliminar(hijo);
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
                if (this.nivel != 0)
                {
                    Especie esp = (Especie)getDatoRaiz();
                    Console.Write(" \tMetabolismo: " + esp.getDatoMEspecie() + "\n\tSexualidad: " + esp.getDatosREspecie() + "\n");
                }
            }
            else
            {
                Recorredor rec = new Recorredor(getHijos());
                rec.comenzar();
                while (rec.fin() == false)
                {
                    ((ArbolGeneral)rec.elemento()).recorridoPreOrden();
                    rec.proximo();
                }
            }
        }
        public int getnivel()
        {
            return this.nivel;
        }
        public void setnivel(int n)
        {
            this.nivel = n;
        }
        #endregion

    }
}
