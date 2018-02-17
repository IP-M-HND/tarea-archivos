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



        public ArchivoDatos encontrar_registro(int fila)
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
                    ArchivoDatos tp = new ArchivoDatos(linea.Substring(0, 4).Replace('-', ' ').Trim(),
                                                        linea.Substring(4, 25).Replace('-', ' ').Trim(),
                                                        linea.Substring(29, 10).Replace('-', ' ').Trim());
                    dat = new ArchivoDatos(tp.id, tp.nombre, tp.departamento);
                }
                if (++i==fila) break;
            }
            reader.Close();
            return dat;
        }

        private int encontrar_registro_fila(ArchivoDatos dat)
        {
            StreamReader reader;
            int nFila = 0;

           
            reader = new StreamReader(_path2);

            while (!reader.EndOfStream)
            {

                string linea = reader.ReadLine();
                ++nFila;
                if (linea != "")
                {
                    ArchivoDatos tp = new ArchivoDatos(linea.Substring(0, 4).Replace('-', ' '),
                                                        linea.Substring(4, 25).Replace('-', ' '),
                                                        linea.Substring(29, 10).Replace('-', ' '));
                    
                    if (dat==tp)
                    {
                        break;
                    }
                }
                
            }

            reader.Close();
            return nFila;
        }

        private string ValidarPrametro(string s, int c)
        {
            string res = "";
            if (s.Length > c)
            {
                res = s.Substring(0, c);
            }
            else
            {
                res = s;
                for (int i = 0; i < c; i++)
                {
                    res += "-";
                    if (res.Length == c) { break; }
                }
            }
            return res;
        }

        public void GuardarArchivo(ArchivoDatos ad)
        {


            try
            {
                StreamWriter escrito = File.AppendText(_path2);
                escrito.Write(Environment.NewLine + ValidarPrametro(ad.id,4) + ValidarPrametro(ad.nombre,25) + ValidarPrametro(ad.departamento,10));
                escrito.Flush();
                escrito.Close();

                

                StreamWriter writeIndices = File.AppendText(_path1);
                writeIndices.Write(Environment.NewLine + encontrar_registro_fila(ad) + "," + ad.departamento + "," + ad.id );
                writeIndices.Flush();
                writeIndices.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: "+ex.Message);
            }

        }

        public void ActualizarArchivo(int id,ArchivoDatos datos)
        {
            var lineas = File.ReadAllLines(_path2);
            lineas[id-1] = ValidarPrametro(datos.id,4) +ValidarPrametro(datos.nombre,25) +ValidarPrametro(datos.departamento,10);
            File.WriteAllLines(_path2,lineas);
        }

        public void EliminarReg(ref List<Indices> _tp)
        {
            try
            {
                string[] tp = new string[_tp.Count()];
                for (int i = 0; i < _tp.Count(); i++)
                {
                    tp[i] = Environment.NewLine + _tp[i].indice + "," + _tp[i].departamento + "," + _tp[i].id_archvio;
                }

                File.WriteAllLines(_path1, tp);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
