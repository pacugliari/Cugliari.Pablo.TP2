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
        /// <summary>
        /// Crea una instancia del tipo GanadorForm con el nombre,puntos y duracion pasados por el parametro
        /// </summary>
        /// <param name="nombre">string con el nombre del ganador</param>
        /// <param name="puntos">string con los puntos del ganador</param>
        /// <param name="duracion">string con la duracion de la partida</param>
        public GanadorForm(string nombre,string puntos,string duracion)
        {
            InitializeComponent();
            this.lblTiempo.Text = duracion;
            this.lblNombreJugador.Text = nombre;
            this.lblPuntos.Text = puntos;
            this.MostrarAyuda(this.btnHome, "Volver al inicio");
            this.quitarSonido = true;
            
        }
        /// <summary>
        /// Reproduce un sonido y cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHome_Click(object sender, EventArgs e)
        {
            ((Button)(sender)).ReproducirRuido(quitarSonido);
            this.Close();
        }

    }
}
