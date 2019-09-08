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
        //private int punteroInicial;

        //lista de hijos
        private ArrayList hijos;
        public ArrayList Hijos { get => hijos; set => hijos = value; }


        public ListaConArreglo()
        {
            //this.punteroInicial = 0;
            Hijos = new ArrayList();
        }
        public override ArbolGeneral obtenerElemento(int pos)
        {
            return (ArbolGeneral)Hijos[pos];
        }
        public override void agregarElemento(object elem, int pos)
        {
            if (pos == Hijos.Count)
            {
                Hijos.Add(elem);
                tamanio += 1;
            }
        }
        public override void eliminar(int pos)
        {
            Hijos.RemoveAt(pos);
            tamanio -= 1;
        }
        public void eliminar(object elem)
        {
            this.Hijos.Remove(elem);
            this.tamanio -= 1;
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
        public override Recorredor getRecorredor()
        {
            return new Recorredor(Hijos);
        }
    }
}
