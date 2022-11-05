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
            this.lbListaArchivos.Items.AddRange(ArchivosDeTexto.ObtenerArchivos());
        }

        private void lbListaArchivos_SelectedIndexChanged(object sender, EventArgs e)
        {
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
    }
}
