using Logica;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmConfiguracion : Form
    {
        public RedNeuronal Rna { get; set; }
        public FrmConfiguracion()
        {
            InitializeComponent();
            Rna = new RedNeuronal();
        }

        public bool validarCampos()
        {
            if (!string.IsNullOrEmpty(txtIteraciones.Text) && !string.IsNullOrEmpty(txtRata.Text) && !string.IsNullOrEmpty(txtErrorMaximo.Text))
            {
                Rna.NumeroIteraciones = Convert.ToInt32(txtIteraciones.Text);
                Rna.RataAprendizaje = (float)Convert.ToDouble(txtRata.Text);
                Rna.ErrorMaximo = (float)Convert.ToDouble(txtErrorMaximo.Text);

                return true;
            }
            MessageBox.Show("Campos Vacios");
            return false;
        }

        private void FrmConfiguracion_Load(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rna.InicializacionPesos(Rna.M, Rna.N);
        }

        private void comboBoxFuncionActivacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rna.FuncionActivacion = comboBoxFuncionActivacion.SelectedItem.ToString();
            Console.WriteLine(string.Format("Funcion de Activacion = {0}  ", comboBoxFuncionActivacion.SelectedItem.ToString()));

        }
    }
}
