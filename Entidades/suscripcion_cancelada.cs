using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class suscripcion_cancelada
    {
        public int id_suscripcion_cancelada { get; set; }
        public int id_persona_juridica { get; set; }
        public int id_area { get; set; }

        public string email { get; set; }
        public Nullable<System.DateTime> fecha_reg { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public int estado { get; set; }

        public string razon_social { get; set; }
        public string nombre_fantasia { get; set; }
        public string nombre_area { get; set; }

        public string fecha_reg_eng { get; set; }
        public string fecha_reg_esp { get; set; }
        public string fecha_mod_eng { get; set; }
        public string fecha_mod_esp { get; set; }
        public int id_tipo_bloqueo { get; set; }
        public string nombre_tipo_bloqueo { get; set; }
    }
}
