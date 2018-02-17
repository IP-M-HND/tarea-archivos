using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea3
{
    public partial class Form1 : Form
    {
        ManejadorFichero mFich = new ManejadorFichero();
        bool editar = false;

        List<Indices> indices = new List<Indices>();

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
            indices=mFich.LeerArchivoIndices();
            cargarGrid(mFich.LeerArchivoDatos(indices));
        }

        private void cargarGrid(List<ArchivoDatos> _datos)
        {
            foreach (ArchivoDatos rw in _datos)
            {
                dataGridView1.Rows.Add(rw.id,rw.nombre,rw.departamento);
            }
        }

        private void BsucarId(string _id)
        {
            var item = indices.Where(d=>d.id_archvio.ToString()==_id).FirstOrDefault();
            if (item!=null)
            {
                ArchivoDatos tp = mFich.encontrar_registro(item.indice);
                txtId.Text = tp.id;
                txtNombre.Text = tp.nombre;
                txtDepartamento.Text = tp.departamento;
            }
        }

        private void BuscarDepartamento(string _depto)
        {

        }
        //al dat doble click en un elemento de la grilla cambiamos el valor de editar a true para que 
        //ediar este activo ademas pasamos los valores de la fila seleccionada a los textbox
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtId.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                txtDepartamento.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
                editar = true;
                txtId.ReadOnly = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            ArchivoDatos datos = new ArchivoDatos(txtId.Text,
                                                        txtNombre.Text,
                                                        txtDepartamento.Text);
            if (editar)
            {
                var tp = indices.Where(d => d.id_archvio.ToString()==txtId.Text).FirstOrDefault();

                mFich.ActualizarArchivo(tp.indice,datos);
            }
            else
            {
                mFich.GuardarArchivo(datos);
            }

            Form1_Load(sender,e);
        }

        private void btn_BuscarID_Click(object sender, EventArgs e)
        {
            String tp = Microsoft.VisualBasic.Interaction.InputBox("Buscar...", "Favor ingresa el Id del Empliado: ");
            BsucarId(tp);
        }

        private void btn_Buscar_ButtonClick(object sender, EventArgs e)
        {
            btn_BuscarID_Click(sender,e);
        }

        private void btn_BuscarDepto_Click(object sender, EventArgs e)
        {
            String tp = Microsoft.VisualBasic.Interaction.InputBox("Buscar...", "Favor ingresa el departamento: ");
            BsucarId(tp);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Indices tp = indices.Where(d => d.id_archvio.ToString() == txtId.Text).FirstOrDefault();
            if (tp!=null)
            {
                indices.Remove(tp);
                mFich.EliminarReg(ref indices);
            }
            Form1_Load(sender,e);
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtDepartamento.Clear();
            txtNombre.Clear();
            txtId.Focus();
            editar = false;
        }
    }
}
