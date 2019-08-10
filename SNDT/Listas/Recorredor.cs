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
        private ListaConArreglo lista;
        private int actual;

        public Recorredor(ArrayList enLista)
        {
            this.lista = new ListaConArreglo();
            this.lista.Datos = enLista;
        }
        public void comenzar()
        {
            this.actual = 0;
        }
        public object elemento()
        {
            return this.lista.obtenerElemento(this.actual);
        }
        public void proximo()
        {
            this.actual += 1;
        }
        public bool fin()
        {
            if (!(actual <= lista.obtenerTamanio() - 1))
            {
                return true;
            }
            return false;
        }
    }
}
