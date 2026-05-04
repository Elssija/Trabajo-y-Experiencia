using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tarea3._3_POO
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void ShowInventario_Click(object sender, EventArgs e)
        {
            Inventario nin = new Inventario();
            nin.ShowDialog();
        }

        private void ShowFactura_Click(object sender, EventArgs e)
        {
            VentaDespacho nven = new VentaDespacho();
            nven.ShowDialog();
        }

        private void ShowPrecios_Click(object sender, EventArgs e)
        {
            
        }
    }
}
