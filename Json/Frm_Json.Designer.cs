namespace Json
{
    partial class Frm_Json
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Json));
            this.Txt_Archivo = new System.Windows.Forms.TextBox();
            this.Dgv_Informacion = new System.Windows.Forms.DataGridView();
            this.Lbl_Total = new System.Windows.Forms.Label();
            this.Btn_Json = new System.Windows.Forms.Button();
            this.Btn_MT = new System.Windows.Forms.Button();
            this.Chk_MT = new System.Windows.Forms.CheckBox();
            this.Chk_Retencion = new System.Windows.Forms.CheckBox();
            this.lbx_Cuentas = new System.Windows.Forms.ListBox();
            this.Btn_Agregar = new System.Windows.Forms.Button();
            this.Bnt_Uno = new System.Windows.Forms.Button();
            this.Bnt_Todos = new System.Windows.Forms.Button();
            this.Txt_Cuenta = new System.Windows.Forms.MaskedTextBox();
            this.Bnt_Excel = new System.Windows.Forms.Button();
            this.buttonInsertarIBFCS = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.Fecha1 = new System.Windows.Forms.DateTimePicker();
            this.buttonCuentasNE = new System.Windows.Forms.Button();
            this.Fecha2 = new System.Windows.Forms.DateTimePicker();
            this.checkBoxFecha1 = new System.Windows.Forms.CheckBox();
            this.checkBoxFecha2 = new System.Windows.Forms.CheckBox();
            this.ExcepcionUPDATESOB = new System.Windows.Forms.CheckBox();
            this.Chk_JSON = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PasswordIB = new System.Windows.Forms.TextBox();
            this.HashBtn = new System.Windows.Forms.Button();
            this.Dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Informacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Txt_Archivo
            // 
            this.Txt_Archivo.Enabled = false;
            this.Txt_Archivo.Location = new System.Drawing.Point(36, 68);
            this.Txt_Archivo.Name = "Txt_Archivo";
            this.Txt_Archivo.Size = new System.Drawing.Size(555, 20);
            this.Txt_Archivo.TabIndex = 1;
            this.Txt_Archivo.Visible = false;
            // 
            // Dgv_Informacion
            // 
            this.Dgv_Informacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Informacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Informacion.Location = new System.Drawing.Point(36, 208);
            this.Dgv_Informacion.Name = "Dgv_Informacion";
            this.Dgv_Informacion.ReadOnly = true;
            this.Dgv_Informacion.Size = new System.Drawing.Size(635, 557);
            this.Dgv_Informacion.TabIndex = 2;
            this.Dgv_Informacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Informacion_CellContentClick);
            // 
            // Lbl_Total
            // 
            this.Lbl_Total.AutoSize = true;
            this.Lbl_Total.Location = new System.Drawing.Point(33, 788);
            this.Lbl_Total.Name = "Lbl_Total";
            this.Lbl_Total.Size = new System.Drawing.Size(40, 13);
            this.Lbl_Total.TabIndex = 6;
            this.Lbl_Total.Text = "Total : ";
            this.Lbl_Total.Visible = false;
            // 
            // Btn_Json
            // 
            this.Btn_Json.Location = new System.Drawing.Point(504, 136);
            this.Btn_Json.Name = "Btn_Json";
            this.Btn_Json.Size = new System.Drawing.Size(75, 23);
            this.Btn_Json.TabIndex = 11;
            this.Btn_Json.Text = "Generar";
            this.Btn_Json.UseVisualStyleBackColor = true;
            this.Btn_Json.Visible = false;
            this.Btn_Json.Click += new System.EventHandler(this.Btn_Json_Click);
            // 
            // Btn_MT
            // 
            this.Btn_MT.Location = new System.Drawing.Point(407, 102);
            this.Btn_MT.Name = "Btn_MT";
            this.Btn_MT.Size = new System.Drawing.Size(75, 23);
            this.Btn_MT.TabIndex = 12;
            this.Btn_MT.Text = "Cargar";
            this.Btn_MT.UseVisualStyleBackColor = true;
            this.Btn_MT.Visible = false;
            this.Btn_MT.Click += new System.EventHandler(this.Btn_MT_Click);
            // 
            // Chk_MT
            // 
            this.Chk_MT.AutoSize = true;
            this.Chk_MT.Location = new System.Drawing.Point(36, 32);
            this.Chk_MT.Name = "Chk_MT";
            this.Chk_MT.Size = new System.Drawing.Size(88, 17);
            this.Chk_MT.TabIndex = 15;
            this.Chk_MT.Text = "Cargar JSON";
            this.Chk_MT.UseVisualStyleBackColor = true;
            this.Chk_MT.CheckedChanged += new System.EventHandler(this.Chk_MT_CheckedChanged);
            // 
            // Chk_Retencion
            // 
            this.Chk_Retencion.AutoSize = true;
            this.Chk_Retencion.Enabled = false;
            this.Chk_Retencion.Location = new System.Drawing.Point(327, 32);
            this.Chk_Retencion.Name = "Chk_Retencion";
            this.Chk_Retencion.Size = new System.Drawing.Size(75, 17);
            this.Chk_Retencion.TabIndex = 19;
            this.Chk_Retencion.Text = "Retencion";
            this.Chk_Retencion.UseVisualStyleBackColor = true;
            this.Chk_Retencion.Visible = false;
            this.Chk_Retencion.CheckedChanged += new System.EventHandler(this.Chk_Retencion_CheckedChanged);
            // 
            // lbx_Cuentas
            // 
            this.lbx_Cuentas.FormattingEnabled = true;
            this.lbx_Cuentas.Location = new System.Drawing.Point(36, 122);
            this.lbx_Cuentas.Name = "lbx_Cuentas";
            this.lbx_Cuentas.Size = new System.Drawing.Size(120, 82);
            this.lbx_Cuentas.TabIndex = 20;
            this.lbx_Cuentas.Visible = false;
            // 
            // Btn_Agregar
            // 
            this.Btn_Agregar.Location = new System.Drawing.Point(171, 93);
            this.Btn_Agregar.Name = "Btn_Agregar";
            this.Btn_Agregar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Agregar.TabIndex = 21;
            this.Btn_Agregar.Text = "Agregar";
            this.Btn_Agregar.UseVisualStyleBackColor = true;
            this.Btn_Agregar.Visible = false;
            this.Btn_Agregar.Click += new System.EventHandler(this.Btn_Agregar_Click);
            // 
            // Bnt_Uno
            // 
            this.Bnt_Uno.Location = new System.Drawing.Point(217, 136);
            this.Bnt_Uno.Name = "Bnt_Uno";
            this.Bnt_Uno.Size = new System.Drawing.Size(29, 23);
            this.Bnt_Uno.TabIndex = 23;
            this.Bnt_Uno.Text = "<";
            this.Bnt_Uno.UseVisualStyleBackColor = true;
            this.Bnt_Uno.Visible = false;
            this.Bnt_Uno.Click += new System.EventHandler(this.Txt_Uno_Click);
            // 
            // Bnt_Todos
            // 
            this.Bnt_Todos.Location = new System.Drawing.Point(171, 136);
            this.Bnt_Todos.Name = "Bnt_Todos";
            this.Bnt_Todos.Size = new System.Drawing.Size(29, 23);
            this.Bnt_Todos.TabIndex = 24;
            this.Bnt_Todos.Text = "<<";
            this.Bnt_Todos.UseVisualStyleBackColor = true;
            this.Bnt_Todos.Visible = false;
            this.Bnt_Todos.Click += new System.EventHandler(this.Txt_Todos_Click);
            // 
            // Txt_Cuenta
            // 
            this.Txt_Cuenta.Location = new System.Drawing.Point(36, 96);
            this.Txt_Cuenta.Mask = "999999999999999999";
            this.Txt_Cuenta.Name = "Txt_Cuenta";
            this.Txt_Cuenta.Size = new System.Drawing.Size(120, 20);
            this.Txt_Cuenta.TabIndex = 25;
            this.Txt_Cuenta.ValidatingType = typeof(int);
            this.Txt_Cuenta.Visible = false;
            this.Txt_Cuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Cuenta_KeyPress);
            // 
            // Bnt_Excel
            // 
            this.Bnt_Excel.Location = new System.Drawing.Point(407, 136);
            this.Bnt_Excel.Name = "Bnt_Excel";
            this.Bnt_Excel.Size = new System.Drawing.Size(75, 23);
            this.Bnt_Excel.TabIndex = 26;
            this.Bnt_Excel.Text = "Excel";
            this.Bnt_Excel.UseVisualStyleBackColor = true;
            this.Bnt_Excel.Visible = false;
            this.Bnt_Excel.Click += new System.EventHandler(this.Bnt_Excel_Click);
            // 
            // buttonInsertarIBFCS
            // 
            this.buttonInsertarIBFCS.Location = new System.Drawing.Point(725, 72);
            this.buttonInsertarIBFCS.Name = "buttonInsertarIBFCS";
            this.buttonInsertarIBFCS.Size = new System.Drawing.Size(111, 54);
            this.buttonInsertarIBFCS.TabIndex = 27;
            this.buttonInsertarIBFCS.Text = "InsertarIB / GenerarFCS";
            this.buttonInsertarIBFCS.UseVisualStyleBackColor = true;
            this.buttonInsertarIBFCS.Visible = false;
            this.buttonInsertarIBFCS.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(860, 114);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(106, 23);
            this.button6.TabIndex = 28;
            this.button6.Text = "ComprobarOracle";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Fecha1
            // 
            this.Fecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha1.Location = new System.Drawing.Point(860, 65);
            this.Fecha1.Name = "Fecha1";
            this.Fecha1.Size = new System.Drawing.Size(106, 20);
            this.Fecha1.TabIndex = 29;
            this.Fecha1.Value = new System.DateTime(2020, 1, 7, 0, 0, 0, 0);
            this.Fecha1.Visible = false;
            this.Fecha1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // buttonCuentasNE
            // 
            this.buttonCuentasNE.Location = new System.Drawing.Point(1183, 65);
            this.buttonCuentasNE.Name = "buttonCuentasNE";
            this.buttonCuentasNE.Size = new System.Drawing.Size(97, 49);
            this.buttonCuentasNE.TabIndex = 30;
            this.buttonCuentasNE.Text = "Generar Cuentas NoEnviadas";
            this.buttonCuentasNE.UseVisualStyleBackColor = true;
            this.buttonCuentasNE.Visible = false;
            this.buttonCuentasNE.Click += new System.EventHandler(this.button7_Click);
            // 
            // Fecha2
            // 
            this.Fecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha2.Location = new System.Drawing.Point(985, 65);
            this.Fecha2.Name = "Fecha2";
            this.Fecha2.Size = new System.Drawing.Size(106, 20);
            this.Fecha2.TabIndex = 31;
            this.Fecha2.Value = new System.DateTime(2020, 1, 8, 0, 0, 0, 0);
            this.Fecha2.Visible = false;
            this.Fecha2.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged_1);
            // 
            // checkBoxFecha1
            // 
            this.checkBoxFecha1.AutoSize = true;
            this.checkBoxFecha1.Location = new System.Drawing.Point(860, 92);
            this.checkBoxFecha1.Name = "checkBoxFecha1";
            this.checkBoxFecha1.Size = new System.Drawing.Size(32, 17);
            this.checkBoxFecha1.TabIndex = 32;
            this.checkBoxFecha1.Text = "=";
            this.checkBoxFecha1.UseVisualStyleBackColor = true;
            this.checkBoxFecha1.Visible = false;
            this.checkBoxFecha1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxFecha2
            // 
            this.checkBoxFecha2.AutoSize = true;
            this.checkBoxFecha2.Location = new System.Drawing.Point(985, 91);
            this.checkBoxFecha2.Name = "checkBoxFecha2";
            this.checkBoxFecha2.Size = new System.Drawing.Size(32, 17);
            this.checkBoxFecha2.TabIndex = 33;
            this.checkBoxFecha2.Text = "=";
            this.checkBoxFecha2.UseVisualStyleBackColor = true;
            this.checkBoxFecha2.Visible = false;
            this.checkBoxFecha2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // ExcepcionUPDATESOB
            // 
            this.ExcepcionUPDATESOB.AutoSize = true;
            this.ExcepcionUPDATESOB.Location = new System.Drawing.Point(504, 106);
            this.ExcepcionUPDATESOB.Name = "ExcepcionUPDATESOB";
            this.ExcepcionUPDATESOB.Size = new System.Drawing.Size(122, 17);
            this.ExcepcionUPDATESOB.TabIndex = 34;
            this.ExcepcionUPDATESOB.Text = "Generar IB Domingo";
            this.ExcepcionUPDATESOB.UseVisualStyleBackColor = true;
            this.ExcepcionUPDATESOB.Visible = false;
            this.ExcepcionUPDATESOB.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // Chk_JSON
            // 
            this.Chk_JSON.AutoSize = true;
            this.Chk_JSON.Location = new System.Drawing.Point(226, 32);
            this.Chk_JSON.Name = "Chk_JSON";
            this.Chk_JSON.Size = new System.Drawing.Size(95, 17);
            this.Chk_JSON.TabIndex = 16;
            this.Chk_JSON.Text = "Generar JSON";
            this.Chk_JSON.UseVisualStyleBackColor = true;
            this.Chk_JSON.CheckedChanged += new System.EventHandler(this.Chk_JSON_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(725, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(126, 17);
            this.checkBox1.TabIndex = 36;
            this.checkBox1.Text = "Procesos adicionales";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Json.Properties.Resources.cargar;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1276, 746);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PasswordIB
            // 
            this.PasswordIB.BackColor = System.Drawing.Color.White;
            this.PasswordIB.Location = new System.Drawing.Point(391, 172);
            this.PasswordIB.Name = "PasswordIB";
            this.PasswordIB.PasswordChar = '*';
            this.PasswordIB.Size = new System.Drawing.Size(200, 20);
            this.PasswordIB.TabIndex = 37;
            this.PasswordIB.UseSystemPasswordChar = true;
            this.PasswordIB.Visible = false;
            this.PasswordIB.TextChanged += new System.EventHandler(this.PasswordIB_TextChanged);
            // 
            // HashBtn
            // 
            this.HashBtn.Location = new System.Drawing.Point(1016, 114);
            this.HashBtn.Name = "HashBtn";
            this.HashBtn.Size = new System.Drawing.Size(75, 23);
            this.HashBtn.TabIndex = 38;
            this.HashBtn.Text = "HASH";
            this.HashBtn.UseVisualStyleBackColor = true;
            this.HashBtn.Visible = false;
            this.HashBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Dtp_Fecha
            // 
            this.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Fecha.Location = new System.Drawing.Point(426, 32);
            this.Dtp_Fecha.Name = "Dtp_Fecha";
            this.Dtp_Fecha.Size = new System.Drawing.Size(165, 20);
            this.Dtp_Fecha.TabIndex = 13;
            this.Dtp_Fecha.Value = new System.DateTime(2019, 10, 21, 0, 0, 0, 0);
            this.Dtp_Fecha.Visible = false;
            this.Dtp_Fecha.ValueChanged += new System.EventHandler(this.Dtp_Fecha_ValueChanged);
            // 
            // Frm_Json
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1276, 746);
            this.Controls.Add(this.Dtp_Fecha);
            this.Controls.Add(this.HashBtn);
            this.Controls.Add(this.PasswordIB);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ExcepcionUPDATESOB);
            this.Controls.Add(this.checkBoxFecha2);
            this.Controls.Add(this.checkBoxFecha1);
            this.Controls.Add(this.Fecha2);
            this.Controls.Add(this.buttonCuentasNE);
            this.Controls.Add(this.Fecha1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.buttonInsertarIBFCS);
            this.Controls.Add(this.Bnt_Excel);
            this.Controls.Add(this.Txt_Cuenta);
            this.Controls.Add(this.Bnt_Todos);
            this.Controls.Add(this.Bnt_Uno);
            this.Controls.Add(this.Btn_Agregar);
            this.Controls.Add(this.lbx_Cuentas);
            this.Controls.Add(this.Chk_Retencion);
            this.Controls.Add(this.Chk_JSON);
            this.Controls.Add(this.Chk_MT);
            this.Controls.Add(this.Btn_MT);
            this.Controls.Add(this.Btn_Json);
            this.Controls.Add(this.Lbl_Total);
            this.Controls.Add(this.Txt_Archivo);
            this.Controls.Add(this.Dgv_Informacion);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_Json";
            this.Text = "JSON";
            this.Load += new System.EventHandler(this.Frm_Json_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Informacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Txt_Archivo;
        private System.Windows.Forms.DataGridView Dgv_Informacion;
        private System.Windows.Forms.Label Lbl_Total;
        private System.Windows.Forms.Button Btn_Json;
        private System.Windows.Forms.Button Btn_MT;
        private System.Windows.Forms.DateTimePicker o;
        private System.Windows.Forms.CheckBox Chk_MT;
        private System.Windows.Forms.CheckBox Chk_Retencion;
        private System.Windows.Forms.ListBox lbx_Cuentas;
        private System.Windows.Forms.Button Btn_Agregar;
        private System.Windows.Forms.Button Bnt_Uno;
        private System.Windows.Forms.Button Bnt_Todos;
        private System.Windows.Forms.MaskedTextBox Txt_Cuenta;
        private System.Windows.Forms.Button Bnt_Excel;
        private System.Windows.Forms.Button buttonInsertarIBFCS;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DateTimePicker Fecha1;
        private System.Windows.Forms.Button buttonCuentasNE;
        private System.Windows.Forms.DateTimePicker Fecha2;
        private System.Windows.Forms.CheckBox checkBoxFecha1;
        private System.Windows.Forms.CheckBox checkBoxFecha2;
        private System.Windows.Forms.CheckBox ExcepcionUPDATESOB;
        private System.Windows.Forms.CheckBox Chk_JSON;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox PasswordIB;
        private System.Windows.Forms.Button HashBtn;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha;
    }
}

