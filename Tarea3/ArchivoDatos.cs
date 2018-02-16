using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea3
{
    class ArchivoDatos
    {
        public ArchivoDatos(string _id,string _nombre,string _departamento)
        {
            this.id = _id;
            this.nombre = _nombre;
            this.departamento = _departamento;
        }
        public string id { get; set; }
        public string nombre { get; set; }
        public string departamento { get; set; }
    }
}
