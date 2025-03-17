using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class estructura_archivo
    {
        public estructura_archivo()
        {
            this.formatos = new List<formato>();

        }

        public int id_estructura_archivo { get; set; }
        public int id_archivo { get; set; }
        public string nombre_columna { get; set; }
        public string err_nombre_columna { get; set; }
        public int numero_columna { get; set; }
        public string err_numero_columna { get; set; }
        public int tipo_dato { get; set; }
        public int guardar { get; set; }
        public int af { get; set; }
        public int chk_af { get; set; }
        public int llave { get; set; }
        public int chk_llave { get; set; }
        public string formato { get; set; }
        public string err_formato { get; set; }
        public int posicion { get; set; }
        public string err_posicion { get; set; }
        public int id_formato { get; set; }
        public int mandatorio { get; set; }
        public int fecha_nacimiento { get; set; }
        public virtual List<formato> formatos { get; set; }
        public Nullable<System.DateTime> fecha_reg { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public byte estado { get; set; }
    }
}
