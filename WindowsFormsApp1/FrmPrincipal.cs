using Logica;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmPrincipal : Form
    {
        RedNeuronal Rna { get; set; }
        FrmEntradasSalidas frmEntradasSalidas;
        FrmConfiguracion frmConfiguracion;
        FrmEntrenamiento frmEntrenamiento;


        public FrmPrincipal()
        {
            InitializeComponent();
            Rna = new RedNeuronal();
            frmEntradasSalidas = new FrmEntradasSalidas();
            frmConfiguracion = new FrmConfiguracion();
            frmEntrenamiento = new FrmEntrenamiento();
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AbrirFormHija(frmEntradasSalidas);
        }

        private void AbrirFormHija(object formhija)
        {
            if (this.panelcontenedor.Controls.Count > 0)
            {
                this.panelcontenedor.Controls.RemoveAt(0);
            }

            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Parent = panelcontenedor;
            fh.Location = new Point((panelcontenedor.Width - fh.Width) / 2, (panelcontenedor.Height - fh.Height) / 2);
            this.panelcontenedor.Controls.Add(fh);
            this.panelcontenedor.Tag = fh;
            fh.Show();

        }

        private void btnEntradasSalidas_Click(object sender, EventArgs e)
        {
            AbrirFormHija(frmEntradasSalidas);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            if (frmEntradasSalidas.validarCampos())
            {
                frmConfiguracion.Rna.X = frmEntradasSalidas.Rna.X;
                frmConfiguracion.Rna.Yd = frmEntradasSalidas.Rna.Yd;
                frmConfiguracion.Rna.Patrones = frmEntradasSalidas.Rna.Patrones;
                frmConfiguracion.Rna.M = frmEntradasSalidas.Rna.M;
                frmConfiguracion.Rna.N = frmEntradasSalidas.Rna.N;
                frmConfiguracion.Rna.Nombre = frmEntradasSalidas.Rna.Nombre;
                
                AbrirFormHija(frmConfiguracion);
            }
        }

        private void btnEntrenamiento_Click(object sender, EventArgs e)
        {
            if (frmConfiguracion.validarCampos())
            {

                AbrirFormHija(frmEntrenamiento);

                Rna.X = frmEntradasSalidas.Rna.X;
                Rna.Yd = frmEntradasSalidas.Rna.Yd;
                Rna.Patrones = frmEntradasSalidas.Rna.Patrones;
                Rna.M = frmEntradasSalidas.Rna.M;
                Rna.N = frmEntradasSalidas.Rna.N;
                Rna.Nombre = frmEntradasSalidas.Rna.Nombre;

                Rna.NumeroIteraciones = frmConfiguracion.Rna.NumeroIteraciones;
                Rna.RataAprendizaje = frmConfiguracion.Rna.RataAprendizaje;
                Rna.ErrorMaximo = frmConfiguracion.Rna.ErrorMaximo;
                Rna.W = frmConfiguracion.Rna.W;
                Rna.U = frmConfiguracion.Rna.U;
                Rna.WAnt = frmConfiguracion.Rna.WAnt;
                Rna.FuncionActivacion = frmConfiguracion.Rna.FuncionActivacion;

                frmEntrenamiento.Rna = Rna;
                frmEntrenamiento.Rna.FormEntrenamiento = frmEntrenamiento;
                frmEntrenamiento.iniciarEntrenamiento();
            }
        }

    }




}

