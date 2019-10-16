namespace SNDT
{
    public abstract class Lista
    {
        public abstract ArbolGeneral obtenerElemento(int posicion);
        public abstract void agregarElemento(ArbolGeneral elemento, int posicion);
        public abstract void eliminar(ArbolGeneral elemento);
        public abstract bool esVacia();
        public abstract bool incluye(string elemento);
        public abstract Recorredor Recorredor { get; }
        public abstract int tamanioLista { get; }
    }
}
