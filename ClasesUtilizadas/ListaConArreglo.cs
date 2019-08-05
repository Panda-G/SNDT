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

        public ArrayList Datos { get => datos; set => datos = value; }

        public ListaConArreglo()
        {
            this.inicial = 0;
            this.Datos = new ArrayList();
        }
        public override object elemento(int pos)
        {
            return this.Datos[pos];
        }
        public void agregar(ArbolGeneral elem)
        {
            Datos.Add(elem);
            tamanio += 1;
        }
        public void agregar(int elem)
        {
            Datos.Add(elem);
            tamanio += 1;
        } 
        public override void agregar(object elem, int pos)
        {
            this.Datos[pos] = elem;
            tamanio += 1;
        }
        public override void eliminar(int pos)
        {
            Datos.RemoveAt(pos);
            this.tamanio -= 1;
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
            foreach (object item in Datos)
            {
                if (item.Equals(elem))
                {
                    return true;
                }
            }
            return false;
        }
        public override Recorredor Recorredor()
        {
            return new Recorredor(Datos);
        }
    }
}
