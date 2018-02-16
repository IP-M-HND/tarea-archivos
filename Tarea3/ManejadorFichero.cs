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

        static string _path1 = @"C:\Datos\Indices.txt";
        static string _path2 = @"C:\Datos\Registros.txt";

        public List<Indices> LeerArchivoIndices()
        {
            List<Indices> _data = new List<Indices>();
            //DataTable dt = new DataTable();
            StreamReader reader;
            
            try
            {
                
                reader = new StreamReader(_path1);
                
                while (!reader.EndOfStream)
                {

                    string[] linea = reader.ReadLine().Split(',');

                    if (linea[0]!="")
                    {
                        _data.Add(new Indices(Convert.ToInt32(linea[0]), linea[1], Convert.ToInt32(linea[2])));
                    }
                    
                    //ArchivoDatos datos = new ArchivoDatos();
                    //datos.id = linea.Substring(0,4).Replace('0', ' ');


                    //datos.nombre = linea.Substring(4,25).Replace('0', ' ');
              
                    //datos.departamento = linea.Substring(29, 10).Replace('0', ' ');
                    //_dgv.Rows.Add(datos.id,datos.nombre,datos.departamento);
                }
                reader.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Erro al intentar leer el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            return _data;
        }

        public List<ArchivoDatos> LeerArchivoDatos(List<Indices> _indices)
        {
            List<ArchivoDatos> _data = new List<ArchivoDatos>();
            //DataTable dt = new DataTable();
           

            try
            {

                
                foreach (Indices _indice in _indices)
                {
                    _data.Add(encontrar_registro(_indice.indice));
                }
                
                
            }
            catch (IOException ex)
            {
                MessageBox.Show("Erro al intentar leer el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return _data;
        }

        private ArchivoDatos encontrar_registro(int fila)
        {
            ArchivoDatos dat = new ArchivoDatos("","","");
            StreamReader reader;
            reader = new StreamReader(_path2);
            int i = 0;
            while (!reader.EndOfStream)
            {

                string linea = reader.ReadLine();
                if (linea != "")
                {
                    ArchivoDatos tp = new ArchivoDatos(linea.Substring(0, 3).Replace('-', ' '),
                                                        linea.Substring(4, 25).Replace('-', ' '),
                                                        linea.Substring(29, 10).Replace('-', ' '));
                    dat = new ArchivoDatos(tp.id, tp.nombre, tp.departamento);
                }
                if (++i==fila) break;
            }
            reader.Close();
            return dat;
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
