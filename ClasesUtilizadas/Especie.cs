using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT.ClasesUtilizadas
{
    public class Especie : TipoDominioAbstracto
    {
        private DatosEspecie dato;
        public Especie(string nombre, string datoMeta, string datoRepr)
        {
            this.nombre = nombre;
            dato = new DatosEspecie(datoMeta, datoRepr);
        }
        public string getDatoMEspecie()
        {
            return this.dato.getMetabolismo();
        }
        public string getDatosREspecie()
        {
            return this.dato.getReproduccion();
        }
        public override void setNombre(string n)
        {
            this.nombre = n;
        }
        public override string getNombre()
        {
            return this.nombre;
        }
    }
    public class DatosEspecie
    {
        private string Metabolismo;
        private string Reproduccion;
        public DatosEspecie(string datoMeta, string datoRepr)
        {
            Metabolismo = datoMeta;
            Reproduccion = datoRepr;
        }
        public string getMetabolismo()
        {
            return this.Metabolismo;
        }
        public string getReproduccion()
        {
            return this.Reproduccion;
        }
    }
}
