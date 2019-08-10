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
        private int inicial;
        private ArrayList datos;

        public ArrayList Datos { get => datos; set => datos = value; }

        public ListaConArreglo()
        {
            inicial = 0;
            Datos = new ArrayList();
        }
        public override object elemento(int pos)
        {
            return Datos[pos];
        }
        
        public override void agregar(object elem, int pos)
        {
            if (pos == Datos.Count)
            {
                Datos.Add(elem);
                tamanio += 1;
            }
        }

        public override void eliminar(int pos)
        {
            Datos.RemoveAt(pos);
            tamanio -= 1;
        }
        public void eliminar(object elem)
        {
            this.Datos.Remove(elem);
            this.tamanio -= 1;
        }
        public override bool esVacia()
        {
            if ((Datos.Count) == 0)
                return true;
            return false;
        }
        public override bool incluye(object elem)
        {
            foreach (var item in Datos)
            {
                if (item == elem)
                    return true;
            }
            return false;
        }
        public override Recorredor getRecorredor()
        {
            return new Recorredor(Datos);
        }
    }
}
