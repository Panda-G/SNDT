using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT
{
    public class Cola<T>
    {
        private readonly List<T> datosCola = new List<T>();
        private int cantidadElementos;
        private T anterior;

        public int CantidadElementos { get => cantidadElementos; set => cantidadElementos = value; }
        
        /* Agrega el objecto de parametro a [datosCola], la lista. 
         * Incrementa en 1 [cantidadElementos]. */
        public void encolarElemento(T elem)
        {
            this.datosCola.Add(elem);
            CantidadElementos += 1;
        }

        /* Almacena objeto en indice 0 en [anterior], elimina el elemento 
         * de la [datosCola] y retorna [anterior]  
           Decrementa en 1 [cantidadElementos]. */
        public T desencolar()
        {
            T temp = anterior = this.datosCola[0];
            this.datosCola.RemoveAt(0);
            CantidadElementos -= 1;
            return temp;
        }

        //Retorna [anterior].
        public T obtenerAnterior()
        {
            return anterior;
        }

        //Retorna el primer elemento de [datosCola].
        public T tope()
        {
            return this.datosCola[0];
        }

        //Responde a "¿Esta vacia la cola?", retornando TRUE si es verdad.
        public bool esVacia()
        {
            return this.CantidadElementos == 0;
        }
    }
}
