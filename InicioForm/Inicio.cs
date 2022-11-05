using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace InicioForm
{
    public partial class Inicio : Form
    {
        private PartidaForm partifaForm;
        private HistoricoForm historial;

        public Inicio()
        {
            InitializeComponent();
            this.partifaForm = new PartidaForm();
            this.historial = new HistoricoForm();

        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            foreach (Control item in Controls)
            {
                item.Visible = true;
            }
            this.btnJugar.Visible = false;
            this.btnHistorial.Visible = false;
            this.pbCruzJ1.Visible = this.pbCruzJ2.Visible = false;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if(this.txtNombreJ1.Text != "" && this.txtNombreJ2.Text != "")
            {
                this.partifaForm.crearPartida(this.txtNombreJ1.Text.ToString(), this.txtNombreJ2.Text.ToString());
                this.partifaForm.Show();

                foreach (Control item in Controls)
                {
                    item.Visible = false;
                }
                this.btnJugar.Visible = true;
                this.btnHistorial.Visible = true;
                this.pbLogo.Visible = true;
                this.txtNombreJ1.Clear();
                this.txtNombreJ2.Clear();
                this.partifaForm = new PartidaForm();
            }
            else
            {
                if (this.txtNombreJ1.Text == "")
                {
                    this.pbCruzJ1.Visible = true;
                }
                if (this.txtNombreJ2.Text == "")
                {
                    this.pbCruzJ2.Visible = true;
                }
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            this.historial.ShowDialog();
            this.historial = new HistoricoForm();
        }

        private void txtNombreJ1_TextChanged(object sender, EventArgs e)
        {
            this.pbCruzJ1.Visible = false;
      
        }

        private void txtNombreJ2_TextChanged(object sender, EventArgs e)
        {
            this.pbCruzJ2.Visible = false;
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Esta seguro que desea salir de Uno Pac ?", "Uno Pac", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }

}
