using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class envio
    {
        public int id_envio { get; set; }
        public int id_plantilla { get; set; }
        public int id_casilla { get; set; }
        public string nom_casilla { get; set; }
        public int id_estado_envio { get; set; }
        public string nom_estado_envio { get; set; }
        public string nombre { get; set; }
        public string archivo { get; set; }
        public string asunto { get; set; }
        public string html_envio { get; set; }
        public string cadena_json { get; set; }
        public int id_archivo { get; set; }
        public Nullable<int> id_proceso { get; set; }
        public string nom_proceso { get; set; }
        public int id_area { get; set; }
        public string nom_area { get; set; }
        public Nullable<int> id_tipo_envio { get; set; }
        public string nom_tipo_envio { get; set; }
        public Nullable<int> id_campania { get; set; }
        public Nullable<System.DateTime> fecha_inicio { get; set; }
        public Nullable<System.DateTime> fecha_termino { get; set; }
        public Nullable<System.DateTime> fecha_reg { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public byte estado { get; set; }
        public int gatillado { get; set; }
        public int gatillado_test { get; set; }
        public Nullable<int> id_fuente { get; set; }
        public Nullable<int> id_usuario_crea { get; set; }
        public Nullable<int> id_usuario_modifica { get; set; }
        public int id_usuario_gatilla { get; set; }
        public DateTime mas_5 { get; set; }
        public DateTime fecha_ult_despacho { get; set; }
        public DateTime mas_60 { get; set; }
        public DateTime actual { get; set; }
        public int id_persona_juridica { get; set; }

        public int es_automatico { get; set; }
        public int validado_automatico { get; set; }

        public int programado { get; set; }
        public Nullable<DateTime> fecha_programdado { get; set; }
        public int id_workflow { get; set; }
        public int id_clasificacion_envio { get; set; }
        public int id_lista_de_contactos { get; set; }
        public int id_evento { get; set; }
        public int cumpleaños { get; set; }
        public TimeSpan hora_despacho { get; set; }
    }
}
