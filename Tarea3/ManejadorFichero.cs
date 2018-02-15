using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea3
{
    class ManejadorFichero
    {
        public void LeerArchivo(ref DataGridView _dgv)
        {
            //DataTable dt = new DataTable();
            StreamReader reader;
            
            try
            {
                string _path = @"C:\Datos\Registros.txt";
                reader = new StreamReader(_path);
                while (!reader.EndOfStream)
                {
                    string[] linea = reader.ReadLine().Split(',');
                    _dgv.Rows.Add(linea[0],linea[1],linea[2]);
                }
                reader.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Erro al intentar leer el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void GuardarArchivo()
        {
            //try
            //{
            //    StreamWriter writer;
            //    if (_path == "")
            //    {
            //        NuevoArchivo(false);
            //    }
            //    writer = new StreamWriter(_path);
            //    writer.Write(txtContenido.Text);
            //    writer.Close();
            //}
            //catch (IOException ex)
            //{
            //    MessageBox.Show("Erro al intentar escribir el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }

        private void NuevoArchivo(bool vaciar)
        {
            //saveFile.Title = "Nuevo Archivo";
            //saveFile.Filter = "Archivos de Texto (*.txt)|*.txt";
            //saveFile.ShowDialog();
            //_path = saveFile.FileName;
            //if (vaciar == true) { txtContenido.Clear(); }
        }
    }
}
