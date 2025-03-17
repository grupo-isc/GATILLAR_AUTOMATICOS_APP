using System;

namespace Entidades
{
    public class envio_gatillado
    {
        public int id_envio_gatillado { get; set; }
        public int id_envio { get; set; }
        public int id_estado_envio { get; set; }
        public int id_persona_juridica { get; set; }
        public byte? programado { get; set; }
        public DateTime? fecha_programado { get; set; }
        public byte? es_automatico { get; set; }
        public byte? validado_automatico { get; set; }
        public byte? gatillado_test { get; set; }
        public byte? gatillado { get; set; }
        public DateTime fecha_reg { get; set; }
        public DateTime? fecha_mod { get; set; }
        public byte estado { get; set; }
    }
}
