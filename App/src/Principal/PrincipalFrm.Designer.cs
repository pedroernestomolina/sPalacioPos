namespace App.src.Principal
{
    partial class PrincipalFrm
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
            this.BT_BUSCAR_PRD = new System.Windows.Forms.Button();
            this.BT_SALIDA = new System.Windows.Forms.Button();
            this.BT_CARGAR_CUENTA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BT_BUSCAR_PRD
            // 
            this.BT_BUSCAR_PRD.Location = new System.Drawing.Point(12, 12);
            this.BT_BUSCAR_PRD.Name = "BT_BUSCAR_PRD";
            this.BT_BUSCAR_PRD.Size = new System.Drawing.Size(160, 23);
            this.BT_BUSCAR_PRD.TabIndex = 0;
            this.BT_BUSCAR_PRD.Text = "BUSCAR PRODUCTO";
            this.BT_BUSCAR_PRD.UseVisualStyleBackColor = true;
            this.BT_BUSCAR_PRD.Click += new System.EventHandler(this.BT_BUSCAR_PRD_Click);
            // 
            // BT_SALIDA
            // 
            this.BT_SALIDA.Location = new System.Drawing.Point(262, 278);
            this.BT_SALIDA.Name = "BT_SALIDA";
            this.BT_SALIDA.Size = new System.Drawing.Size(75, 23);
            this.BT_SALIDA.TabIndex = 1;
            this.BT_SALIDA.Text = "SALIDA";
            this.BT_SALIDA.UseVisualStyleBackColor = true;
            this.BT_SALIDA.Click += new System.EventHandler(this.BT_SALIDA_Click);
            // 
            // BT_CARGAR_CUENTA
            // 
            this.BT_CARGAR_CUENTA.Location = new System.Drawing.Point(12, 41);
            this.BT_CARGAR_CUENTA.Name = "BT_CARGAR_CUENTA";
            this.BT_CARGAR_CUENTA.Size = new System.Drawing.Size(160, 23);
            this.BT_CARGAR_CUENTA.TabIndex = 2;
            this.BT_CARGAR_CUENTA.Text = "CARGAR CUENTA";
            this.BT_CARGAR_CUENTA.UseVisualStyleBackColor = true;
            this.BT_CARGAR_CUENTA.Click += new System.EventHandler(this.BT_CARGAR_CUENTA_Click);
            // 
            // PrincipalFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 313);
            this.Controls.Add(this.BT_CARGAR_CUENTA);
            this.Controls.Add(this.BT_SALIDA);
            this.Controls.Add(this.BT_BUSCAR_PRD);
            this.Name = "PrincipalFrm";
            this.Text = "PrincipalFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrincipalFrm_FormClosing);
            this.Load += new System.EventHandler(this.PrincipalFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_BUSCAR_PRD;
        private System.Windows.Forms.Button BT_SALIDA;
        private System.Windows.Forms.Button BT_CARGAR_CUENTA;
    }
}