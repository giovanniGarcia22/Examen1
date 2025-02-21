using System.Windows.Forms.VisualStyles;

namespace Examen1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                    string filNam = openFileDialog1.FileName;
                    string read = File.ReadAllText(filNam);
                    string[] ren = read.Split('\n');
                    dataGridView1.Columns.Clear();
                    string[] x = ren[0].Split(',');
                    dataGridView1.Columns.Add("RFC", "RFC");
                    dataGridView1.Columns.Add("Promedio", "Promedio");
                    dataGridView1.Columns.Add("Edad", "Edad");
                    dataGridView1.Columns.Add("Sexo", "Sexo");
                    for (int i = 0; i < x.Length; i++)
                    {
                        if (x[i] != "RFC" && x[i] != "Promedio")
                        {
                            dataGridView1.Columns.Add(x[i].Trim(), x[i].Trim());
                        }
                    }
                    for (int i = 0; i < ren.Length; i++)
                    {
                        string[] resultados = ren[i].Split(',');
                        if (resultados.Length == x.Length)
                        {
                            string curp = resultados[0].Trim();
                            string prom = resultados[1].Trim();
                            int edad = CalcularEdad(curp);
                            string sexo = DeterminarSexo(curp);
                            string[] col = new string[dataGridView1.Columns.Count];
                            col[0] = curp; 
                            col[1] = prom; 
                            col[2] = edad.ToString();
                            col[3] = sexo;
                            for (int j = 2; j < resultados.Length; j++)
                            {
                                col[j + 2] = resultados[j];
                            }
                            dataGridView1.Rows.Add(col);
                        }



                    }
                
                
            }

        }
        private int CalcularEdad(string curp)
        {
            int edad;
            DateTime x = DateTime.Now;
            int año;
            int mes = Convert.ToInt16(curp.Substring(6, 2));
            String añoS = curp.Substring(4, 2);
            if (Convert.ToInt16(añoS) > 25)
            {
                año = Convert.ToInt16("19" + añoS);
            }
            else
            {
                año = Convert.ToInt16("20" + añoS);
            }
            if ((x.Month - mes) < 0)
            {
                edad = (x.Year - año) - 1;
            }
            else
            {
                edad = x.Month - año;
            }
            return edad;
        }

        private string DeterminarSexo(string curp)
        {
            String sexo = curp.Substring(10, 1);
            if (sexo == "H"){
                return "Masculino";
            }
            else{
                return "Femenino";
            }
        }

    }
}
