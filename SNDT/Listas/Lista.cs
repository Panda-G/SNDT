using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT
{
    public abstract class Lista
    {
        protected int tamanio { get; set; }

        public abstract ArbolGeneral obtenerElemento(int pos);
        public abstract void agregarElemento(object elem, int pos);
        public abstract void eliminar(int pos);
        public abstract bool esVacia();
        public abstract bool incluye(object elem);
        public abstract Recorredor getRecorredor();

        public int tamanioLista()
        {
            return this.tamanio;
        }
    }
}
