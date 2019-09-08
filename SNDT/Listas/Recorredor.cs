using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT
{
    public class Recorredor
    {
        private readonly ListaConArreglo lista;
        private int actual;

        public Recorredor(ArrayList enLista)
        {
            this.lista = new ListaConArreglo { Hijos = enLista };
        }
        public void comenzar()
        {
            this.actual = 0;
        }
        public ArbolGeneral obtenerElemento()
        {
            return this.lista.obtenerElemento(this.actual);
        }
        public void proximo()
        {
            this.actual += 1;
        }
        public bool esFin()
        {
            if (!(actual <= lista.tamanioLista() - 1))
            {
                return true;
            }
            return false;
            //if (this.lista.esVacia())
            //    return true;
            //return false;
        }
    }
}
