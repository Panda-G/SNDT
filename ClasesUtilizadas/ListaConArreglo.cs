using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT.ClasesUtilizadas
{
    public class ListaConArreglo : Lista
    {
        private int inicial;
        private ArrayList datos;

        public ListaConArreglo()
        {
            this.inicial = 0;
            this.datos = new ArrayList();
        }
        public override object elemento(int pos)
        {
            return this.datos[pos];
        }
        public void agregar(ArbolGeneral elem)
        {
            datos.Add(elem);
            tamanio += 1;
        }
        public void agregar(int elem)
        {
            datos.Add(elem);
            tamanio += 1;
        }
        public override void agregar(object elem, int pos)
        {
            this.datos[pos] = elem;
        }
        public override void eliminar(int pos)
        {
            datos.RemoveAt(pos);
            this.tamanio -= 1;
        }
        public void eliminar(object elem)
        {
            this.datos.Remove(elem);
            this.tamanio -= 1;
        }
        public override bool esVacia()
        {
            if ((datos.Count) == 0)
                return true;
            return false;
        }
        public override bool incluye(object elem)
        {
            foreach (var item in datos)
            {
                if (item == elem)
                    return true;
            }
            return false;
        }
    }
}
