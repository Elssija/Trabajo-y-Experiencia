using WinFormsAppPOO1.Models;

namespace WinFormsAppPOO1
{
    public partial class Form1 : Form
    {
        //metodo public
        public void CargarDatos()
        {
            try
            {
                //crear un objeto para tener acceso al contexto de la BD
                Data.JairoContext contexto = new Data.JairoContext();
                //recuperar todos lo datos de la tabla producto asi como todas las columnas
                Grid1.DataSource = contexto.Productos.ToList();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //evento que sucede cuando se dibuja el form en la pantalla
            this.CargarDatos();

            //personalizar grid
            Grid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid1.RowHeadersVisible = false; //selector de filas oculto
            Grid1.ReadOnly = true; //evitar poder editar desde el grid
            Grid1.AllowUserToResizeRows = false; //evitar poder editar desde el grid

            //colocar etiquetas en los titulos de algunas columnas
            Grid1.Columns["ProductoID"].HeaderText = "Numero";
            Grid1.Columns["PrecioVenta"].HeaderText = "Precio de Venta";
            Grid1.AutoResizeColumns(); //autoajustar el ancho de la columnas de acuerdo al contenido
        }

        private void BotonAgregar_Click(object sender, EventArgs e)
        {
            //crear una nueva instancia de detalle
            Detalle d = new Detalle();
            d.ShowDialog(); //mostrar en pantalla
            if (d.IsDisposed == false)
            {
                try
                {

                    Producto registro = new Producto();
                    registro.Codigo = d.Codigo.Text.Trim();
                    registro.Nombre = d.Nombre.Text.Trim();
                    registro.Costo = decimal.Parse(d.Costo.Text.Trim());
                    registro.PrecioVenta = decimal.Parse(d.PrecioVenta.Text.Trim());
                    registro.Existencias = int.Parse(d.Existencias.Text.Trim());
                    registro.Comentarios = d.Comentarios.Text.Trim();

                    //conectar a la base de datos
                    Data.JairoContext contexto = new Data.JairoContext();
                    contexto.Productos.Add(registro);
                    contexto.SaveChanges();
                    this.CargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void BotonsEditar_Click(object sender, EventArgs e)
        {
            //validar si se ha selccionado una fila
            if (Grid1.CurrentRow == null)
            {
                return;
            }
            try
            {
                Data.JairoContext contexto = new Data.JairoContext();

                Producto registro = contexto.Productos.Find(Grid1.CurrentRow.Cells["ProductoID"].Value);

                //dibujar form de detalles 
                Detalle d = new Detalle();
                d.Codigo.Text = registro.Codigo;
                d.Nombre.Text = registro.Nombre;
                d.Costo.Text = registro.Costo.ToString();
                d.PrecioVenta.Text = registro.PrecioVenta.ToString();
                d.Existencias.Text = registro.Existencias.ToString();
                d.Comentarios.Text = registro.Comentarios.ToString();
                d.ShowDialog(); //mostrar form de detalle

                if (d.IsDisposed == false)
                {
                    //colocar los nuevos datos desde Detalle hacia el registro recuperador
                    registro.Codigo = d.Codigo.Text.Trim();
                    registro.Nombre = d.Nombre.Text.Trim();
                    registro.Costo = decimal.Parse(d.Costo.Text.Trim());
                    registro.PrecioVenta = decimal.Parse(d.PrecioVenta.Text.Trim());
                    registro.Existencias = int.Parse(d.Existencias.Text.Trim());
                    registro.Comentarios = d.Comentarios.Text.Trim();

                    //cambiar el estado del registro a modificado
                    contexto.Entry(registro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    contexto.SaveChanges();
                    this.CargarDatos();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            if (Grid1.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un item");
            }
            DialogResult respuesta = MessageBox.Show("Desea eliminar el item", "Eliminar", MessageBoxButtons.YesNo);
            try
            {
                Data.JairoContext contexto = new Data.JairoContext();

                Producto registro = contexto.Productos.Find(Grid1.CurrentRow.Cells["ProductoID"].Value);

                contexto.Remove(registro);
                contexto.SaveChanges();
                this.CargarDatos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
