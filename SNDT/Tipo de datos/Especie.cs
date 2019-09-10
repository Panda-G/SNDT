using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT
{
    public class Especie : TipoDominioAbstracto
    {
        private readonly DatosEspecie dato;
        public DatosEspecie Dato { get => dato; }
        public Especie(string nombreEspecie, string tipoMetabolismo, string tipoReproduccion)
        {
            Nombre = nombreEspecie;
            dato = new DatosEspecie(tipoMetabolismo, tipoReproduccion);
        }
    } 

    public class DatosEspecie
    {
        private readonly string metabolismo;
        private readonly string reproduccion;

        public string Metabolismo { get => metabolismo; }
        public string Reproduccion { get => reproduccion; }
        public DatosEspecie(string metabolismo, string reproduccion)
        {
            this.metabolismo = metabolismo;
            this.reproduccion = reproduccion;
        }
    }
}
