﻿namespace WindowsFormsApp1
{
	partial class FrmPatrones
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.button1 = new System.Windows.Forms.Button();
            this.listPatrones = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listSalidas = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSimulacion = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(88, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cargar Entrenamiento";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listPatrones
            // 
            this.listPatrones.FormattingEnabled = true;
            this.listPatrones.Location = new System.Drawing.Point(244, 165);
            this.listPatrones.Name = "listPatrones";
            this.listPatrones.Size = new System.Drawing.Size(197, 186);
            this.listPatrones.TabIndex = 2;
            this.listPatrones.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Patrones";
            // 
            // listSalidas
            // 
            this.listSalidas.FormattingEnabled = true;
            this.listSalidas.Location = new System.Drawing.Point(565, 165);
            this.listSalidas.Name = "listSalidas";
            this.listSalidas.Size = new System.Drawing.Size(159, 186);
            this.listSalidas.TabIndex = 4;
            this.listSalidas.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(182)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 71);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(316, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Entrenamiento";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Green;
            this.panel2.Location = new System.Drawing.Point(0, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 38);
            this.panel2.TabIndex = 6;
            // 
            // btnSimulacion
            // 
            this.btnSimulacion.Enabled = false;
            this.btnSimulacion.Location = new System.Drawing.Point(461, 244);
            this.btnSimulacion.Name = "btnSimulacion";
            this.btnSimulacion.Size = new System.Drawing.Size(84, 31);
            this.btnSimulacion.TabIndex = 7;
            this.btnSimulacion.Text = "Simulación";
            this.btnSimulacion.UseVisualStyleBackColor = true;
            // 
            // FrmPatrones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSimulacion);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listSalidas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listPatrones);
            this.Controls.Add(this.button1);
            this.Name = "FrmPatrones";
            this.Text = "FrmSimulacion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listPatrones;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listSalidas;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnSimulacion;
	}
}