namespace Tarea3._3_POO
{
    partial class Inventario
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Grid1 = new DataGridView();
            Boton_Editar = new Button();
            Boton_Agregar = new Button();
            Boton_Eliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)Grid1).BeginInit();
            SuspendLayout();
            // 
            // Grid1
            // 
            Grid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Grid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid1.Location = new Point(12, 12);
            Grid1.Name = "Grid1";
            Grid1.Size = new Size(776, 366);
            Grid1.TabIndex = 0;
            // 
            // Boton_Editar
            // 
            Boton_Editar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Boton_Editar.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Boton_Editar.Location = new Point(12, 399);
            Boton_Editar.Name = "Boton_Editar";
            Boton_Editar.Size = new Size(108, 39);
            Boton_Editar.TabIndex = 1;
            Boton_Editar.Text = "Editar";
            Boton_Editar.UseVisualStyleBackColor = true;
            Boton_Editar.Click += Boton_Agregar_Click;
            // 
            // Boton_Agregar
            // 
            Boton_Agregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Boton_Agregar.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Boton_Agregar.Location = new Point(126, 399);
            Boton_Agregar.Name = "Boton_Agregar";
            Boton_Agregar.Size = new Size(108, 39);
            Boton_Agregar.TabIndex = 2;
            Boton_Agregar.Text = "Agregar";
            Boton_Agregar.UseVisualStyleBackColor = true;
            Boton_Agregar.Click += Boton_Editar_Click;
            // 
            // Boton_Eliminar
            // 
            Boton_Eliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Boton_Eliminar.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Boton_Eliminar.Location = new Point(680, 399);
            Boton_Eliminar.Name = "Boton_Eliminar";
            Boton_Eliminar.Size = new Size(108, 39);
            Boton_Eliminar.TabIndex = 3;
            Boton_Eliminar.Text = "Eliminar";
            Boton_Eliminar.UseVisualStyleBackColor = true;
            Boton_Eliminar.Click += Boton_Eliminar_Click;
            // 
            // Inventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 450);
            Controls.Add(Boton_Eliminar);
            Controls.Add(Boton_Agregar);
            Controls.Add(Boton_Editar);
            Controls.Add(Grid1);
            MaximizeBox = false;
            Name = "Inventario";
            Text = "Jairo Jassiel Aguilera Romero 20232001430";
            Load += Form1_Load;
            Shown += Inventario_Shown;
            ((System.ComponentModel.ISupportInitialize)Grid1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button Boton_Editar;
        private Button Boton_Agregar;
        private Button Boton_Eliminar;
        public DataGridView Grid1;
    }
}
