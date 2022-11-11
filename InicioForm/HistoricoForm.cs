using Entidades;
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
    public partial class HistoricoForm : Form
    {
        public HistoricoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Si el radioButton Logs esta chequeado carga los paths de archivos de las partidas ganadas en el ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbLogs_CheckedChanged(object sender, EventArgs e)
        {
            this.txtInfoLog.Visible = true;
            this.lbListaArchivos.Visible = true;
            this.dgvPartidas.Visible = false;
            this.lbListaArchivos.Items.Clear();
            this.txtInfoLog.Clear();
            this.lbListaArchivos.Items.AddRange(ArchivosDeTexto.ObtenerArchivos());
        }

        /// <summary>
        /// Si se selecciona algun item del ListBox de ListaArchivos, se carga todo su contenido en el TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbListaArchivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnEliminar.Enabled = true;
            if(this.lbListaArchivos.SelectedItem is not null)
                this.txtInfoLog.Text = ArchivosDeTexto.LeerArchivoHastaElFinal(this.lbListaArchivos.SelectedItem.ToString());
        }

        /// <summary>
        /// Si el radioButton Partidas esta chequeado, carga la base de datos y la muestra en un DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbPartidas_CheckedChanged(object sender, EventArgs e)
        {
            this.txtInfoLog.Visible = false;
            this.dgvPartidas.Visible = true;
            this.lbListaArchivos.Visible = false;
            this.dgvPartidas.Rows.Clear();

            foreach (PartidaSQL item in SQL.ObtenerListaDato())
            {
                this.dgvPartidas.Rows.Add(item.ToString().Split('-'));
            }
        }

        /// <summary>
        /// Si selecciona algun item del ListBox o DataGridView se habilita el boton de Eliminar permitiendo eliminar el archivo
        /// o dato en el SQL segun corresponda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lbListaArchivos.Visible)
            {
                if(this.lbListaArchivos.SelectedItem is not null)
                    ArchivosDeTexto.EliminarArchivo(this.lbListaArchivos.SelectedItem.ToString());
                this.rbLogs_CheckedChanged(sender, e);
            }
            else
            {
                int id = int.Parse(this.dgvPartidas.CurrentRow.Cells[0].Value.ToString());
                if (this.dgvPartidas.Rows.Count > 0)
                {
                    SQL.EliminarDato(id);
                }
                this.rbPartidas_CheckedChanged(sender, e);
            }
            this.btnEliminar.Enabled = false;
        }

        /// <summary>
        /// Si selecciona alguna columna del DataGridView marca en azul toda la fila de la columna seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPartidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvPartidas.Rows.Count > 0)
            {
                this.dgvPartidas.CurrentRow.Selected = true;
                this.btnEliminar.Enabled = true;
            }
            else
                this.btnEliminar.Enabled = false;
        }

        /// <summary>
        /// Verifica si hay conexion con la base de datos, en caso de no haber bloquea el radioButton Partidas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistoricoForm_Load(object sender, EventArgs e)
        {
            if (!SQL.ProbarConexion())
            {
                this.rbPartidas.Enabled = false;
            }else
                this.rbPartidas.Enabled = true;
        }
    }
}
