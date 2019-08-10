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
        private int nivel = 0;
        public NodoGeneral Raiz { get => raiz; set => raiz = value; }

        #region Constructores
        public ArbolGeneral(string enDato)
        {
            this.Raiz = new NodoGeneral(new TipoDominio(enDato));
        }
        public ArbolGeneral (string enEspecie, string[] datoEspecie)
        {
            Especie miEspecie = new Especie(enEspecie, datoEspecie[0], datoEspecie[1]);
            this.Raiz = new NodoGeneral(miEspecie);
        }
        #endregion

        #region Metodos
        public TipoDominioAbstracto getDatoRaiz()
        {
            return this.Raiz.Dato;
        }
        public ListaConArreglo getHijos()
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
            return this.Raiz != null && this.getHijos().obtenerTamanio() == 0;
        }
        public void recorridoPreOrden()
        {
            Console.WriteLine(getDatoRaiz().Nombre);
            if (esHoja())
            {
                if (this.nivel != 0)
                {
                    Especie esp = (Especie)getDatoRaiz();
                    Console.Write(" \tMetabolismo: " + esp.Dato.Metabolismo + "\n\tReproduccion: " + esp.Dato.Reproduccion + "\n");
                }
            }
            else
            {
                Recorredor rec = this.getHijos().getRecorredor();
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
