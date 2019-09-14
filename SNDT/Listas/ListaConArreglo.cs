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
        public ArrayList Hijos { get => hijos; }

        public ListaConArreglo()
        {
            this.hijos = new ArrayList();
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
        public override void eliminar(ArbolGeneral elemento)
        {
            this.Hijos.Remove(elemento);
        }
        public override bool esVacia()
        {
            if ((Hijos.Count) == 0)
                return true;
            return false;
        }
        public int nuevoIncluye(string elemento)
        {
            //Retorna posicion del elemento en la lista, en caso contrario retorna -1
            return Hijos.IndexOf(elemento);
        }
        public override bool incluye(string elemento)
        {
            //obtener pos del elemento
            foreach (ArbolGeneral hijo in Hijos)
            {
                if (String.Equals(hijo.Raiz.Dato.Nombre, elemento))
                    return true;
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
