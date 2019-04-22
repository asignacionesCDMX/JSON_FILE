namespace Json
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.Ms_Principal = new System.Windows.Forms.MenuStrip();
            this.procesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargaAmexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.principalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Lbl_Version = new System.Windows.Forms.ToolStripStatusLabel();
            this.Ms_Principal.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ms_Principal
            // 
            this.Ms_Principal.BackColor = System.Drawing.SystemColors.Control;
            this.Ms_Principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.procesosToolStripMenuItem,
            this.portalToolStripMenuItem,
            this.bitacoraToolStripMenuItem});
            this.Ms_Principal.Location = new System.Drawing.Point(0, 0);
            this.Ms_Principal.Name = "Ms_Principal";
            this.Ms_Principal.Size = new System.Drawing.Size(974, 24);
            this.Ms_Principal.TabIndex = 0;
            this.Ms_Principal.Text = "Ms_Principal";
            // 
            // procesosToolStripMenuItem
            // 
            this.procesosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargaAmexToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.salirToolStripMenuItem});
            this.procesosToolStripMenuItem.Name = "procesosToolStripMenuItem";
            this.procesosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.procesosToolStripMenuItem.Text = "Procesos";
            // 
            // cargaAmexToolStripMenuItem
            // 
            this.cargaAmexToolStripMenuItem.Name = "cargaAmexToolStripMenuItem";
            this.cargaAmexToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.cargaAmexToolStripMenuItem.Text = "Carga Amex";
            this.cargaAmexToolStripMenuItem.Click += new System.EventHandler(this.cargaAmexToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(135, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // portalToolStripMenuItem
            // 
            this.portalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.principalToolStripMenuItem});
            this.portalToolStripMenuItem.Name = "portalToolStripMenuItem";
            this.portalToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.portalToolStripMenuItem.Text = "Portal";
            // 
            // principalToolStripMenuItem
            // 
            this.principalToolStripMenuItem.Name = "principalToolStripMenuItem";
            this.principalToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.principalToolStripMenuItem.Text = "Principal";
            this.principalToolStripMenuItem.Click += new System.EventHandler(this.principalToolStripMenuItem_Click);
            // 
            // bitacoraToolStripMenuItem
            // 
            this.bitacoraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitacoraToolStripMenuItem1});
            this.bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            this.bitacoraToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.bitacoraToolStripMenuItem.Text = "Bitacora";
            // 
            // bitacoraToolStripMenuItem1
            // 
            this.bitacoraToolStripMenuItem1.Name = "bitacoraToolStripMenuItem1";
            this.bitacoraToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.bitacoraToolStripMenuItem1.Text = "Bitacora";
            this.bitacoraToolStripMenuItem1.Click += new System.EventHandler(this.bitacoraToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Lbl_Version});
            this.statusStrip1.Location = new System.Drawing.Point(0, 638);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(974, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Lbl_Version
            // 
            this.Lbl_Version.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Lbl_Version.Name = "Lbl_Version";
            this.Lbl_Version.Size = new System.Drawing.Size(52, 17);
            this.Lbl_Version.Text = "Versión: ";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(974, 660);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Ms_Principal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.Ms_Principal;
            this.MinimumSize = new System.Drawing.Size(914, 579);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.Ms_Principal.ResumeLayout(false);
            this.Ms_Principal.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Ms_Principal;
        private System.Windows.Forms.ToolStripMenuItem procesosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargaAmexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem principalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Lbl_Version;
    }
}