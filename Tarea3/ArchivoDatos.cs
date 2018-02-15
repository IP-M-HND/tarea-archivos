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
        public ArchivoDatos(int _id,char[] _nombre,char[] _departamento)
        {
            this.id = _id;
            this.Setnombre(_nombre);
            this.Setdepartamento(_departamento);
        }
        public int id { get { return id; }
                        set {
                if (id > 9999)
                {
                    MessageBox.Show("Solo se Permiten Id de 4 caracteres: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    this.id = id;
            } }

        private char[] nombre1;

        public char[] Getnombre()
        {
            return nombre1;
        }

        public void Setnombre(char[] value)
        {
            nombre1 = value;
        }

        private char[] departamento1;

        public char[] Getdepartamento()
        {
            return departamento1;
        }

        public void Setdepartamento(char[] value)
        {
            departamento1 = value;
        }
    }
}
