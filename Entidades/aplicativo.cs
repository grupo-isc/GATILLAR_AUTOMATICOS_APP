using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class aplicativo
    {
        public int id_aplicativo { get; set; }
        public double cant_sesiones { get; set; }
        public double proporcional { get; set; }
        public int cont_proporcional { get; set; }

        public Nullable<System.DateTime> fecha_reg { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public int estado { get; set; }
        public string nombre_aplicativo { get; set; }
        public string descripcion_aplicativo { get; set; }
        public int inmediato { get; set; }
    }
}
