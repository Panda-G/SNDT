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

        public NodoGeneral(TipoDominioAbstracto enNombre)
        {
            this.dato = enNombre;
            this.listaHijos = new ListaConArreglo();
        }
        public NodoGeneral(Especie enNombre)
        {
            this.dato = enNombre;
        }

        public TipoDominioAbstracto Dato
        {
            get { return dato; }
        }
        public ListaConArreglo ListaHijos
        {
            get { return listaHijos; }
        }
    }
}
