namespace Tarea3._3_POO
{
    partial class AgregarProducto
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
            Boton_CancelarPA = new Button();
            Boton_AgregarPA = new Button();
            label4 = new Label();
            ExistenPA = new TextBox();
            label3 = new Label();
            PVentaPA = new TextBox();
            label2 = new Label();
            NombrePA = new TextBox();
            label1 = new Label();
            IngresarPA = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // Boton_CancelarPA
            // 
            Boton_CancelarPA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Boton_CancelarPA.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Boton_CancelarPA.Location = new Point(237, 303);
            Boton_CancelarPA.Name = "Boton_CancelarPA";
            Boton_CancelarPA.Size = new Size(86, 39);
            Boton_CancelarPA.TabIndex = 23;
            Boton_CancelarPA.Text = "Cancelar";
            Boton_CancelarPA.UseVisualStyleBackColor = true;
            Boton_CancelarPA.Click += Boton_CancelarPA_Click;
            // 
            // Boton_AgregarPA
            // 
            Boton_AgregarPA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Boton_AgregarPA.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Boton_AgregarPA.Location = new Point(144, 303);
            Boton_AgregarPA.Name = "Boton_AgregarPA";
            Boton_AgregarPA.Size = new Size(86, 39);
            Boton_AgregarPA.TabIndex = 22;
            Boton_AgregarPA.Text = "Agregar";
            Boton_AgregarPA.UseVisualStyleBackColor = true;
            Boton_AgregarPA.Click += Boton_AgregarPA_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 236);
            label4.Name = "label4";
            label4.Size = new Size(0, 22);
            label4.TabIndex = 18;
            // 
            // ExistenPA
            // 
            ExistenPA.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExistenPA.Location = new Point(107, 161);
            ExistenPA.Name = "ExistenPA";
            ExistenPA.ReadOnly = true;
            ExistenPA.Size = new Size(216, 32);
            ExistenPA.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(20, 165);
            label3.Name = "label3";
            label3.Size = new Size(77, 22);
            label3.TabIndex = 16;
            label3.Text = "Existen:";
            // 
            // PVentaPA
            // 
            PVentaPA.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PVentaPA.Location = new Point(144, 91);
            PVentaPA.Name = "PVentaPA";
            PVentaPA.ReadOnly = true;
            PVentaPA.Size = new Size(179, 32);
            PVentaPA.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 95);
            label2.Name = "label2";
            label2.Size = new Size(118, 22);
            label2.TabIndex = 14;
            label2.Text = "PrecioVenta:";
            // 
            // NombrePA
            // 
            NombrePA.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NombrePA.Location = new Point(107, 26);
            NombrePA.Name = "NombrePA";
            NombrePA.Size = new Size(216, 32);
            NombrePA.TabIndex = 13;
            NombrePA.TextChanged += NombrePA_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 30);
            label1.Name = "label1";
            label1.Size = new Size(83, 22);
            label1.TabIndex = 12;
            label1.Text = "Nombre:";
            // 
            // IngresarPA
            // 
            IngresarPA.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IngresarPA.Location = new Point(107, 226);
            IngresarPA.Name = "IngresarPA";
            IngresarPA.PlaceholderText = "0";
            IngresarPA.Size = new Size(216, 32);
            IngresarPA.TabIndex = 25;
            IngresarPA.TextChanged += textBox1_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 230);
            label5.Name = "label5";
            label5.Size = new Size(85, 22);
            label5.TabIndex = 24;
            label5.Text = "Ingresar:";
            // 
            // AgregarProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 375);
            Controls.Add(IngresarPA);
            Controls.Add(label5);
            Controls.Add(Boton_CancelarPA);
            Controls.Add(Boton_AgregarPA);
            Controls.Add(label4);
            Controls.Add(ExistenPA);
            Controls.Add(label3);
            Controls.Add(PVentaPA);
            Controls.Add(label2);
            Controls.Add(NombrePA);
            Controls.Add(label1);
            Name = "AgregarProducto";
            Text = "AgregarProducto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Boton_CancelarPA;
        private Button Boton_AgregarPA;
        private Label label4;
        public TextBox ExistenPA;
        private Label label3;
        public TextBox PVentaPA;
        private Label label2;
        public TextBox NombrePA;
        private Label label1;
        public TextBox IngresarPA;
        private Label label5;
    }
}