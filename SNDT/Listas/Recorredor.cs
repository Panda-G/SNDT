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

<<<<<<< HEAD:SNDT/Listas/Recorredor.cs
        public Recorredor(ArrayList enLista)
        {
            this.lista = new ListaConArreglo();
            this.lista.Datos = enLista;
        }
=======
        public Recorredor(ArrayList inLista)
        {
            lista = new ListaConArreglo();
            this.lista.Datos = inLista;
        }

>>>>>>> version-3:ClasesUtilizadas/Recorredor.cs
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
<<<<<<< HEAD:SNDT/Listas/Recorredor.cs
            if (!(actual <= lista.obtenerTamanio() - 1))
=======
            if (actual == lista.getTamanio())
>>>>>>> version-3:ClasesUtilizadas/Recorredor.cs
            {
                return true;
            }
            return false;
        }
    }
}
