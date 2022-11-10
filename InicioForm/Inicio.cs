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

        private void EjecutarNuevaPartida()
        {
            object[] nombres = new object[] { this.txtNombreJ1.Text.ToString(), this.txtNombreJ2.Text.ToString() };
            Task.Run(() =>
            {
                PartidaForm partifaForm = new PartidaForm(nombres[0].ToString(), nombres[1].ToString());
                partifaForm.ShowDialog();
            });
        }

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

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            ((Button)sender).ReproducirRuido(quitarSonido);
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
