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

        public Recorredor(ArrayList inLista)
        {
            lista = new ListaConArreglo();
            this.lista.Datos = inLista;
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
        }

        public bool fin()
        {
            if (actual == lista.getTamanio())
            {
                return true;
            }
            return false;
        }
    }
}
