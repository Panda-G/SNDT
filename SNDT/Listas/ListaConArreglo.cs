using System;
using System.Collections;

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
                Hijos.Add(elemento);
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
            try
            {
                //esta vacia la lista? no. entonces entra foreach
                foreach (ArbolGeneral arbolGeneral in Hijos)
                {
                    if (arbolGeneral.Raiz.Dato.Nombre == elemento)
                        return Hijos.IndexOf(arbolGeneral);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("{0} Second exception caught.", e);
            }
            return -1;
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
        public override int tamanioLista => Hijos.Count;
        public override Recorredor Recorredor => new Recorredor(Hijos);
    }
}
