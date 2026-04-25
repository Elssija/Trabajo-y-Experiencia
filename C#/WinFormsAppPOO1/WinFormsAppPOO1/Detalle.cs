using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsAppPOO1
{
    public partial class Detalle : Form
    {
        public Detalle()
        {
            InitializeComponent();
        }

        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            //destruir el formulario
            this.Dispose();
        }

        private void BotonAceptar_Click(object sender, EventArgs e)
        {
            //validar que las cajas de texto vengan llenas
            try
            {
                if(Codigo.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Codigo no puede ir en blanco");
                }
                if (Nombre.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Nombre no puede ir en blanco");
                }
                if (double.Parse(Costo.Text) < 0)
                {
                    MessageBox.Show("Costo no puede ser negativo");
                }
                if (double.Parse(Costo.Text) <= 0)
                {
                    MessageBox.Show("Costo no puede ser 0");
                }
                if (double.Parse(PrecioVenta.Text) <= 0)
                {
                    MessageBox.Show("Precio de venta menor que 0");
                }
                if (Existencias.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Existencias no puede ir en blanco");
                }

                //si llego hasta aqui todo salio bien, por lo tanto ocutamos el fomulario
                //pero no lo destruimos de la memoria
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Los datos digitados no son correctos");
            }
        }
    }
}
