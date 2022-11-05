
namespace InicioForm
{
    partial class HistoricoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoricoForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.rbPartidas = new System.Windows.Forms.RadioButton();
            this.rbLogs = new System.Windows.Forms.RadioButton();
            this.lbListaArchivos = new System.Windows.Forms.ListBox();
            this.txtInfoLog = new System.Windows.Forms.TextBox();
            this.dgvPartidas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jugador1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jugador2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ganador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puntosGanador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartidas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.rbPartidas);
            this.groupBox1.Controls.Add(this.rbLogs);
            this.groupBox1.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.Orange;
            this.groupBox1.Location = new System.Drawing.Point(43, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(925, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Historial";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Orange;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Location = new System.Drawing.Point(711, 40);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 29);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // rbPartidas
            // 
            this.rbPartidas.AutoSize = true;
            this.rbPartidas.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbPartidas.ForeColor = System.Drawing.Color.Orange;
            this.rbPartidas.Location = new System.Drawing.Point(277, 44);
            this.rbPartidas.Name = "rbPartidas";
            this.rbPartidas.Size = new System.Drawing.Size(286, 25);
            this.rbPartidas.TabIndex = 1;
            this.rbPartidas.TabStop = true;
            this.rbPartidas.Text = "Ver estadisticas de partidas";
            this.rbPartidas.UseVisualStyleBackColor = true;
            this.rbPartidas.CheckedChanged += new System.EventHandler(this.rbPartidas_CheckedChanged);
            // 
            // rbLogs
            // 
            this.rbLogs.AutoSize = true;
            this.rbLogs.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbLogs.ForeColor = System.Drawing.Color.Orange;
            this.rbLogs.Location = new System.Drawing.Point(24, 44);
            this.rbLogs.Name = "rbLogs";
            this.rbLogs.Size = new System.Drawing.Size(220, 25);
            this.rbLogs.TabIndex = 0;
            this.rbLogs.TabStop = true;
            this.rbLogs.Text = "Ver logs de partidas ";
            this.rbLogs.UseVisualStyleBackColor = true;
            this.rbLogs.CheckedChanged += new System.EventHandler(this.rbLogs_CheckedChanged);
            // 
            // lbListaArchivos
            // 
            this.lbListaArchivos.BackColor = System.Drawing.Color.Orange;
            this.lbListaArchivos.FormattingEnabled = true;
            this.lbListaArchivos.ItemHeight = 20;
            this.lbListaArchivos.Location = new System.Drawing.Point(43, 130);
            this.lbListaArchivos.Name = "lbListaArchivos";
            this.lbListaArchivos.Size = new System.Drawing.Size(925, 104);
            this.lbListaArchivos.TabIndex = 2;
            this.lbListaArchivos.SelectedIndexChanged += new System.EventHandler(this.lbListaArchivos_SelectedIndexChanged);
            // 
            // txtInfoLog
            // 
            this.txtInfoLog.BackColor = System.Drawing.Color.Orange;
            this.txtInfoLog.Location = new System.Drawing.Point(43, 254);
            this.txtInfoLog.Multiline = true;
            this.txtInfoLog.Name = "txtInfoLog";
            this.txtInfoLog.ReadOnly = true;
            this.txtInfoLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfoLog.Size = new System.Drawing.Size(925, 270);
            this.txtInfoLog.TabIndex = 1;
            // 
            // dgvPartidas
            // 
            this.dgvPartidas.AllowUserToAddRows = false;
            this.dgvPartidas.AllowUserToDeleteRows = false;
            this.dgvPartidas.BackgroundColor = System.Drawing.Color.Orange;
            this.dgvPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fecha,
            this.jugador1,
            this.jugador2,
            this.ganador,
            this.puntosGanador,
            this.duracion});
            this.dgvPartidas.Location = new System.Drawing.Point(43, 130);
            this.dgvPartidas.Name = "dgvPartidas";
            this.dgvPartidas.ReadOnly = true;
            this.dgvPartidas.RowHeadersWidth = 51;
            this.dgvPartidas.RowTemplate.Height = 29;
            this.dgvPartidas.Size = new System.Drawing.Size(925, 394);
            this.dgvPartidas.TabIndex = 2;
            this.dgvPartidas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartidas_CellClick);
            // 
            // id
            // 
            this.id.Frozen = true;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 125;
            // 
            // fecha
            // 
            this.fecha.Frozen = true;
            this.fecha.HeaderText = "Fecha";
            this.fecha.MinimumWidth = 6;
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 125;
            // 
            // jugador1
            // 
            this.jugador1.Frozen = true;
            this.jugador1.HeaderText = "Jugador 1";
            this.jugador1.MinimumWidth = 6;
            this.jugador1.Name = "jugador1";
            this.jugador1.ReadOnly = true;
            this.jugador1.Width = 125;
            // 
            // jugador2
            // 
            this.jugador2.Frozen = true;
            this.jugador2.HeaderText = "Jugador 2";
            this.jugador2.MinimumWidth = 6;
            this.jugador2.Name = "jugador2";
            this.jugador2.ReadOnly = true;
            this.jugador2.Width = 125;
            // 
            // ganador
            // 
            this.ganador.Frozen = true;
            this.ganador.HeaderText = "Ganador";
            this.ganador.MinimumWidth = 6;
            this.ganador.Name = "ganador";
            this.ganador.ReadOnly = true;
            this.ganador.Width = 125;
            // 
            // puntosGanador
            // 
            this.puntosGanador.Frozen = true;
            this.puntosGanador.HeaderText = "Puntos Ganador";
            this.puntosGanador.MinimumWidth = 6;
            this.puntosGanador.Name = "puntosGanador";
            this.puntosGanador.ReadOnly = true;
            this.puntosGanador.Width = 125;
            // 
            // duracion
            // 
            this.duracion.Frozen = true;
            this.duracion.HeaderText = "Duracion";
            this.duracion.MinimumWidth = 6;
            this.duracion.Name = "duracion";
            this.duracion.ReadOnly = true;
            this.duracion.Width = 125;
            // 
            // HistoricoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InicioForm.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(1005, 552);
            this.Controls.Add(this.dgvPartidas);
            this.Controls.Add(this.lbListaArchivos);
            this.Controls.Add(this.txtInfoLog);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HistoricoForm";
            this.Text = "UnoPac";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbListaArchivos;
        private System.Windows.Forms.RadioButton rbPartidas;
        private System.Windows.Forms.RadioButton rbLogs;
        private System.Windows.Forms.TextBox txtInfoLog;
        private System.Windows.Forms.DataGridView dgvPartidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn jugador1;
        private System.Windows.Forms.DataGridViewTextBoxColumn jugador2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ganador;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntosGanador;
        private System.Windows.Forms.DataGridViewTextBoxColumn duracion;
        private System.Windows.Forms.Button btnEliminar;
    }
}