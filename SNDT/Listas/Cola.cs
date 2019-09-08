using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT
{
    public class Cola<T>
    {
        private readonly List<T> datos = new List<T>();
        private int cantidadElementos;
        private T anterior;

        public int CantidadElementos { get => cantidadElementos; set => cantidadElementos = value; }

        public void encolarElemento(T elem)
        {
            this.datos.Add(elem);
            ++this.CantidadElementos;
        }

        public T desencolar()
        {
            T temp = anterior = this.datos[0];
            this.datos.RemoveAt(0);
            --this.CantidadElementos;
            return temp;
        }

        public T obtenerAnterior()
        {
            return anterior;
        }

        public T tope()
        {
            return this.datos[0];
        }

        public bool esVacia()
        {
            return this.datos.Count == 0 && this.CantidadElementos == 0;
        }

        public int obtenerCantidad()
        {
            return this.CantidadElementos;
        }
    }
}
