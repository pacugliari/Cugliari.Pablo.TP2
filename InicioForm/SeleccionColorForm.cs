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
    public partial class SeleccionColorForm : Form
    {
        private bool cerrar;
        public SeleccionColorForm()
        {
            InitializeComponent();
            this.cerrar = false;
            
        }

        private void btnAmarillo_Click(object sender, EventArgs e)
        {
            Partida.ColorActual = EColor.Amarillo;
            this.cerrar = true;
            this.Close();
        }

        private void btnAzul_Click(object sender, EventArgs e)
        {
            Partida.ColorActual = EColor.Azul;
            this.cerrar = true;
            this.Close();
        }

        private void btnRojo_Click(object sender, EventArgs e)
        {
            Partida.ColorActual = EColor.Rojo;
            this.cerrar = true;
            this.Close();
        }

        private void btnVerde_Click(object sender, EventArgs e)
        {
            Partida.ColorActual = EColor.Verde;
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
