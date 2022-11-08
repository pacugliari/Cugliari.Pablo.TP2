
namespace UnoPacGUI
{
    partial class SeleccionColorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionColorForm));
            this.btnAmarillo = new System.Windows.Forms.Button();
            this.btnAzul = new System.Windows.Forms.Button();
            this.btnRojo = new System.Windows.Forms.Button();
            this.btnVerde = new System.Windows.Forms.Button();
            this.lblJ2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAmarillo
            // 
            this.btnAmarillo.BackColor = System.Drawing.Color.Transparent;
            this.btnAmarillo.BackgroundImage = global::UnoPacGUI.Properties.Resources.colorAmarillo;
            this.btnAmarillo.FlatAppearance.BorderSize = 0;
            this.btnAmarillo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmarillo.ForeColor = System.Drawing.Color.Transparent;
            this.btnAmarillo.Location = new System.Drawing.Point(67, 84);
            this.btnAmarillo.Name = "btnAmarillo";
            this.btnAmarillo.Size = new System.Drawing.Size(66, 66);
            this.btnAmarillo.TabIndex = 19;
            this.btnAmarillo.UseVisualStyleBackColor = false;
            this.btnAmarillo.Click += new System.EventHandler(this.btnAmarillo_Click);
            // 
            // btnAzul
            // 
            this.btnAzul.BackColor = System.Drawing.Color.Transparent;
            this.btnAzul.BackgroundImage = global::UnoPacGUI.Properties.Resources.colorAzul;
            this.btnAzul.FlatAppearance.BorderSize = 0;
            this.btnAzul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAzul.ForeColor = System.Drawing.Color.Transparent;
            this.btnAzul.Location = new System.Drawing.Point(162, 84);
            this.btnAzul.Name = "btnAzul";
            this.btnAzul.Size = new System.Drawing.Size(66, 66);
            this.btnAzul.TabIndex = 20;
            this.btnAzul.UseVisualStyleBackColor = false;
            this.btnAzul.Click += new System.EventHandler(this.btnAzul_Click);
            // 
            // btnRojo
            // 
            this.btnRojo.BackColor = System.Drawing.Color.Transparent;
            this.btnRojo.BackgroundImage = global::UnoPacGUI.Properties.Resources.colorRojo;
            this.btnRojo.FlatAppearance.BorderSize = 0;
            this.btnRojo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRojo.ForeColor = System.Drawing.Color.Transparent;
            this.btnRojo.Location = new System.Drawing.Point(67, 174);
            this.btnRojo.Name = "btnRojo";
            this.btnRojo.Size = new System.Drawing.Size(66, 66);
            this.btnRojo.TabIndex = 21;
            this.btnRojo.UseVisualStyleBackColor = false;
            this.btnRojo.Click += new System.EventHandler(this.btnRojo_Click);
            // 
            // btnVerde
            // 
            this.btnVerde.BackColor = System.Drawing.Color.Transparent;
            this.btnVerde.BackgroundImage = global::UnoPacGUI.Properties.Resources.colorVerde;
            this.btnVerde.FlatAppearance.BorderSize = 0;
            this.btnVerde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerde.ForeColor = System.Drawing.Color.Transparent;
            this.btnVerde.Location = new System.Drawing.Point(162, 174);
            this.btnVerde.Name = "btnVerde";
            this.btnVerde.Size = new System.Drawing.Size(66, 66);
            this.btnVerde.TabIndex = 22;
            this.btnVerde.UseVisualStyleBackColor = false;
            this.btnVerde.Click += new System.EventHandler(this.btnVerde_Click);
            // 
            // lblJ2
            // 
            this.lblJ2.AutoSize = true;
            this.lblJ2.BackColor = System.Drawing.Color.Transparent;
            this.lblJ2.Font = new System.Drawing.Font("Showcard Gothic", 19.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblJ2.ForeColor = System.Drawing.Color.Orange;
            this.lblJ2.Location = new System.Drawing.Point(12, 19);
            this.lblJ2.Name = "lblJ2";
            this.lblJ2.Size = new System.Drawing.Size(276, 42);
            this.lblJ2.TabIndex = 27;
            this.lblJ2.Text = "Elija un color:";
            // 
            // SeleccionColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UnoPacGUI.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(300, 268);
            this.Controls.Add(this.lblJ2);
            this.Controls.Add(this.btnVerde);
            this.Controls.Add(this.btnRojo);
            this.Controls.Add(this.btnAzul);
            this.Controls.Add(this.btnAmarillo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(318, 315);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(318, 315);
            this.Name = "SeleccionColorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SeleccionColorForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAmarillo;
        private System.Windows.Forms.Button btnAzul;
        private System.Windows.Forms.Button btnRojo;
        private System.Windows.Forms.Button btnVerde;
        private System.Windows.Forms.Label lblJ2;
    }
}