namespace Tarea3._3_POO
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
            ShowInventario = new Button();
            ShowFactura = new Button();
            ShowPrecios = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ShowInventario
            // 
            ShowInventario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ShowInventario.Location = new Point(58, 301);
            ShowInventario.Name = "ShowInventario";
            ShowInventario.Size = new Size(115, 33);
            ShowInventario.TabIndex = 0;
            ShowInventario.Text = "Inventario";
            ShowInventario.UseVisualStyleBackColor = true;
            ShowInventario.Click += ShowInventario_Click;
            // 
            // ShowFactura
            // 
            ShowFactura.Anchor = AnchorStyles.Bottom;
            ShowFactura.Location = new Point(332, 301);
            ShowFactura.Name = "ShowFactura";
            ShowFactura.Size = new Size(115, 33);
            ShowFactura.TabIndex = 1;
            ShowFactura.Text = "Facturación";
            ShowFactura.UseVisualStyleBackColor = true;
            ShowFactura.Click += ShowFactura_Click;
            // 
            // ShowPrecios
            // 
            ShowPrecios.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ShowPrecios.Location = new Point(582, 301);
            ShowPrecios.Name = "ShowPrecios";
            ShowPrecios.Size = new Size(115, 33);
            ShowPrecios.TabIndex = 2;
            ShowPrecios.Text = "Precios";
            ShowPrecios.UseVisualStyleBackColor = true;
            ShowPrecios.Click += ShowPrecios_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.Captura_de_pantalla_2026_01_26_205038;
            pictureBox1.Location = new Point(104, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(580, 258);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(781, 386);
            Controls.Add(pictureBox1);
            Controls.Add(ShowPrecios);
            Controls.Add(ShowFactura);
            Controls.Add(ShowInventario);
            ForeColor = SystemColors.ControlText;
            Name = "Principal";
            Text = "Principal";
            TransparencyKey = Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button ShowInventario;
        private Button ShowFactura;
        private Button ShowPrecios;
        private PictureBox pictureBox1;
    }
}