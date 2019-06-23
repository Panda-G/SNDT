using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT.ClasesUtilizadas
{
    public class TipoDominio:TipoDominioAbstracto
    {
        public TipoDominio() { }
        public TipoDominio(string n)
        {
            this.nombre = n;
        }
        //public string Nombre
        //{
        //    get => nombre;
        //    set => nombre = value;
        //}
        public override void setNombre(string n)
        {
            this.nombre = n;
        }

        public override string getNombre()
        {
            return this.nombre;
        }

    }
}
