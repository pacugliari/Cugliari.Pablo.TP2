using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace UnoPacGUI
{
    public partial class Inicio : Form
    {
        private HistoricoForm historial;
        private bool quitarSonido;

        /// <summary>
        /// Crea una instancia de Inicio cargando los mensajes de ayuda y poniendo el quitar sonido en false
        /// </summary>
        public Inicio()
        {
            InitializeComponent();
            this.historial = new HistoricoForm();
            this.MostrarAyuda(this.btnHistorial, "Historial de partidas ganadas");
            this.MostrarAyuda(this.btnHome, "Volver al inicio");
            this.MostrarAyuda(this.btnJugar, "Iniciar partida nueva");
            this.MostrarAyuda(this.btnSiguiente, "Comenzar partida");
            this.MostrarAyuda(this.txtNombreJ1, "Nombre jugador 1");
            this.MostrarAyuda(this.txtNombreJ2, "Nombre jugador 2");
            this.quitarSonido = false;


        }

        /// <summary>
        /// Habilita todos los controles para cargar los datos de los jugadores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJugar_Click(object sender, EventArgs e)
        {
            ((Button)sender).ReproducirRuido(quitarSonido);
            foreach (Control item in Controls)
            {
                item.Visible = true;
            }
            this.btnJugar.Visible = false;
            this.btnHistorial.Visible = false;
            this.pbCruzJ1.Visible = this.pbCruzJ2.Visible = false;
        }

        /// <summary>
        /// Ejecuta un task en un hilo distinto al principal permitiendo ejecutar varias partidas al mismo tiempo
        /// </summary>
        private void EjecutarNuevaPartida()
        {
            object[] nombres = new object[] { this.txtNombreJ1.Text.ToString(), this.txtNombreJ2.Text.ToString() };
            Task.Run(() =>
            {
                PartidaForm partifaForm = new PartidaForm(nombres[0].ToString(), nombres[1].ToString());
                partifaForm.ShowDialog();
            });
        }

        /// <summary>
        /// Verifica los datos cargados y genera una nueva partida , limpiando los controles de inicio para 
        /// dejarlo listo por si se quiere crear una nueva partida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ((Button)sender).ReproducirRuido(quitarSonido);
            if (this.txtNombreJ1.Text != "" && this.txtNombreJ2.Text != "")
            {
                this.EjecutarNuevaPartida();

                foreach (Control item in Controls)
                {
                    item.Visible = false;
                }
                this.btnJugar.Visible = true;
                this.btnHistorial.Visible = true;
                this.pbLogo.Visible = true;
                this.btnMusica.Visible = true;
                this.txtNombreJ1.Clear();
                this.txtNombreJ2.Clear();
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

        /// <summary>
        /// Crea y muestra el formulario HistoricoForm de manera modal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            ((Button)sender).ReproducirRuido(quitarSonido);
            this.historial.ShowDialog();
            this.historial = new HistoricoForm();
        }

        /// <summary>
        /// Oculta el pictureBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreJ1_TextChanged(object sender, EventArgs e)
        {
            this.pbCruzJ1.Visible = false;
      
        }

        /// <summary>
        /// Oculta el pictureBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreJ2_TextChanged(object sender, EventArgs e)
        {
            this.pbCruzJ2.Visible = false;
        }

        /// <summary>
        /// Pregunta si se quiere salir de la partida, en el caso afirmativo cierra sino permanece en el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Esta seguro que desea salir de Uno Pac ?", "Uno Pac", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Carga los controles necesarios de la pantalla de inicio ocultando el resto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHome_Click(object sender, EventArgs e)
        {
            ((Button)sender).ReproducirRuido(quitarSonido);
            foreach (Control item in Controls)
            {
                item.Visible = false;
            }
            this.btnJugar.Visible = true;
            this.btnHistorial.Visible = true;
            this.pbLogo.Visible = true;
            this.btnMusica.Visible = true;
        }

        /// <summary>
        /// Activa o Desactiva la musica del juego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMusica_Click(object sender, EventArgs e)
        {
            if (!this.quitarSonido)
            {
                this.btnMusica.BackgroundImage = Properties.Resources.mutearMusica;
            }
            else
            {
                this.btnMusica.BackgroundImage = Properties.Resources.musica;
            }
            this.quitarSonido = !this.quitarSonido;
        }
    }

}
