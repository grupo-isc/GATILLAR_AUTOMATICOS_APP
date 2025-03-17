using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class contacto
    {
        public int id_contacto { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public int id_tipo_dato { get; set; }
        public DateTime fecha_reg { get; set; }
        public DateTime fecha_mod { get; set; }
        public int estado { get; set; }
        public string nombre_dato { get; set; }
        public int linea { get; set; }
        public string datos { get; set; }
        public int id_lista_de_contactos { get; set; }
        public string mandatorio { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int id_envio { get; set; }
    }
}
