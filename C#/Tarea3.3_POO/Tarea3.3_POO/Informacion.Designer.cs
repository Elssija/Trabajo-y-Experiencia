namespace Tarea3._3_POO
{
    partial class Informacion
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
            Nombre = new TextBox();
            PrecioVenta = new TextBox();
            label2 = new Label();
            Existencias = new TextBox();
            label3 = new Label();
            Codigo = new TextBox();
            label4 = new Label();
            Observaciones = new TextBox();
            label5 = new Label();
            Boton_Aceptar = new Button();
            Boton_Cancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 27);
            label1.Name = "label1";
            label1.Size = new Size(83, 22);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // Nombre
            // 
            Nombre.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Nombre.Location = new Point(114, 23);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(216, 32);
            Nombre.TabIndex = 1;
            // 
            // PrecioVenta
            // 
            PrecioVenta.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PrecioVenta.Location = new Point(114, 88);
            PrecioVenta.Name = "PrecioVenta";
            PrecioVenta.Size = new Size(216, 32);
            PrecioVenta.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(27, 92);
            label2.Name = "label2";
            label2.Size = new Size(70, 22);
            label2.TabIndex = 2;
            label2.Text = "Precio:";
            // 
            // Existencias
            // 
            Existencias.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Existencias.Location = new Point(139, 158);
            Existencias.Name = "Existencias";
            Existencias.Size = new Size(191, 32);
            Existencias.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(27, 162);
            label3.Name = "label3";
            label3.Size = new Size(111, 22);
            label3.TabIndex = 4;
            label3.Text = "Existencias:";
            // 
            // Codigo
            // 
            Codigo.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Codigo.Location = new Point(114, 229);
            Codigo.Name = "Codigo";
            Codigo.Size = new Size(216, 32);
            Codigo.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(27, 233);
            label4.Name = "label4";
            label4.Size = new Size(72, 22);
            label4.TabIndex = 6;
            label4.Text = "Codigo";
            // 
            // Observaciones
            // 
            Observaciones.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Observaciones.Location = new Point(27, 331);
            Observaciones.Multiline = true;
            Observaciones.Name = "Observaciones";
            Observaciones.Size = new Size(303, 71);
            Observaciones.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(27, 292);
            label5.Name = "label5";
            label5.Size = new Size(143, 22);
            label5.TabIndex = 8;
            label5.Text = "Observaciones:";
            // 
            // Boton_Aceptar
            // 
            Boton_Aceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Boton_Aceptar.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Boton_Aceptar.Location = new Point(139, 420);
            Boton_Aceptar.Name = "Boton_Aceptar";
            Boton_Aceptar.Size = new Size(86, 39);
            Boton_Aceptar.TabIndex = 10;
            Boton_Aceptar.Text = "Aceptar";
            Boton_Aceptar.UseVisualStyleBackColor = true;
            Boton_Aceptar.Click += Boton_Aceptar_Click;
            // 
            // Boton_Cancelar
            // 
            Boton_Cancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Boton_Cancelar.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Boton_Cancelar.Location = new Point(244, 420);
            Boton_Cancelar.Name = "Boton_Cancelar";
            Boton_Cancelar.Size = new Size(86, 39);
            Boton_Cancelar.TabIndex = 11;
            Boton_Cancelar.Text = "Cancelar";
            Boton_Cancelar.UseVisualStyleBackColor = true;
            Boton_Cancelar.Click += Boton_Cancelar_Click;
            // 
            // Informacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 471);
            Controls.Add(Boton_Cancelar);
            Controls.Add(Boton_Aceptar);
            Controls.Add(Observaciones);
            Controls.Add(label5);
            Controls.Add(Codigo);
            Controls.Add(label4);
            Controls.Add(Existencias);
            Controls.Add(label3);
            Controls.Add(PrecioVenta);
            Controls.Add(label2);
            Controls.Add(Nombre);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Informacion";
            Text = "Informacion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button Boton_Aceptar;
        private Button Boton_Cancelar;
        public TextBox Nombre;
        public TextBox PrecioVenta;
        public TextBox Existencias;
        public TextBox Codigo;
        public TextBox Observaciones;
    }
}