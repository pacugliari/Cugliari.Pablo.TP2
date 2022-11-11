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

        /// <summary>
        /// Crea una instancia del tipo SeleccionColorForm cargando los mensajes de ayuda y atributos con valores validos
        /// </summary>
        /// <param name="partida"></param>
        public SeleccionColorForm(Partida partida)
        {
            InitializeComponent();
            this.cerrar = false;
            this.partida = partida;
            this.MostrarAyuda(this.lblJ2, "Elija un color para cambiar el color actual de la partida");

        }

        /// <summary>
        /// Asigna el color Amarillo como color actual de la partida y cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAmarillo_Click(object sender, EventArgs e)
        {
            this.partida.ColorActual = EColor.Amarillo;
            this.cerrar = true;
            this.Close();
        }

        /// <summary>
        /// Asigna el color Azul como color actual de la partida y cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAzul_Click(object sender, EventArgs e)
        {
            this.partida.ColorActual = EColor.Azul;
            this.cerrar = true;
            this.Close();
        }


        /// <summary>
        /// Asigna el color Rojo como color actual de la partida y cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRojo_Click(object sender, EventArgs e)
        {
            this.partida.ColorActual = EColor.Rojo;
            this.cerrar = true;
            this.Close();
        }


        /// <summary>
        /// Asigna el color Verde como color actual de la partida y cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerde_Click(object sender, EventArgs e)
        {
            this.partida.ColorActual = EColor.Verde;
            this.cerrar = true;
            this.Close();
        }

        /// <summary>
        /// Evita que el usuario trate de cerrar la ventana, obligandolo a elegir un color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeleccionColorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!this.cerrar)
                e.Cancel = true;
        }
    }
}
