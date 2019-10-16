using System;

namespace SNDT
{
    public class ArbolGeneral
    {
        //Atributos de la clase [ArbolGeneral]
        private NodoGeneral raiz;
        private int nivelNodo;
        //Propiedades
        public NodoGeneral Raiz { get => this.raiz; }
        public int NivelNodo { get => this.nivelNodo; set => this.nivelNodo = value; }

        #region Constructores
        public ArbolGeneral(string categoria)
        {
            this.raiz = new NodoGeneral(new TipoDominio(categoria));
        }
        public ArbolGeneral(string categoria, string[] datoEspecie)
        {
            Especie categoriaEspecie = new Especie(categoria, datoEspecie[0], datoEspecie[1]);
            this.raiz = new NodoGeneral(categoriaEspecie) { ListaHijos = null };
        }
        #endregion

        #region Metodos

        public void agregarHijo(ArbolGeneral hijo)
        {
            if (Raiz.ListaHijos.nuevoIncluye(hijo.Raiz.Dato.Nombre) == -1)
                this.Raiz.ListaHijos.agregarElemento(hijo, Raiz.ListaHijos.tamanioLista);
        }

        public void eliminarHijo(ArbolGeneral hijo)
        {
            if (Raiz.ListaHijos.nuevoIncluye(hijo.Raiz.Dato.Nombre) == -1)
                this.Raiz.ListaHijos.eliminar(hijo);
        }

        public bool esHoja()
        {
            return this.Raiz != null && this.Raiz.ListaHijos.tamanioLista == 0;
        }

        //Imprime en pantalla el recorrido Pre-Orden del arbol del que es llamado
        public void recorridoPreOrden()
        {
            Console.WriteLine(Raiz.Dato.Nombre);
            if (esHoja())
            {
                if (this.NivelNodo != 0)
                {
                    Especie esp = (Especie)Raiz.Dato;
                    Console.Write(" \tMetabolismo: " + esp.Dato.Metabolismo +
                                 "\n\tReproduccion: " + esp.Dato.Reproduccion + "\n");
                }
            }
            else
            {
                Recorredor recorrer = Raiz.ListaHijos.Recorredor;
                recorrer.comenzar();
                while (recorrer.esFin() == false)
                {
                    ((ArbolGeneral)recorrer.obtenerElemento()).recorridoPreOrden();
                    recorrer.proximo();
                }
            }
        }
        #endregion

    }
}
