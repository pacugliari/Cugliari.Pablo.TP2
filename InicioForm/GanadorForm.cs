using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnoPacGUI
{
    public partial class GanadorForm : Form
    {
        private bool quitarSonido;
        public GanadorForm(string nombre,string puntos,string duracion)
        {
            InitializeComponent();
            this.lblTiempo.Text = duracion;
            this.lblNombreJugador.Text = nombre;
            this.lblPuntos.Text = puntos;
            this.MostrarAyuda(this.btnHome, "Volver al inicio");
            this.quitarSonido = true;
            
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ((Button)(sender)).ReproducirRuido(quitarSonido);
            this.Close();
        }

    }
}
