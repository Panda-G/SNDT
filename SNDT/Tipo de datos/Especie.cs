namespace SNDT
{
    public class Especie : TipoDominioAbstracto
    {

        private DatosEspecie dato;
        public DatosEspecie Dato { get => dato; }
        public Especie(string nombreEspecie, string tipoMetabolismo, string tipoReproduccion)
        {
            Nombre = nombreEspecie;
            this.dato = new DatosEspecie(tipoMetabolismo, tipoReproduccion);
        }

    }
    public class DatosEspecie
    {
        private readonly string metabolismo;
        private readonly string reproduccion;

        public string Metabolismo { get => this.metabolismo; }
        public string Reproduccion { get => this.reproduccion; }
        public DatosEspecie(string metabolismo, string reproduccion)
        {
            this.metabolismo = metabolismo;
            this.reproduccion = reproduccion;
        }

    }
}
