using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNDT
{
    public class TipoDominio : TipoDominioAbstracto
    {
        public TipoDominio(string entradaNombre)
        {
            Nombre = entradaNombre;
        }
    }
}
