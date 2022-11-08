
namespace UnoPacGUI
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnJugar = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.lblJ2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.txtNombreJ2 = new System.Windows.Forms.TextBox();
            this.txtNombreJ1 = new System.Windows.Forms.TextBox();
            this.pbCruzJ1 = new System.Windows.Forms.PictureBox();
            this.pbCruzJ2 = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCruzJ1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCruzJ2)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.BackgroundImage")));
            this.pbLogo.Location = new System.Drawing.Point(339, 57);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(327, 420);
            this.pbLogo.TabIndex = 2;
            this.pbLogo.TabStop = false;
            // 
            // btnJugar
            // 
            this.btnJugar.BackColor = System.Drawing.SystemColors.WindowText;
            this.btnJugar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnJugar.BackgroundImage")));
            this.btnJugar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnJugar.Location = new System.Drawing.Point(454, 530);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(115, 119);
            this.btnJugar.TabIndex = 3;
            this.btnJugar.UseVisualStyleBackColor = false;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackColor = System.Drawing.SystemColors.WindowText;
            this.btnHistorial.BackgroundImage = global::UnoPacGUI.Properties.Resources.historial;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHistorial.Location = new System.Drawing.Point(12, 257);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(76, 76);
            this.btnHistorial.TabIndex = 21;
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // lblJ2
            // 
            this.lblJ2.AutoSize = true;
            this.lblJ2.BackColor = System.Drawing.Color.Transparent;
            this.lblJ2.Font = new System.Drawing.Font("Showcard Gothic", 19.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblJ2.ForeColor = System.Drawing.Color.Orange;
            this.lblJ2.Location = new System.Drawing.Point(190, 449);
            this.lblJ2.Name = "lblJ2";
            this.lblJ2.Size = new System.Drawing.Size(651, 42);
            this.lblJ2.TabIndex = 27;
            this.lblJ2.Text = "Ingrese el nombre de los jugadores:";
            this.lblJ2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 19.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(275, 514);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 42);
            this.label1.TabIndex = 28;
            this.label1.Text = "Jugador 1:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 19.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(275, 574);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 42);
            this.label2.TabIndex = 29;
            this.label2.Text = "Jugador 2:";
            this.label2.Visible = false;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.SystemColors.WindowText;
            this.btnSiguiente.BackgroundImage = global::UnoPacGUI.Properties.Resources.skip;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSiguiente.Location = new System.Drawing.Point(575, 631);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(60, 60);
            this.btnSiguiente.TabIndex = 32;
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Visible = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // txtNombreJ2
            // 
            this.txtNombreJ2.Location = new System.Drawing.Point(499, 589);
            this.txtNombreJ2.Name = "txtNombreJ2";
            this.txtNombreJ2.Size = new System.Drawing.Size(203, 27);
            this.txtNombreJ2.TabIndex = 37;
            this.txtNombreJ2.Visible = false;
            this.txtNombreJ2.TextChanged += new System.EventHandler(this.txtNombreJ2_TextChanged);
            // 
            // txtNombreJ1
            // 
            this.txtNombreJ1.Location = new System.Drawing.Point(499, 529);
            this.txtNombreJ1.Name = "txtNombreJ1";
            this.txtNombreJ1.Size = new System.Drawing.Size(203, 27);
            this.txtNombreJ1.TabIndex = 38;
            this.txtNombreJ1.Visible = false;
            this.txtNombreJ1.TextChanged += new System.EventHandler(this.txtNombreJ1_TextChanged);
            // 
            // pbCruzJ1
            // 
            this.pbCruzJ1.BackColor = System.Drawing.Color.Transparent;
            this.pbCruzJ1.BackgroundImage = global::UnoPacGUI.Properties.Resources.cruz;
            this.pbCruzJ1.Location = new System.Drawing.Point(708, 529);
            this.pbCruzJ1.Name = "pbCruzJ1";
            this.pbCruzJ1.Size = new System.Drawing.Size(30, 30);
            this.pbCruzJ1.TabIndex = 39;
            this.pbCruzJ1.TabStop = false;
            this.pbCruzJ1.Visible = false;
            // 
            // pbCruzJ2
            // 
            this.pbCruzJ2.BackColor = System.Drawing.Color.Transparent;
            this.pbCruzJ2.BackgroundImage = global::UnoPacGUI.Properties.Resources.cruz;
            this.pbCruzJ2.Location = new System.Drawing.Point(708, 586);
            this.pbCruzJ2.Name = "pbCruzJ2";
            this.pbCruzJ2.Size = new System.Drawing.Size(30, 30);
            this.pbCruzJ2.TabIndex = 40;
            this.pbCruzJ2.TabStop = false;
            this.pbCruzJ2.Visible = false;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.SystemColors.WindowText;
            this.btnHome.BackgroundImage = global::UnoPacGUI.Properties.Resources.home1;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHome.Location = new System.Drawing.Point(371, 631);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(60, 60);
            this.btnHome.TabIndex = 41;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Visible = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UnoPacGUI.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(982, 703);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.pbCruzJ2);
            this.Controls.Add(this.pbCruzJ1);
            this.Controls.Add(this.txtNombreJ1);
            this.Controls.Add(this.txtNombreJ2);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblJ2);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.pbLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 750);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 750);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inicio_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCruzJ1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCruzJ2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Label lblJ2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.TextBox txtNombreJ2;
        private System.Windows.Forms.TextBox txtNombreJ1;
        private System.Windows.Forms.PictureBox pbCruzJ1;
        private System.Windows.Forms.PictureBox pbCruzJ2;
        private System.Windows.Forms.Button btnHome;
    }
}