using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InicioForm
{
    public partial class Inicio : Form
    {
        private PartidaForm partifaForm;

        public Inicio()
        {
            InitializeComponent();
            this.partifaForm = new PartidaForm();
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            foreach (Control item in Controls)
            {
                item.Visible = true;
            }
            this.btnJugar.Visible = false;
            this.btnHistorial.Visible = false;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.partifaForm.crearPartida(this.txtNombreJ1.Text.ToString(),this.txtNombreJ2.Text.ToString());
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

        private void btnHistorial_Click(object sender, EventArgs e)
        {

        }
    }

}
