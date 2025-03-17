using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class formato
    {
        public int id_formato { get; set; }
        public int id_tipo { get; set; }
        public string nom_formato { get; set; }
        public Nullable<System.DateTime> fecha_reg { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public byte estado { get; set; }
    }
}
