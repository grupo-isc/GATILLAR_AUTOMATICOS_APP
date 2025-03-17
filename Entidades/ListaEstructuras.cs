using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ListaEstructuras
    {
        public ListaEstructuras()
        {
            this.estructuras = new List<estructura_archivo>();
        }

        public List<estructura_archivo> estructuras { get; set; }
    }
}
