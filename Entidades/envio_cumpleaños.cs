using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class envio_cumpleaños
    {
        public int id_envio_cumpleaños { get; set; }
        public int id_lista_contactos { get; set; }
        public int id_envio { get; set; }
        public string email { get; set; }
        public DateTime fecha_envio { get; set; }
        public int estado { get; set; }
    }
}
