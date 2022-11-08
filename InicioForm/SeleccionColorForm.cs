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

namespace UnoPacGUI
{
    public partial class SeleccionColorForm : Form
    {
        private bool cerrar;
        private Partida partida;
        public SeleccionColorForm(Partida partida)
        {
            InitializeComponent();
            this.cerrar = false;
            this.partida = partida;
            Inicio.MostrarAyuda(this.lblJ2, "Elija un color para cambiar el color actual de la partida");

        }

        private void btnAmarillo_Click(object sender, EventArgs e)
        {
            this.partida.ColorActual = EColor.Amarillo;
            this.cerrar = true;
            this.Close();
        }

        private void btnAzul_Click(object sender, EventArgs e)
        {
            this.partida.ColorActual = EColor.Azul;
            this.cerrar = true;
            this.Close();
        }

        private void btnRojo_Click(object sender, EventArgs e)
        {
            this.partida.ColorActual = EColor.Rojo;
            this.cerrar = true;
            this.Close();
        }

        private void btnVerde_Click(object sender, EventArgs e)
        {
            this.partida.ColorActual = EColor.Verde;
            this.cerrar = true;
            this.Close();
        }

        private void SeleccionColorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!this.cerrar)
                e.Cancel = true;
        }
    }
}
