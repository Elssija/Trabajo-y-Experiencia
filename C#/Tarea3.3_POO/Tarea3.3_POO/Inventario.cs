using Microsoft.Win32;
using System.Transactions;
using Tarea3._3_POO.Models;

namespace Tarea3._3_POO
{
    public partial class Inventario : Form
    {

        public void CargarDatos()
        {
            Data.AguileraContext g = new Data.AguileraContext();
            Grid1.DataSource = g.Ventas.ToList();
        }
        public Inventario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
            Grid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid1.RowHeadersVisible = false;
            Grid1.ReadOnly = true;
            Grid1.AllowUserToResizeRows = false;

            Grid1.Columns["ProductoId"].HeaderText = "Numero de Producto";
            Grid1.AutoResizeColumns();
        }

        private void Boton_Agregar_Click(object sender, EventArgs e)
        {
            Informacion info = new Informacion();
            try
            {
                if (Grid1.CurrentRow == null)
                {
                    if (info.ShowDialog() == DialogResult.OK)
                    {
                        Venta registro = new Venta();

                        registro.Nombre = info.Nombre.Text;
                        registro.Precio = decimal.Parse(info.PrecioVenta.Text);
                        registro.Existencias = int.Parse(info.Existencias.Text);
                        registro.Codigo = info.Codigo.Text;
                        registro.Observaciones = info.Observaciones.Text;

                        Data.AguileraContext context = new Data.AguileraContext();

                        context.Ventas.Add(registro);
                        context.SaveChanges();
                        this.CargarDatos();
                    }
                }
                if (Grid1.CurrentRow != null)
                {

                    Data.AguileraContext context = new Data.AguileraContext();
                    Venta registro = context.Ventas.Find(Grid1.CurrentRow.Cells["ProductoID"].Value);

                    info.Nombre.Text = registro.Nombre;
                    info.PrecioVenta.Text = registro.Precio.ToString();
                    info.Existencias.Text = registro.Existencias.ToString();
                    info.Codigo.Text = registro.Codigo;
                    info.Observaciones.Text = registro.Observaciones;
                    if (info.ShowDialog() == DialogResult.OK)
                    {
                        if (info.IsDisposed != true)
                        {
                            registro.Nombre = info.Nombre.Text.Trim();
                            registro.Precio = decimal.Parse(info.PrecioVenta.Text.Trim());
                            registro.Existencias = int.Parse(info.Existencias.Text.Trim());
                            registro.Codigo = info.Codigo.Text.Trim();
                            registro.Observaciones = info.Observaciones.Text.Trim();
                        }

                        context.Entry(registro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                        this.CargarDatos();
                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Boton_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                Informacion info = new Informacion();
                Data.AguileraContext data= new Data.AguileraContext();
                AgregarProducto n = new AgregarProducto();
                n.ShowDialog();
                if(n.IsDisposed != true)
                {
                    string buscar = n.NombrePA.Text.ToLower().Trim();

                    Venta name = data.Ventas.FirstOrDefault(p => p.Nombre.ToLower().Trim() == buscar);

                    name.Existencias += int.Parse(n.IngresarPA.Text);
                    data.Entry(name).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    data.SaveChanges();
                    this.CargarDatos();
                }
                
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Boton_Eliminar_Click(object sender, EventArgs e)
        {
            if (Grid1.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un item");
            }

            DialogResult borrar = MessageBox.Show("¿Desea Eliminar Item?", "Eliminar", MessageBoxButtons.YesNo);
            if (borrar == DialogResult.Yes)
            {
                try
                {
                    Data.AguileraContext context = new Data.AguileraContext();
                    Venta registro = context.Ventas.Find(Grid1.CurrentRow.Cells["ProductoID"].Value);

                    context.Remove(registro);

                    context.SaveChanges();
                    this.CargarDatos();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Inventario_Shown(object sender, EventArgs e)
        {
            Grid1.CurrentCell = null;
            Grid1.ClearSelection();
        }
    }
}
