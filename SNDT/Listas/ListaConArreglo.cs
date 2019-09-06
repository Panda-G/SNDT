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
<<<<<<< HEAD:SNDT/Listas/ListaConArreglo.cs
            inicial = 0;
            Datos = new ArrayList();
=======
            this.inicial = 0;
            this.Datos = new ArrayList();
        }
        public override object elemento(int pos)
        {
            return this.Datos[pos];
>>>>>>> version-3:ClasesUtilizadas/ListaConArreglo.cs
        }
        public override object obtenerElemento(int pos)
        {
<<<<<<< HEAD:SNDT/Listas/ListaConArreglo.cs
            return Datos[pos];
        }
        
        public override void agregar(object elem, int pos)
        {
            if (pos == Datos.Count)
            {
                Datos.Add(elem);
                tamanio += 1;
            }
=======
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
>>>>>>> version-3:ClasesUtilizadas/ListaConArreglo.cs
        }

        public override void eliminar(int pos)
        {
            Datos.RemoveAt(pos);
<<<<<<< HEAD:SNDT/Listas/ListaConArreglo.cs
            tamanio -= 1;
=======
            this.tamanio -= 1;
>>>>>>> version-3:ClasesUtilizadas/ListaConArreglo.cs
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
<<<<<<< HEAD:SNDT/Listas/ListaConArreglo.cs
            foreach (var item in Datos)
=======
            foreach (object item in Datos)
>>>>>>> version-3:ClasesUtilizadas/ListaConArreglo.cs
            {
                if (item.Equals(elem))
                {
                    return true;
                }
            }
            return false;
        }
<<<<<<< HEAD:SNDT/Listas/ListaConArreglo.cs
        public override Recorredor getRecorredor()
=======
        public override Recorredor Recorredor()
>>>>>>> version-3:ClasesUtilizadas/ListaConArreglo.cs
        {
            return new Recorredor(Datos);
        }
    }
}
