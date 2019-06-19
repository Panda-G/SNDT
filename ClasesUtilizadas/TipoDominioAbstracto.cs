using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT.ClasesUtilizadas
{
    public abstract class TipoDominioAbstracto
    {
        protected string nombre;

        public abstract void setNombre(string n);
        public abstract string getNombre();
    }
}
