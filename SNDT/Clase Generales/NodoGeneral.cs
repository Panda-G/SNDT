using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT
{
    public class NodoGeneral
    {
        //Atributos
        private TipoDominioAbstracto dato;
        private ListaConArreglo listaHijos;
        //Propiedades
        public TipoDominioAbstracto Dato { get => dato; set => dato = value; }
        public ListaConArreglo ListaHijos { get => listaHijos; set => listaHijos = value; }
        //Constructor
        public NodoGeneral(TipoDominioAbstracto nombreDato)
        {
            this.Dato = nombreDato;
            this.ListaHijos = new ListaConArreglo();
        }
    }
}
