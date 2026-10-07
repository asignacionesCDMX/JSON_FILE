namespace Json
{
    partial class Frm_Bitacora
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Bitacora));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Dgv_Resultado = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Dtp_Inicio = new System.Windows.Forms.DateTimePicker();
            this.Dtp_Fin = new System.Windows.Forms.DateTimePicker();
            this.Pbx_Cuenta = new System.Windows.Forms.PictureBox();
            this.Pbx_Buscar = new System.Windows.Forms.PictureBox();
            this.Pbx_Exportar = new System.Windows.Forms.PictureBox();
            this.Txt_Cuenta = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Bnt_Concentrado = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Resultado)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx_Cuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx_Buscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx_Exportar)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Dgv_Resultado, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 221F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1167, 735);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Dgv_Resultado
            // 
            this.Dgv_Resultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_Resultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSalmon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_Resultado.DefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_Resultado.Location = new System.Drawing.Point(3, 224);
            this.Dgv_Resultado.Name = "Dgv_Resultado";
            this.Dgv_Resultado.ReadOnly = true;
            this.Dgv_Resultado.Size = new System.Drawing.Size(1161, 508);
            this.Dgv_Resultado.TabIndex = 1;
            this.Dgv_Resultado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Resultado_CellContentClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel2.BackgroundImage")));
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.34622F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.66599F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.9878F));
            this.tableLayoutPanel2.Controls.Add(this.Dtp_Inicio, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.Dtp_Fin, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.Pbx_Cuenta, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.Pbx_Buscar, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.Pbx_Exportar, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.Txt_Cuenta, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Bnt_Concentrado, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1161, 215);
            this.tableLayoutPanel2.TabIndex = 2;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // Dtp_Inicio
            // 
            this.Dtp_Inicio.Location = new System.Drawing.Point(3, 73);
            this.Dtp_Inicio.Name = "Dtp_Inicio";
            this.Dtp_Inicio.Size = new System.Drawing.Size(204, 20);
            this.Dtp_Inicio.TabIndex = 0;
            // 
            // Dtp_Fin
            // 
            this.Dtp_Fin.Location = new System.Drawing.Point(298, 73);
            this.Dtp_Fin.Name = "Dtp_Fin";
            this.Dtp_Fin.Size = new System.Drawing.Size(207, 20);
            this.Dtp_Fin.TabIndex = 1;
            // 
            // Pbx_Cuenta
            // 
            this.Pbx_Cuenta.Image = global::Json.Properties.Resources.Btn_Cuenta;
            this.Pbx_Cuenta.Location = new System.Drawing.Point(543, 123);
            this.Pbx_Cuenta.Name = "Pbx_Cuenta";
            this.Pbx_Cuenta.Size = new System.Drawing.Size(112, 39);
            this.Pbx_Cuenta.TabIndex = 2;
            this.Pbx_Cuenta.TabStop = false;
            this.Pbx_Cuenta.Click += new System.EventHandler(this.pictureBox1_Click);
            this.Pbx_Cuenta.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.Pbx_Cuenta.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // Pbx_Buscar
            // 
            this.Pbx_Buscar.Image = global::Json.Properties.Resources.Btn_Buscar;
            this.Pbx_Buscar.Location = new System.Drawing.Point(706, 73);
            this.Pbx_Buscar.Name = "Pbx_Buscar";
            this.Pbx_Buscar.Size = new System.Drawing.Size(112, 38);
            this.Pbx_Buscar.TabIndex = 3;
            this.Pbx_Buscar.TabStop = false;
            this.Pbx_Buscar.Click += new System.EventHandler(this.pictureBox2_Click);
            this.Pbx_Buscar.MouseLeave += new System.EventHandler(this.Pbx_Buscar_MouseLeave);
            this.Pbx_Buscar.MouseHover += new System.EventHandler(this.Pbx_Buscar_MouseHover);
            // 
            // Pbx_Exportar
            // 
            this.Pbx_Exportar.Image = global::Json.Properties.Resources.Btn_Excel;
            this.Pbx_Exportar.Location = new System.Drawing.Point(828, 73);
            this.Pbx_Exportar.Name = "Pbx_Exportar";
            this.Pbx_Exportar.Size = new System.Drawing.Size(113, 38);
            this.Pbx_Exportar.TabIndex = 4;
            this.Pbx_Exportar.TabStop = false;
            this.Pbx_Exportar.Click += new System.EventHandler(this.pictureBox3_Click);
            this.Pbx_Exportar.MouseLeave += new System.EventHandler(this.Pbx_Exportar_MouseLeave);
            this.Pbx_Exportar.MouseHover += new System.EventHandler(this.Pbx_Exportar_MouseHover);
            // 
            // Txt_Cuenta
            // 
            this.Txt_Cuenta.Location = new System.Drawing.Point(298, 123);
            this.Txt_Cuenta.Mask = "99999999999999999999";
            this.Txt_Cuenta.Name = "Txt_Cuenta";
            this.Txt_Cuenta.Size = new System.Drawing.Size(207, 20);
            this.Txt_Cuenta.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cuenta:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha Fin:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha Inicio:";
            // 
            // Bnt_Concentrado
            // 
            this.Bnt_Concentrado.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bnt_Concentrado.Location = new System.Drawing.Point(3, 123);
            this.Bnt_Concentrado.Name = "Bnt_Concentrado";
            this.Bnt_Concentrado.Size = new System.Drawing.Size(157, 39);
            this.Bnt_Concentrado.TabIndex = 9;
            this.Bnt_Concentrado.Text = "CONCENTRADO";
            this.Bnt_Concentrado.UseVisualStyleBackColor = true;
            this.Bnt_Concentrado.Click += new System.EventHandler(this.Bnt_Concentrado_Click);
            // 
            // Frm_Bitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1167, 735);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(1183, 769);
            this.Name = "Frm_Bitacora";
            this.Text = "Frm_Bitacora";
            this.Load += new System.EventHandler(this.Frm_Bitacora_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Resultado)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx_Cuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx_Buscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx_Exportar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView Dgv_Resultado;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker Dtp_Inicio;
        private System.Windows.Forms.DateTimePicker Dtp_Fin;
        private System.Windows.Forms.PictureBox Pbx_Cuenta;
        private System.Windows.Forms.PictureBox Pbx_Buscar;
        private System.Windows.Forms.PictureBox Pbx_Exportar;
        private System.Windows.Forms.MaskedTextBox Txt_Cuenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Bnt_Concentrado;
    }
}