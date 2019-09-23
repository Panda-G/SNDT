namespace SistemaTaxonomico
{
    partial class Menu
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
            this.pnlMenuLateral = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.btnAdminitracion = new System.Windows.Forms.Button();
            this.pnlAdmin = new System.Windows.Forms.Panel();
            this.btnCadenaCompleta = new System.Windows.Forms.Button();
            this.btnCadenaCatgoria = new System.Windows.Forms.Button();
            this.btnEliminarEspecie = new System.Windows.Forms.Button();
            this.btnConsuta = new System.Windows.Forms.Button();
            this.pnlConsulta = new System.Windows.Forms.Panel();
            this.btnCateProfundidad = new System.Windows.Forms.Button();
            this.btnEspecieClase = new System.Windows.Forms.Button();
            this.btnVerEspecie = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.pnlMenuLateral.SuspendLayout();
            this.pnlAdmin.SuspendLayout();
            this.pnlConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenuLateral
            // 
            this.pnlMenuLateral.AutoScroll = true;
            this.pnlMenuLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(46)))), ((int)(((byte)(56)))));
            this.pnlMenuLateral.Controls.Add(this.btnAyuda);
            this.pnlMenuLateral.Controls.Add(this.pnlConsulta);
            this.pnlMenuLateral.Controls.Add(this.btnConsuta);
            this.pnlMenuLateral.Controls.Add(this.pnlAdmin);
            this.pnlMenuLateral.Controls.Add(this.btnAdminitracion);
            this.pnlMenuLateral.Controls.Add(this.pnlLogo);
            this.pnlMenuLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuLateral.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuLateral.Name = "pnlMenuLateral";
            this.pnlMenuLateral.Size = new System.Drawing.Size(250, 486);
            this.pnlMenuLateral.TabIndex = 0;
            // 
            // pnlLogo
            // 
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(250, 100);
            this.pnlLogo.TabIndex = 0;
            // 
            // btnAdminitracion
            // 
            this.btnAdminitracion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdminitracion.FlatAppearance.BorderSize = 0;
            this.btnAdminitracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminitracion.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminitracion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAdminitracion.Location = new System.Drawing.Point(0, 100);
            this.btnAdminitracion.Name = "btnAdminitracion";
            this.btnAdminitracion.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAdminitracion.Size = new System.Drawing.Size(250, 45);
            this.btnAdminitracion.TabIndex = 1;
            this.btnAdminitracion.Text = "Administración";
            this.btnAdminitracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdminitracion.UseVisualStyleBackColor = true;
            this.btnAdminitracion.Click += new System.EventHandler(this.BtnAdminitracion_Click);
            // 
            // pnlAdmin
            // 
            this.pnlAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
            this.pnlAdmin.Controls.Add(this.btnEliminarEspecie);
            this.pnlAdmin.Controls.Add(this.btnCadenaCatgoria);
            this.pnlAdmin.Controls.Add(this.btnCadenaCompleta);
            this.pnlAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAdmin.Location = new System.Drawing.Point(0, 145);
            this.pnlAdmin.Name = "pnlAdmin";
            this.pnlAdmin.Size = new System.Drawing.Size(250, 122);
            this.pnlAdmin.TabIndex = 2;
            // 
            // btnCadenaCompleta
            // 
            this.btnCadenaCompleta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCadenaCompleta.FlatAppearance.BorderSize = 0;
            this.btnCadenaCompleta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadenaCompleta.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadenaCompleta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCadenaCompleta.Location = new System.Drawing.Point(0, 0);
            this.btnCadenaCompleta.Name = "btnCadenaCompleta";
            this.btnCadenaCompleta.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnCadenaCompleta.Size = new System.Drawing.Size(250, 40);
            this.btnCadenaCompleta.TabIndex = 0;
            this.btnCadenaCompleta.Text = "Cadena completa";
            this.btnCadenaCompleta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCadenaCompleta.UseVisualStyleBackColor = true;
            this.btnCadenaCompleta.Click += new System.EventHandler(this.BtnCadenaCompleta_Click);
            // 
            // btnCadenaCatgoria
            // 
            this.btnCadenaCatgoria.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCadenaCatgoria.FlatAppearance.BorderSize = 0;
            this.btnCadenaCatgoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadenaCatgoria.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadenaCatgoria.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCadenaCatgoria.Location = new System.Drawing.Point(0, 40);
            this.btnCadenaCatgoria.Name = "btnCadenaCatgoria";
            this.btnCadenaCatgoria.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnCadenaCatgoria.Size = new System.Drawing.Size(250, 40);
            this.btnCadenaCatgoria.TabIndex = 1;
            this.btnCadenaCatgoria.Text = "Categoria";
            this.btnCadenaCatgoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCadenaCatgoria.UseVisualStyleBackColor = true;
            this.btnCadenaCatgoria.Click += new System.EventHandler(this.BtnCadenaCatgoria_Click);
            // 
            // btnEliminarEspecie
            // 
            this.btnEliminarEspecie.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEliminarEspecie.FlatAppearance.BorderSize = 0;
            this.btnEliminarEspecie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarEspecie.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarEspecie.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminarEspecie.Location = new System.Drawing.Point(0, 80);
            this.btnEliminarEspecie.Name = "btnEliminarEspecie";
            this.btnEliminarEspecie.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnEliminarEspecie.Size = new System.Drawing.Size(250, 40);
            this.btnEliminarEspecie.TabIndex = 2;
            this.btnEliminarEspecie.Text = "Eliminar especie";
            this.btnEliminarEspecie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarEspecie.UseVisualStyleBackColor = true;
            this.btnEliminarEspecie.Click += new System.EventHandler(this.BtnEliminarEspecie_Click);
            // 
            // btnConsuta
            // 
            this.btnConsuta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsuta.FlatAppearance.BorderSize = 0;
            this.btnConsuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsuta.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsuta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConsuta.Location = new System.Drawing.Point(0, 267);
            this.btnConsuta.Name = "btnConsuta";
            this.btnConsuta.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnConsuta.Size = new System.Drawing.Size(250, 45);
            this.btnConsuta.TabIndex = 3;
            this.btnConsuta.Text = "Consulta";
            this.btnConsuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsuta.UseVisualStyleBackColor = true;
            this.btnConsuta.Click += new System.EventHandler(this.BtnConsuta_Click);
            // 
            // pnlConsulta
            // 
            this.pnlConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
            this.pnlConsulta.Controls.Add(this.btnCateProfundidad);
            this.pnlConsulta.Controls.Add(this.btnEspecieClase);
            this.pnlConsulta.Controls.Add(this.btnVerEspecie);
            this.pnlConsulta.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConsulta.Location = new System.Drawing.Point(0, 312);
            this.pnlConsulta.Name = "pnlConsulta";
            this.pnlConsulta.Size = new System.Drawing.Size(250, 122);
            this.pnlConsulta.TabIndex = 4;
            // 
            // btnCateProfundidad
            // 
            this.btnCateProfundidad.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCateProfundidad.FlatAppearance.BorderSize = 0;
            this.btnCateProfundidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCateProfundidad.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCateProfundidad.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCateProfundidad.Location = new System.Drawing.Point(0, 80);
            this.btnCateProfundidad.Name = "btnCateProfundidad";
            this.btnCateProfundidad.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnCateProfundidad.Size = new System.Drawing.Size(250, 40);
            this.btnCateProfundidad.TabIndex = 2;
            this.btnCateProfundidad.Text = "Categoria de una profundidad";
            this.btnCateProfundidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCateProfundidad.UseVisualStyleBackColor = true;
            this.btnCateProfundidad.Click += new System.EventHandler(this.BtnCateProfundidad_Click);
            // 
            // btnEspecieClase
            // 
            this.btnEspecieClase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEspecieClase.FlatAppearance.BorderSize = 0;
            this.btnEspecieClase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEspecieClase.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEspecieClase.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEspecieClase.Location = new System.Drawing.Point(0, 40);
            this.btnEspecieClase.Name = "btnEspecieClase";
            this.btnEspecieClase.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnEspecieClase.Size = new System.Drawing.Size(250, 40);
            this.btnEspecieClase.TabIndex = 1;
            this.btnEspecieClase.Text = "Especie por clase";
            this.btnEspecieClase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEspecieClase.UseVisualStyleBackColor = true;
            this.btnEspecieClase.Click += new System.EventHandler(this.BtnEspecieClase_Click);
            // 
            // btnVerEspecie
            // 
            this.btnVerEspecie.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVerEspecie.FlatAppearance.BorderSize = 0;
            this.btnVerEspecie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerEspecie.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerEspecie.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVerEspecie.Location = new System.Drawing.Point(0, 0);
            this.btnVerEspecie.Name = "btnVerEspecie";
            this.btnVerEspecie.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnVerEspecie.Size = new System.Drawing.Size(250, 40);
            this.btnVerEspecie.TabIndex = 0;
            this.btnVerEspecie.Text = "Cadena completa";
            this.btnVerEspecie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerEspecie.UseVisualStyleBackColor = true;
            this.btnVerEspecie.Click += new System.EventHandler(this.BtnVerEspecie_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAyuda.FlatAppearance.BorderSize = 0;
            this.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyuda.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAyuda.Location = new System.Drawing.Point(0, 434);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAyuda.Size = new System.Drawing.Size(250, 45);
            this.btnAyuda.TabIndex = 5;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.BtnAyuda_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 486);
            this.Controls.Add(this.pnlMenuLateral);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(850, 280);
            this.Name = "Menu";
            this.Text = "Menu";
            this.pnlMenuLateral.ResumeLayout(false);
            this.pnlAdmin.ResumeLayout(false);
            this.pnlConsulta.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenuLateral;
        private System.Windows.Forms.Panel pnlConsulta;
        private System.Windows.Forms.Button btnCateProfundidad;
        private System.Windows.Forms.Button btnEspecieClase;
        private System.Windows.Forms.Button btnVerEspecie;
        private System.Windows.Forms.Button btnConsuta;
        private System.Windows.Forms.Panel pnlAdmin;
        private System.Windows.Forms.Button btnEliminarEspecie;
        private System.Windows.Forms.Button btnCadenaCatgoria;
        private System.Windows.Forms.Button btnCadenaCompleta;
        private System.Windows.Forms.Button btnAdminitracion;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Button btnAyuda;
    }
}