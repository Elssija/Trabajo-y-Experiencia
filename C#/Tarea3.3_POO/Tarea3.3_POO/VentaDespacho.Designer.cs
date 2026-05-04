namespace Tarea3._3_POO
{
    partial class VentaDespacho
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
            dataGridView1 = new DataGridView();
            Cambio = new TextBox();
            label1 = new Label();
            label2 = new Label();
            Total = new TextBox();
            label3 = new Label();
            Pago = new TextBox();
            EditarCobro = new Button();
            Ingresar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(618, 295);
            dataGridView1.TabIndex = 0;
            // 
            // Cambio
            // 
            Cambio.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Cambio.Location = new Point(511, 335);
            Cambio.Name = "Cambio";
            Cambio.PlaceholderText = "0";
            Cambio.Size = new Size(119, 23);
            Cambio.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(411, 335);
            label1.Name = "label1";
            label1.Size = new Size(94, 24);
            label1.TabIndex = 2;
            label1.Text = "Cambio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(447, 414);
            label2.Name = "label2";
            label2.Size = new Size(58, 24);
            label2.TabIndex = 4;
            label2.Text = "Total";
            // 
            // Total
            // 
            Total.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Total.Location = new Point(511, 415);
            Total.Name = "Total";
            Total.PlaceholderText = "0";
            Total.Size = new Size(119, 23);
            Total.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(195, 335);
            label3.Name = "label3";
            label3.Size = new Size(69, 24);
            label3.TabIndex = 6;
            label3.Text = "Pago:";
            // 
            // Pago
            // 
            Pago.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Pago.Location = new Point(270, 335);
            Pago.Name = "Pago";
            Pago.PlaceholderText = "0";
            Pago.Size = new Size(119, 23);
            Pago.TabIndex = 5;
            // 
            // EditarCobro
            // 
            EditarCobro.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            EditarCobro.Location = new Point(12, 414);
            EditarCobro.Name = "EditarCobro";
            EditarCobro.Size = new Size(116, 23);
            EditarCobro.TabIndex = 7;
            EditarCobro.Text = "Editar Cobro";
            EditarCobro.UseVisualStyleBackColor = true;
            // 
            // Ingresar
            // 
            Ingresar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Ingresar.Location = new Point(12, 334);
            Ingresar.Name = "Ingresar";
            Ingresar.Size = new Size(138, 28);
            Ingresar.TabIndex = 8;
            Ingresar.Text = "Ingresar Poducto";
            Ingresar.UseVisualStyleBackColor = true;
            // 
            // VentaDespacho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 450);
            Controls.Add(Ingresar);
            Controls.Add(EditarCobro);
            Controls.Add(label3);
            Controls.Add(Pago);
            Controls.Add(label2);
            Controls.Add(Total);
            Controls.Add(label1);
            Controls.Add(Cambio);
            Controls.Add(dataGridView1);
            Name = "VentaDespacho";
            Text = "VentaDespacho";
            Load += VentaDespacho_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox Cambio;
        private Label label1;
        private Label label2;
        private TextBox Total;
        private Label label3;
        public TextBox Pago;
        private Button EditarCobro;
        private Button Ingresar;
    }
}