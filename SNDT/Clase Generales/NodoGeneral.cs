namespace SNDT
{
    public class NodoGeneral
    {
        //Atributos
        private TipoDominioAbstracto dato;
        private ListaConArreglo listaHijos;
        //Propiedades
        public TipoDominioAbstracto Dato { get => this.dato; }
        public ListaConArreglo ListaHijos { get => this.listaHijos; set => this.listaHijos = value; }
        //Constructor
        public NodoGeneral(TipoDominioAbstracto nombreDato)
        {
            this.dato = nombreDato;
            this.listaHijos = new ListaConArreglo();
        }
    }
}
