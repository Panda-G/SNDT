using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT.ClasesUtilizadas
{
    public class Recorredor
    {
        private ListaConArreglo lista;
        private int actual;

        public Recorredor() { }
        public Recorredor(ListaConArreglo lista)
        {
            this.lista = lista;
        }

        public void comenzar()
        {
            this.actual = 0;
        }

        public object elemento()
        {
            return this.lista.elemento(this.actual);
        }

        public void proximo()
        {
            this.actual += 1;
            //this.lista.elemento(this.actual);
        }

        public bool fin()
        {
            if (!(actual <= lista.getTamanio() - 1))
            {
                return true;
            }
            return false;
        }
    }
}
