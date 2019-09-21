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
        private readonly ArrayList lista;
        private int actual;

        public Recorredor(ArrayList enLista)
        {
            this.lista = new ArrayList(enLista);
        }
        public void comenzar() => this.actual = 0;
        public ArbolGeneral obtenerElemento() => (ArbolGeneral)lista[actual];
        public void proximo() => this.actual += 1;
        public bool esFin()
        {
            //Si actual es meno o igual a la ultima posicion de la lista
            if (!(actual <= lista.Count - 1))
            {
                return true;
            }
            return false;
        }
    }
}
