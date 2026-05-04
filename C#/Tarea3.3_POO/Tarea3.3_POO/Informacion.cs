using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tarea3._3_POO
{
    public partial class Informacion : Form
    {
        public Informacion()
        {
            InitializeComponent();
        }

        private void Boton_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Data.AguileraContext g = new Data.AguileraContext();

                if (Nombre.Text.Trim() == null)
                {
                    MessageBox.Show("El Nombre no puede ir vacio");
                    return;
                }

                if (PrecioVenta.Text.Trim() == null)
                {
                    MessageBox.Show("El Precio de Venta no puede ir vacio");
                    return;
                }
                if (Existencias.Text.Trim() == null)
                {
                    MessageBox.Show("El numero de Existencias no puede ir vacio");
                    return;
                }
                if (Codigo.Text.Trim() == null)
                {
                    MessageBox.Show("El Codigo no puede ir vacio");
                    return;
                }

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Datos digitados invalidos");
            }
        }

        private void Boton_Cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
