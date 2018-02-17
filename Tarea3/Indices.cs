using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3
{
    class Indices
    {
        public Indices(int _indice,string _departamento,int _id_archivo)
        {
            this.id_archvio = _id_archivo;
            this.departamento = _departamento;
            this.indice = _indice;
        }
        public int id_archvio { get; set; }
        public string departamento { get; set; }
        public int indice { get; set; }
    }
}
