namespace WinFormsAppPOO1
{
    partial class Detalle
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
            label1 = new Label();
            Codigo = new TextBox();
            Nombre = new TextBox();
            label2 = new Label();
            Costo = new TextBox();
            label3 = new Label();
            PrecioVenta = new TextBox();
            label4 = new Label();
            Existencias = new TextBox();
            label5 = new Label();
            Comentarios = new TextBox();
            label6 = new Label();
            BotonAceptar = new Button();
            BotonCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(84, 30);
            label1.TabIndex = 0;
            label1.Text = "Codigo:";
            // 
            // Codigo
            // 
            Codigo.Font = new Font("Arial Narrow", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Codigo.Location = new Point(190, 22);
            Codigo.Name = "Codigo";
            Codigo.Size = new Size(117, 29);
            Codigo.TabIndex = 1;
            // 
            // Nombre
            // 
            Nombre.Font = new Font("Arial Narrow", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Nombre.Location = new Point(190, 73);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(423, 29);
            Nombre.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(94, 30);
            label2.TabIndex = 2;
            label2.Text = "Nombre:";
            // 
            // Costo
            // 
            Costo.Font = new Font("Arial Narrow", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Costo.Location = new Point(190, 126);
            Costo.Name = "Costo";
            Costo.Size = new Size(117, 29);
            Costo.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 126);
            label3.Name = "label3";
            label3.Size = new Size(71, 30);
            label3.TabIndex = 4;
            label3.Text = "Costo:";
            // 
            // PrecioVenta
            // 
            PrecioVenta.Font = new Font("Arial Narrow", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PrecioVenta.Location = new Point(190, 176);
            PrecioVenta.Name = "PrecioVenta";
            PrecioVenta.Size = new Size(117, 29);
            PrecioVenta.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 176);
            label4.Name = "label4";
            label4.Size = new Size(172, 30);
            label4.TabIndex = 6;
            label4.Text = "Precio de Ventas:";
            // 
            // Existencias
            // 
            Existencias.Font = new Font("Arial Narrow", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Existencias.Location = new Point(190, 226);
            Existencias.Name = "Existencias";
            Existencias.Size = new Size(117, 29);
            Existencias.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 226);
            label5.Name = "label5";
            label5.Size = new Size(113, 30);
            label5.TabIndex = 8;
            label5.Text = "Existencias";
            // 
            // Comentarios
            // 
            Comentarios.Font = new Font("Arial Narrow", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Comentarios.Location = new Point(190, 277);
            Comentarios.Multiline = true;
            Comentarios.Name = "Comentarios";
            Comentarios.Size = new Size(423, 80);
            Comentarios.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 275);
            label6.Name = "label6";
            label6.Size = new Size(135, 30);
            label6.TabIndex = 10;
            label6.Text = "Comentarios:";
            // 
            // BotonAceptar
            // 
            BotonAceptar.Anchor = AnchorStyles.None;
            BotonAceptar.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotonAceptar.Location = new Point(338, 381);
            BotonAceptar.Name = "BotonAceptar";
            BotonAceptar.Size = new Size(129, 46);
            BotonAceptar.TabIndex = 12;
            BotonAceptar.Text = "Aceptar";
            BotonAceptar.UseVisualStyleBackColor = true;
            BotonAceptar.Click += BotonAceptar_Click;
            // 
            // BotonCancelar
            // 
            BotonCancelar.Anchor = AnchorStyles.None;
            BotonCancelar.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotonCancelar.Location = new Point(484, 381);
            BotonCancelar.Name = "BotonCancelar";
            BotonCancelar.Size = new Size(129, 46);
            BotonCancelar.TabIndex = 13;
            BotonCancelar.Text = "Cancelar";
            BotonCancelar.UseVisualStyleBackColor = true;
            BotonCancelar.Click += BotonCancelar_Click;
            // 
            // Detalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 439);
            Controls.Add(BotonCancelar);
            Controls.Add(BotonAceptar);
            Controls.Add(Comentarios);
            Controls.Add(label6);
            Controls.Add(Existencias);
            Controls.Add(label5);
            Controls.Add(PrecioVenta);
            Controls.Add(label4);
            Controls.Add(Costo);
            Controls.Add(label3);
            Controls.Add(Nombre);
            Controls.Add(label2);
            Controls.Add(Codigo);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Detalle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button BotonAceptar;
        private Button BotonCancelar;
        public TextBox Codigo;
        public TextBox Nombre;
        public TextBox Costo;
        public TextBox PrecioVenta;
        public TextBox Existencias;
        public TextBox Comentarios;
    }
}