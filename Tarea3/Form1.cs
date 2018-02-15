using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea3
{
    public partial class Form1 : Form
    {
        ManejadorFichero mFich = new ManejadorFichero();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt = mFich.LeerArchivo();
            //foreach (DataRow item in dt.Rows)
            //{
            //    dataGridView1.Rows.Add(item[0],item[1],item[2]);
            //}
            mFich.LeerArchivo(ref dataGridView1);
        }
    }
}
