using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT.ClasesUtilizadas
{
    public class NodoGeneral
    {
        private TipoDominioAbstracto dato;
        private ListaConArreglo listaHijos;


        public NodoGeneral() { }
        
        public NodoGeneral(TipoDominioAbstracto enNombre)
        {
            this.dato = enNombre;
            this.listaHijos = new ListaConArreglo();
        }


        public TipoDominioAbstracto getDato()
        {
            return this.dato;
        }
        public void setHijos(ListaConArreglo hijos)
        {
            this.listaHijos = hijos;
        }
        public ListaConArreglo getHijos()
        {
            return this.listaHijos;
        }
        public void setDato(TipoDominioAbstracto dato)
        {
            this.dato = dato;
        }

    }
}
