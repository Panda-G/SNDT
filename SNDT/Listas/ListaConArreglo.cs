using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT
{
    public class ListaConArreglo : Lista
    {
        //lista de hijos
        private ArrayList hijos;
        public ArrayList Hijos { get => hijos; set => hijos = value; }

        public ListaConArreglo()
        {
            Hijos = new ArrayList();
        }
        public override ArbolGeneral obtenerElemento(int posicion)
        {
            return (ArbolGeneral)Hijos[posicion];
        }
        public override void agregarElemento(ArbolGeneral elemento, int posicion)
        {
            if (posicion == Hijos.Count)
            {
                Hijos.Add(elemento);
            }
        }
        public override void eliminar(int posicion)
        {
            Hijos.RemoveAt(posicion);
        }
        public void eliminar(object elemento)
        {
            this.Hijos.Remove(elemento);
        }
        public override bool esVacia()
        {
            if ((Hijos.Count) == 0)
                return true;
            return false;
        }
        public override bool incluye(object elem)
        {
            foreach (var item in Hijos)
            {
                if (item.Equals(elem))
                {
                    return true;
                }
            }
            return false;
        }
        public override int tamanioLista()
        {
            return Hijos.Count;
        }
        public override Recorredor getRecorredor()
        {
            return new Recorredor(Hijos);
        }
    }
}
