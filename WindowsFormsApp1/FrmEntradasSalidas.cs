using Logica;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmEntradasSalidas : Form
    {
        public RedNeuronal Rna { get; set; }
        public FrmEntradasSalidas()
        {
            InitializeComponent();
            Rna = new RedNeuronal();
        }

        private void FrmEntradasSalidas_Load(object sender, EventArgs e)
        {

        }

        public bool validarCampos()
        {
            if (!string.IsNullOrEmpty(txtNombre.Text) && Rna != null)
            {
                Rna.Nombre = txtNombre.Text;
                return true;
            }
            MessageBox.Show("Hay campos vacios");
            return false;
        }

        private void btnEntradasSalidas_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                FileName = "archivo Json",
                Filter = "Json files (*.json)|*.json|Todos los archivos (*.*)|*.*",
                Title = "Abriendo archivo Json"
            };

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string json = File.ReadAllText(file);
                    Rna = JsonConvert.DeserializeObject<RedNeuronal>(json);
                    cargarEntradasSalidasPatrones(Rna.X.GetLength(1), Rna.Yd.GetLength(1), Rna.X.GetLength(0));
                    cargarTablas();

                }
                catch (IOException)
                {
                }
            }
        }

        private void cargarTablas()
        {
            for (int i = 0; i < Rna.X.GetLength(0); i++)
            {
                string cadena = "";
                for (int j = 0; j < Rna.X.GetLength(1); j++)
                {
                    cadena += $"{Rna.X[i, j]} \t";
                }
                listEntradas.Items.Add(cadena);
            }

            for (int i = 0; i < Rna.Yd.GetLength(0); i++)
            {
                string cadena = "";
                for (int j = 0; j < Rna.Yd.GetLength(1); j++)
                {
                    cadena += $"{Rna.Yd[i, j]} \t";
                }
                listSalidas.Items.Add(cadena);
            }
        }

        private void cargarEntradasSalidasPatrones(int entradas, int salidas, int patrones)
        {
            lblEntras.Text = $"Entradas: {entradas}";
            lblSalidas.Text = $"Salidas: {salidas}";
            lblPatrones.Text = $"Patrones: {patrones}";

            Rna.M = entradas;//entradas
            Rna.N = salidas;//salidas
            Rna.Patrones = patrones;//patrones
        }
    }
}
