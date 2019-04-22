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
            this.Btn_Archivo = new System.Windows.Forms.Button();
            this.Txt_Archivo = new System.Windows.Forms.TextBox();
            this.Dgv_Informacion = new System.Windows.Forms.DataGridView();
            this.Lbl_Total = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Txt_Update = new System.Windows.Forms.Button();
            this.Txt_Generar = new System.Windows.Forms.Button();
            this.Btn_Json = new System.Windows.Forms.Button();
            this.Btn_MT = new System.Windows.Forms.Button();
            this.Dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.Chk_Carga = new System.Windows.Forms.CheckBox();
            this.Chk_MT = new System.Windows.Forms.CheckBox();
            this.Chk_JSON = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.Chk_Retencion = new System.Windows.Forms.CheckBox();
            this.lbx_Cuentas = new System.Windows.Forms.ListBox();
            this.Btn_Agregar = new System.Windows.Forms.Button();
            this.Bnt_Uno = new System.Windows.Forms.Button();
            this.Bnt_Todos = new System.Windows.Forms.Button();
            this.Txt_Cuenta = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Informacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Archivo
            // 
            this.Btn_Archivo.Location = new System.Drawing.Point(327, 136);
            this.Btn_Archivo.Name = "Btn_Archivo";
            this.Btn_Archivo.Size = new System.Drawing.Size(75, 23);
            this.Btn_Archivo.TabIndex = 0;
            this.Btn_Archivo.Text = "Cargar";
            this.Btn_Archivo.UseVisualStyleBackColor = true;
            this.Btn_Archivo.Visible = false;
            this.Btn_Archivo.Click += new System.EventHandler(this.Btn_Archivo_Click);
            // 
            // Txt_Archivo
            // 
            this.Txt_Archivo.Enabled = false;
            this.Txt_Archivo.Location = new System.Drawing.Point(36, 68);
            this.Txt_Archivo.Name = "Txt_Archivo";
            this.Txt_Archivo.Size = new System.Drawing.Size(555, 20);
            this.Txt_Archivo.TabIndex = 1;
            // 
            // Dgv_Informacion
            // 
            this.Dgv_Informacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Informacion.Location = new System.Drawing.Point(36, 208);
            this.Dgv_Informacion.Name = "Dgv_Informacion";
            this.Dgv_Informacion.Size = new System.Drawing.Size(555, 150);
            this.Dgv_Informacion.TabIndex = 2;
            this.Dgv_Informacion.Visible = false;
            // 
            // Lbl_Total
            // 
            this.Lbl_Total.AutoSize = true;
            this.Lbl_Total.Location = new System.Drawing.Point(116, 371);
            this.Lbl_Total.Name = "Lbl_Total";
            this.Lbl_Total.Size = new System.Drawing.Size(40, 13);
            this.Lbl_Total.TabIndex = 6;
            this.Lbl_Total.Text = "Total : ";
            this.Lbl_Total.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "SHA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(327, 403);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "PRUEBA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Txt_Update
            // 
            this.Txt_Update.Location = new System.Drawing.Point(153, 403);
            this.Txt_Update.Name = "Txt_Update";
            this.Txt_Update.Size = new System.Drawing.Size(75, 23);
            this.Txt_Update.TabIndex = 9;
            this.Txt_Update.Text = "Update";
            this.Txt_Update.UseVisualStyleBackColor = true;
            this.Txt_Update.Visible = false;
            this.Txt_Update.Click += new System.EventHandler(this.Txt_Update_Click);
            // 
            // Txt_Generar
            // 
            this.Txt_Generar.Location = new System.Drawing.Point(417, 403);
            this.Txt_Generar.Name = "Txt_Generar";
            this.Txt_Generar.Size = new System.Drawing.Size(75, 23);
            this.Txt_Generar.TabIndex = 10;
            this.Txt_Generar.Text = "Generar";
            this.Txt_Generar.UseVisualStyleBackColor = true;
            this.Txt_Generar.Visible = false;
            this.Txt_Generar.Click += new System.EventHandler(this.Txt_Generar_Click);
            // 
            // Btn_Json
            // 
            this.Btn_Json.Location = new System.Drawing.Point(516, 136);
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
            // Dtp_Fecha
            // 
            this.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Fecha.Location = new System.Drawing.Point(426, 32);
            this.Dtp_Fecha.Name = "Dtp_Fecha";
            this.Dtp_Fecha.Size = new System.Drawing.Size(165, 20);
            this.Dtp_Fecha.TabIndex = 13;
            this.Dtp_Fecha.Value = new System.DateTime(2018, 12, 20, 0, 0, 0, 0);
            this.Dtp_Fecha.Visible = false;
            // 
            // Chk_Carga
            // 
            this.Chk_Carga.AutoSize = true;
            this.Chk_Carga.Location = new System.Drawing.Point(125, 32);
            this.Chk_Carga.Name = "Chk_Carga";
            this.Chk_Carga.Size = new System.Drawing.Size(95, 17);
            this.Chk_Carga.TabIndex = 14;
            this.Chk_Carga.Text = "Carga / HASH";
            this.Chk_Carga.UseVisualStyleBackColor = true;
            this.Chk_Carga.Visible = false;
            this.Chk_Carga.CheckedChanged += new System.EventHandler(this.Chk_Carga_CheckedChanged);
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(516, 403);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Generar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Json.Properties.Resources.cargar;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(606, 534);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(396, 175);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 18;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Chk_Retencion
            // 
            this.Chk_Retencion.AutoSize = true;
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
            // Frm_Json
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 534);
            this.Controls.Add(this.Txt_Cuenta);
            this.Controls.Add(this.Bnt_Todos);
            this.Controls.Add(this.Bnt_Uno);
            this.Controls.Add(this.Btn_Agregar);
            this.Controls.Add(this.lbx_Cuentas);
            this.Controls.Add(this.Chk_Retencion);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Chk_JSON);
            this.Controls.Add(this.Chk_MT);
            this.Controls.Add(this.Chk_Carga);
            this.Controls.Add(this.Dtp_Fecha);
            this.Controls.Add(this.Btn_MT);
            this.Controls.Add(this.Btn_Json);
            this.Controls.Add(this.Txt_Generar);
            this.Controls.Add(this.Txt_Update);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Lbl_Total);
            this.Controls.Add(this.Txt_Archivo);
            this.Controls.Add(this.Btn_Archivo);
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

        private System.Windows.Forms.Button Btn_Archivo;
        private System.Windows.Forms.TextBox Txt_Archivo;
        private System.Windows.Forms.DataGridView Dgv_Informacion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Lbl_Total;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Txt_Update;
        private System.Windows.Forms.Button Txt_Generar;
        private System.Windows.Forms.Button Btn_Json;
        private System.Windows.Forms.Button Btn_MT;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha;
        private System.Windows.Forms.CheckBox Chk_Carga;
        private System.Windows.Forms.CheckBox Chk_MT;
        private System.Windows.Forms.CheckBox Chk_JSON;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox Chk_Retencion;
        private System.Windows.Forms.ListBox lbx_Cuentas;
        private System.Windows.Forms.Button Btn_Agregar;
        private System.Windows.Forms.Button Bnt_Uno;
        private System.Windows.Forms.Button Bnt_Todos;
        private System.Windows.Forms.MaskedTextBox Txt_Cuenta;
    }
}

