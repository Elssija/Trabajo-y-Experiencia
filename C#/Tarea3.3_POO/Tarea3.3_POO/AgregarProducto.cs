using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Tarea3._3_POO.Models;

namespace Tarea3._3_POO
{
    public partial class AgregarProducto : Form
    {
        public AgregarProducto()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NombrePA_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Inventario n = new Inventario();
                var registro = new Data.AguileraContext();

                string nombrebusqueda = NombrePA.Text.Trim().ToLower();
                Venta name = registro.Ventas.FirstOrDefault(p => p.Nombre.ToLower().Trim() == nombrebusqueda);

                if (name != null)
                {
                    PVentaPA.Text = name.Precio.ToString();
                    ExistenPA.Text = name.Existencias.ToString();
                }
                else
                {
                    PVentaPA.Text = "0";
                    ExistenPA.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Boton_CancelarPA_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Boton_AgregarPA_Click(object sender, EventArgs e)
        {
            DialogResult seguridad = MessageBox.Show("¿Deseas cambiar el numero de existencias?", "Cambiar", MessageBoxButtons.YesNo);
            if (seguridad == DialogResult.Yes) 
            {
                this.Close(); 
            }
            else
            {
                return;
            }
        }
    }
}
