using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT
{
    public class Especie : TipoDominioAbstracto
    {
        private DatosEspecie dato;

        public DatosEspecie Dato { get => dato; set => dato = value; }

        public Especie(string nombreEspecie, string datoMeta, string datoRepr)
        {
            this.Nombre = nombreEspecie;
            Dato = new DatosEspecie(datoMeta, datoRepr);
        }

    }
    public class DatosEspecie
    {
        private string metabolismo;
        private string reproduccion;

        public string Metabolismo { get => metabolismo; }
        public string Reproduccion { get => reproduccion; }
        public DatosEspecie(string metabolismo, string reproduccion)
        {
            this.metabolismo = metabolismo;
            this.reproduccion = reproduccion;
        }
    }

}
