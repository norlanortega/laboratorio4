using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ejemploSProyB
{
    public partial class Form1 : Form
    {
        private byte[] imagenSeleccionada = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        // =========================
        // CARGA DEL FORMULARIO
        // =========================
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        // =========================
        // CARGAR / REFRESCAR GRID
        // =========================
        private void CargarGrid(string filtro = "")
        {
            List<Producto> productos = Conexion.GetProductos(filtro);

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Precio", "Precio");
            dataGridView1.Columns.Add("Cantidad", "Cantidad");

            DataGridViewImageColumn colImagen = new DataGridViewImageColumn();
            colImagen.Name = "Imagen";
            colImagen.HeaderText = "Imagen";
            colImagen.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(colImagen);

            foreach (Producto p in productos)
            {
                Image img = null;
                if (p.Imagen != null)
                {
                    using (MemoryStream ms = new MemoryStream(p.Imagen))
                    {
                        img = Image.FromStream(ms);
                    }
                }

                int index = dataGridView1.Rows.Add(p.Id, p.Nombre, p.Precio, p.Cantidad, img);
                dataGridView1.Rows[index].Height = 60;
            }
        }

        // =========================
        // SELECCIONAR FILA -> CARGAR EN CAMPOS
        // =========================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

            txtFolio.Text = fila.Cells["Id"].Value.ToString();
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
            txtCantidad.Text = fila.Cells["Cantidad"].Value.ToString();

            if (fila.Cells["Imagen"].Value != null)
            {
                pictureBox2.Image = (Image)fila.Cells["Imagen"].Value;
            }
            else
            {
                pictureBox2.Image = null;
            }

            imagenSeleccionada = null; // se resetea; solo se reemplaza si el usuario elige una nueva
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        // =========================
        // SELECCIONAR IMAGEN
        // =========================
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = Image.FromFile(ofd.FileName);
                    imagenSeleccionada = File.ReadAllBytes(ofd.FileName);
                }
            }
        }

        // =========================
        // VALIDAR CAMPOS (reutilizable)
        // =========================
        private bool ValidarCampos(out int folio, out decimal precio, out int cantidad)
        {
            folio = 0;
            precio = 0;
            cantidad = 0;

            if (!int.TryParse(txtFolio.Text, out folio))
            {
                MessageBox.Show("Ingrese un folio válido.");
                txtFolio.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto.");
                txtNombre.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Ingrese un precio válido.");
                txtPrecio.Focus();
                return false;
            }

            if (!int.TryParse(txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                txtCantidad.Focus();
                return false;
            }

            return true;
        }

        // =========================
        // GUARDAR
        // =========================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out int folio, out decimal precio, out int cantidad))
                return;

            if (Conexion.ExisteId(folio))
            {
                MessageBox.Show("El folio ya existe.");
                txtFolio.Focus();
                return;
            }

            Producto nuevo = new Producto
            {
                Id = folio,
                Nombre = txtNombre.Text,
                Precio = precio,
                Cantidad = cantidad,
                Imagen = imagenSeleccionada
            };

            bool exito = Conexion.InsertarProducto(nuevo);

            if (exito)
            {
                MessageBox.Show(
                    "Producto guardado correctamente.",
                    "Guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarGrid();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(
                    "Ocurrió un error al guardar el producto.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================
        // MODIFICAR
        // =========================
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show(
                    "Seleccione un producto para modificar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!ValidarCampos(out int folio, out decimal precio, out int cantidad))
                return;

            Producto prod = new Producto
            {
                Id = folio,
                Nombre = txtNombre.Text,
                Precio = precio,
                Cantidad = cantidad,
                Imagen = imagenSeleccionada // null si no se cambió, ModificarProducto lo respeta
            };

            bool exito = Conexion.ModificarProducto(prod);

            if (exito)
            {
                MessageBox.Show(
                    "Producto modificado correctamente.",
                    "Modificar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarGrid();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(
                    "Ocurrió un error al modificar el producto.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================
        // ELIMINAR
        // =========================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show(
                    "Seleccione un producto para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea eliminar este producto?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                bool exito = Conexion.EliminarProducto(id);

                if (exito)
                {
                    MessageBox.Show(
                        "Producto eliminado correctamente.",
                        "Eliminar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    CargarGrid();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(
                        "Ocurrió un error al eliminar el producto.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        // =========================
        // LIMPIAR
        // =========================
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtFolio.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();

            pictureBox2.Image = null;
            imagenSeleccionada = null;

            dataGridView1.ClearSelection();

            txtFolio.Focus();
        }

        private void txtFolio_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string filtro = txtBusqueda.Text.Trim();
            CargarGrid(filtro);
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

        }
    }
}