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

        public abstract object obtenerElemento(int pos);
        public abstract void agregar(object elem, int pos);
        public abstract void eliminar(int pos);
        public abstract bool esVacia();
        public abstract bool incluye(object elem);

<<<<<<< HEAD:SNDT/Listas/Lista.cs
        public abstract Recorredor getRecorredor();
=======
        public abstract Recorredor Recorredor();
>>>>>>> version-3:ClasesUtilizadas/Lista.cs

        public int obtenerTamanio()
        {
            return tamanio;
        }
    }
}
