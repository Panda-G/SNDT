using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT
{
    public abstract class Lista
    {
        public abstract ArbolGeneral obtenerElemento(int posicion);
        public abstract void agregarElemento(ArbolGeneral elemento, int posicion);
        public abstract void eliminar(int posicion);
        public abstract bool esVacia();
        public abstract bool incluye(ArbolGeneral elemento);
        public abstract Recorredor getRecorredor();
        public abstract int tamanioLista();
    }
}
