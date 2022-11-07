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

namespace InicioForm
{
    public partial class HistoricoForm : Form
    {
        public HistoricoForm()
        {
            InitializeComponent();
        }

        private void rbLogs_CheckedChanged(object sender, EventArgs e)
        {
            this.txtInfoLog.Visible = true;
            this.lbListaArchivos.Visible = true;
            this.dgvPartidas.Visible = false;
            this.lbListaArchivos.Items.Clear();
            this.txtInfoLog.Clear();
            this.lbListaArchivos.Items.AddRange(ArchivosDeTexto.ObtenerArchivos());
        }

        private void lbListaArchivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnEliminar.Enabled = true;
            if(this.lbListaArchivos.SelectedItem is not null)
                this.txtInfoLog.Text = ArchivosDeTexto.LeerArchivoHastaElFinal(this.lbListaArchivos.SelectedItem.ToString());
        }

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lbListaArchivos.Visible)
            {
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
    }
}
