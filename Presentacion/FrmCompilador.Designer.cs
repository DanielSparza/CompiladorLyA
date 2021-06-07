namespace Presentacion
{
    partial class FrmCompilador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompilador));
            this.dtgTokens = new System.Windows.Forms.DataGridView();
            this.rtxtEntrada = new System.Windows.Forms.RichTextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.cmbPuerto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPinBase1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPinHombro = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPinCodo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPinPinza = new System.Windows.Forms.ComboBox();
            this.cmbPinBase2 = new System.Windows.Forms.ComboBox();
            this.cmbPinBase3 = new System.Windows.Forms.ComboBox();
            this.cmbPinBase4 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPlaca = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTokens)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgTokens
            // 
            this.dtgTokens.AllowUserToAddRows = false;
            this.dtgTokens.AllowUserToDeleteRows = false;
            this.dtgTokens.AllowUserToResizeRows = false;
            this.dtgTokens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgTokens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTokens.BackgroundColor = System.Drawing.Color.Silver;
            this.dtgTokens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTokens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgTokens.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgTokens.Location = new System.Drawing.Point(462, 17);
            this.dtgTokens.Name = "dtgTokens";
            this.dtgTokens.ReadOnly = true;
            this.dtgTokens.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTokens.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgTokens.RowHeadersVisible = false;
            this.dtgTokens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTokens.Size = new System.Drawing.Size(439, 19);
            this.dtgTokens.TabIndex = 0;
            this.dtgTokens.Visible = false;
            // 
            // rtxtEntrada
            // 
            this.rtxtEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtxtEntrada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtEntrada.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtEntrada.Location = new System.Drawing.Point(25, 48);
            this.rtxtEntrada.Name = "rtxtEntrada";
            this.rtxtEntrada.Size = new System.Drawing.Size(383, 454);
            this.rtxtEntrada.TabIndex = 0;
            this.rtxtEntrada.Text = "";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(60, 516);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 32);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Entrada";
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEjecutar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEjecutar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEjecutar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEjecutar.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutar.Location = new System.Drawing.Point(250, 516);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(119, 32);
            this.btnEjecutar.TabIndex = 7;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEjecutar.UseVisualStyleBackColor = false;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // cmbPuerto
            // 
            this.cmbPuerto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPuerto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPuerto.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPuerto.FormattingEnabled = true;
            this.cmbPuerto.Location = new System.Drawing.Point(592, 365);
            this.cmbPuerto.Name = "cmbPuerto";
            this.cmbPuerto.Size = new System.Drawing.Size(201, 30);
            this.cmbPuerto.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(512, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Puerto:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(470, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Pin de la base:";
            // 
            // cmbPinBase1
            // 
            this.cmbPinBase1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPinBase1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPinBase1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPinBase1.FormattingEnabled = true;
            this.cmbPinBase1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13"});
            this.cmbPinBase1.Location = new System.Drawing.Point(592, 140);
            this.cmbPinBase1.Name = "cmbPinBase1";
            this.cmbPinBase1.Size = new System.Drawing.Size(58, 30);
            this.cmbPinBase1.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(470, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "Pin del hombro:";
            // 
            // cmbPinHombro
            // 
            this.cmbPinHombro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPinHombro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPinHombro.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPinHombro.FormattingEnabled = true;
            this.cmbPinHombro.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13"});
            this.cmbPinHombro.Location = new System.Drawing.Point(592, 185);
            this.cmbPinHombro.Name = "cmbPinHombro";
            this.cmbPinHombro.Size = new System.Drawing.Size(201, 30);
            this.cmbPinHombro.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(470, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Pin del codo:";
            // 
            // cmbPinCodo
            // 
            this.cmbPinCodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPinCodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPinCodo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPinCodo.FormattingEnabled = true;
            this.cmbPinCodo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13"});
            this.cmbPinCodo.Location = new System.Drawing.Point(592, 231);
            this.cmbPinCodo.Name = "cmbPinCodo";
            this.cmbPinCodo.Size = new System.Drawing.Size(201, 30);
            this.cmbPinCodo.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(470, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 25);
            this.label7.TabIndex = 21;
            this.label7.Text = "Pin de la pinza:";
            // 
            // cmbPinPinza
            // 
            this.cmbPinPinza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPinPinza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPinPinza.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPinPinza.FormattingEnabled = true;
            this.cmbPinPinza.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13"});
            this.cmbPinPinza.Location = new System.Drawing.Point(592, 279);
            this.cmbPinPinza.Name = "cmbPinPinza";
            this.cmbPinPinza.Size = new System.Drawing.Size(201, 30);
            this.cmbPinPinza.TabIndex = 20;
            // 
            // cmbPinBase2
            // 
            this.cmbPinBase2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPinBase2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPinBase2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPinBase2.FormattingEnabled = true;
            this.cmbPinBase2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13"});
            this.cmbPinBase2.Location = new System.Drawing.Point(656, 140);
            this.cmbPinBase2.Name = "cmbPinBase2";
            this.cmbPinBase2.Size = new System.Drawing.Size(58, 30);
            this.cmbPinBase2.TabIndex = 22;
            // 
            // cmbPinBase3
            // 
            this.cmbPinBase3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPinBase3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPinBase3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPinBase3.FormattingEnabled = true;
            this.cmbPinBase3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13"});
            this.cmbPinBase3.Location = new System.Drawing.Point(720, 140);
            this.cmbPinBase3.Name = "cmbPinBase3";
            this.cmbPinBase3.Size = new System.Drawing.Size(58, 30);
            this.cmbPinBase3.TabIndex = 23;
            // 
            // cmbPinBase4
            // 
            this.cmbPinBase4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPinBase4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPinBase4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPinBase4.FormattingEnabled = true;
            this.cmbPinBase4.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13"});
            this.cmbPinBase4.Location = new System.Drawing.Point(784, 140);
            this.cmbPinBase4.Name = "cmbPinBase4";
            this.cmbPinBase4.Size = new System.Drawing.Size(58, 30);
            this.cmbPinBase4.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(515, 417);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 25);
            this.label8.TabIndex = 26;
            this.label8.Text = "Placa:";
            // 
            // cmbPlaca
            // 
            this.cmbPlaca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPlaca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPlaca.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlaca.FormattingEnabled = true;
            this.cmbPlaca.Items.AddRange(new object[] {
            "Arduino Uno",
            "Arduino Leonardo",
            "Arduino Esplora",
            "Arduino Micro",
            "Arduino Duemilanove (328)",
            "Arduino Duemilanove (168)",
            "Arduino Nano (328)",
            "Arduino Nano (168)",
            "Arduino Mini (328)",
            "Arduino Mini (168)",
            "Arduino Pro Mini (328)",
            "Arduino Pro Mini (168)",
            "Arduino Mega  2560/ADK",
            "Arduino Mega 1280",
            "Arduino Mega 8",
            "Microduino Core+ (644P)",
            "Freematics OBD-II Adapter (644P)",
            ""});
            this.cmbPlaca.Location = new System.Drawing.Point(592, 412);
            this.cmbPlaca.Name = "cmbPlaca";
            this.cmbPlaca.Size = new System.Drawing.Size(201, 30);
            this.cmbPlaca.TabIndex = 25;
            // 
            // FrmCompilador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(913, 564);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbPlaca);
            this.Controls.Add(this.cmbPinBase4);
            this.Controls.Add(this.cmbPinBase3);
            this.Controls.Add(this.cmbPinBase2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbPinPinza);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbPinCodo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbPinHombro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPinBase1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPuerto);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.rtxtEntrada);
            this.Controls.Add(this.dtgTokens);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCompilador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compilador";
            this.Load += new System.EventHandler(this.FrmLexico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTokens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgTokens;
        private System.Windows.Forms.RichTextBox rtxtEntrada;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.ComboBox cmbPuerto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPinBase1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPinHombro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbPinCodo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbPinPinza;
        private System.Windows.Forms.ComboBox cmbPinBase2;
        private System.Windows.Forms.ComboBox cmbPinBase3;
        private System.Windows.Forms.ComboBox cmbPinBase4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbPlaca;
    }
}