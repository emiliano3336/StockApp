namespace stockApp
{

    partial class frmGestorComercio
    {
        /// <summary>
        /// Required designer variable.
        // </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestorComercio));
            this.iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            this.btnGestionarProducto = new System.Windows.Forms.Button();
            this.btnAbrirCaja = new System.Windows.Forms.Button();
            this.btnGestionarStock = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombreComercio = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // iconMenuItem1
            // 
            this.iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconMenuItem1.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem1.Name = "iconMenuItem1";
            this.iconMenuItem1.Size = new System.Drawing.Size(32, 19);
            this.iconMenuItem1.Text = "iconMenuItem1";
            // 
            // btnGestionarProducto
            // 
            this.btnGestionarProducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGestionarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarProducto.Location = new System.Drawing.Point(90, 188);
            this.btnGestionarProducto.Name = "btnGestionarProducto";
            this.btnGestionarProducto.Size = new System.Drawing.Size(181, 169);
            this.btnGestionarProducto.TabIndex = 0;
            this.btnGestionarProducto.Text = "Gestionar producto\r\n";
            this.btnGestionarProducto.UseVisualStyleBackColor = false;
            this.btnGestionarProducto.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAbrirCaja
            // 
            this.btnAbrirCaja.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAbrirCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirCaja.Location = new System.Drawing.Point(346, 188);
            this.btnAbrirCaja.Name = "btnAbrirCaja";
            this.btnAbrirCaja.Size = new System.Drawing.Size(181, 169);
            this.btnAbrirCaja.TabIndex = 1;
            this.btnAbrirCaja.Text = "Abrir caja";
            this.btnAbrirCaja.UseVisualStyleBackColor = false;
            // 
            // btnGestionarStock
            // 
            this.btnGestionarStock.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGestionarStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarStock.Location = new System.Drawing.Point(606, 188);
            this.btnGestionarStock.Name = "btnGestionarStock";
            this.btnGestionarStock.Size = new System.Drawing.Size(181, 169);
            this.btnGestionarStock.TabIndex = 2;
            this.btnGestionarStock.Text = "Gestionar stock";
            this.btnGestionarStock.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(321, 417);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(226, 67);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(594, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha del dia";
            // 
            // lblNombreComercio
            // 
            this.lblNombreComercio.AutoSize = true;
            this.lblNombreComercio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreComercio.Location = new System.Drawing.Point(258, 78);
            this.lblNombreComercio.Name = "lblNombreComercio";
            this.lblNombreComercio.Size = new System.Drawing.Size(340, 39);
            this.lblNombreComercio.TabIndex = 5;
            this.lblNombreComercio.Text = "Nombre del comercio";
            this.lblNombreComercio.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(154, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 103);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // frmGestorComercio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 551);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblNombreComercio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGestionarStock);
            this.Controls.Add(this.btnAbrirCaja);
            this.Controls.Add(this.btnGestionarProducto);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmGestorComercio";
            this.Padding = new System.Windows.Forms.Padding(4, 88, 4, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de comercio";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private System.Windows.Forms.Button btnGestionarProducto;
        private System.Windows.Forms.Button btnAbrirCaja;
        private System.Windows.Forms.Button btnGestionarStock;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombreComercio;
        private System.Windows.Forms.PictureBox pictureBox1;

        private class Inherits
        {
        }

        #endregion
    }
}

