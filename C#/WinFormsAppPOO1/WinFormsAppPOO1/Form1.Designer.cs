namespace WinFormsAppPOO1
{
    partial class Form1
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
            BotonAgregar = new Button();
            BotonsEditar = new Button();
            BotonEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)Grid1).BeginInit();
            SuspendLayout();
            // 
            // Grid1
            // 
            Grid1.AccessibleRole = AccessibleRole.None;
            Grid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Grid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid1.Location = new Point(12, 12);
            Grid1.Name = "Grid1";
            Grid1.Size = new Size(655, 195);
            Grid1.TabIndex = 0;
            Grid1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // BotonAgregar
            // 
            BotonAgregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BotonAgregar.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotonAgregar.Location = new Point(12, 213);
            BotonAgregar.Name = "BotonAgregar";
            BotonAgregar.Size = new Size(129, 46);
            BotonAgregar.TabIndex = 1;
            BotonAgregar.Text = "Agregar";
            BotonAgregar.UseVisualStyleBackColor = true;
            BotonAgregar.Click += BotonAgregar_Click;
            // 
            // BotonsEditar
            // 
            BotonsEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BotonsEditar.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotonsEditar.Location = new Point(147, 213);
            BotonsEditar.Name = "BotonsEditar";
            BotonsEditar.Size = new Size(129, 46);
            BotonsEditar.TabIndex = 2;
            BotonsEditar.Text = "Editar";
            BotonsEditar.UseVisualStyleBackColor = true;
            BotonsEditar.Click += BotonsEditar_Click;
            // 
            // BotonEliminar
            // 
            BotonEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BotonEliminar.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotonEliminar.Location = new Point(444, 213);
            BotonEliminar.Name = "BotonEliminar";
            BotonEliminar.Size = new Size(129, 46);
            BotonEliminar.TabIndex = 3;
            BotonEliminar.Text = "Eliminar";
            BotonEliminar.UseVisualStyleBackColor = true;
            BotonEliminar.Click += BotonEliminar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 271);
            Controls.Add(BotonEliminar);
            Controls.Add(BotonsEditar);
            Controls.Add(BotonAgregar);
            Controls.Add(Grid1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)Grid1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Grid1;
        private Button BotonAgregar;
        private Button BotonsEditar;
        private Button BotonEliminar;
    }
}
