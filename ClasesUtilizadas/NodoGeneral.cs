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
            this.Dato = enNombre;
            this.listaHijos = new ListaConArreglo();
        }

        public ListaConArreglo ListaHijos
        {
            get => listaHijos;
            set => listaHijos = value;
        }
        public TipoDominioAbstracto Dato
        {
            get => dato;
            set => dato = value;
        }
        //public void setHijos(ListaConArreglo hijos)
        //{
        //    this.listaHijos = hijos;
        //}
        //public ListaConArreglo getHijos()
        //{
        //    return this.listaHijos;
        //}
        //public TipoDominioAbstracto getDato()
        //{
        //    return this.Dato;
        //}
        //public void setDato(TipoDominioAbstracto dato)
        //{
        //    this.Dato = dato;
        //}
    }
}
