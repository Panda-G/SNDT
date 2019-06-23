using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT.ClasesUtilizadas
{
    public class Cola<T>
    {
        private List<T> datos = new List<T>();
        private int numeroElementos;
        private T anterior;
        public void encolar(T elem)
        {
            this.datos.Add(elem);
            ++this.numeroElementos;
        }

        public T desencolar()
        {
            T temp = anterior = this.datos[0];
            this.datos.RemoveAt(0);
            --this.numeroElementos;
            return temp;
        }

        public T getAnterior()
        {
            return anterior;
        }

        public T tope()
        {
            return this.datos[0];
        }

        public bool esVacia()
        {
            return this.datos.Count == 0 && this.numeroElementos == 0;
        }

        public int getNumeroElementos()
        {
            return this.numeroElementos;
        }
    }
}
