namespace ejemploSProyB
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            v = new Panel();
            btnBuscar = new Button();
            pictureBox1 = new PictureBox();
            txtBusqueda = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            txtFolio = new TextBox();
            txtNombre = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            folio = new DataGridViewTextBoxColumn();
            nombre = new DataGridViewTextBoxColumn();
            precio = new DataGridViewTextBoxColumn();
            cantidad = new DataGridViewTextBoxColumn();
            images = new DataGridViewTextBoxColumn();
            btnLimpiar = new Button();
            imageList1 = new ImageList(components);
            btnEliminar = new Button();
            btnModificar = new Button();
            btnGuardar = new Button();
            txtPrecio = new TextBox();
            txtCantidad = new TextBox();
            pictureBox2 = new PictureBox();
            v.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // v
            // 
            v.BackColor = SystemColors.Highlight;
            v.Controls.Add(btnBuscar);
            v.Controls.Add(pictureBox1);
            v.Controls.Add(txtBusqueda);
            v.Location = new Point(41, 326);
            v.Name = "v";
            v.Size = new Size(871, 98);
            v.TabIndex = 0;
            v.Paint += panel1_Paint;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(78, 38);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(116, 29);
            btnBuscar.TabIndex = 16;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.BottomLeft;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.snapchat;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(572, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 1);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(201, 38);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(346, 31);
            txtBusqueda.TabIndex = 14;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(119, 135);
            label1.Name = "label1";
            label1.Size = new Size(51, 25);
            label1.TabIndex = 1;
            label1.Text = "Folio";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Highlight;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(932, 98);
            panel2.TabIndex = 1;
            // 
            // txtFolio
            // 
            txtFolio.Location = new Point(197, 132);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(262, 31);
            txtFolio.TabIndex = 2;
            txtFolio.TextChanged += txtFolio_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(197, 184);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(262, 31);
            txtNombre.TabIndex = 3;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(119, 190);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 4;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(119, 243);
            label3.Name = "label3";
            label3.Size = new Size(61, 25);
            label3.TabIndex = 5;
            label3.Text = "precio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(119, 285);
            label4.Name = "label4";
            label4.Size = new Size(83, 25);
            label4.TabIndex = 6;
            label4.Text = "Cantidad";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { folio, nombre, precio, cantidad, images });
            dataGridView1.Location = new Point(31, 420);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(881, 184);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // folio
            // 
            folio.HeaderText = "folio";
            folio.MinimumWidth = 8;
            folio.Name = "folio";
            folio.Width = 150;
            // 
            // nombre
            // 
            nombre.HeaderText = "Nombre";
            nombre.MinimumWidth = 8;
            nombre.Name = "nombre";
            nombre.Width = 150;
            // 
            // precio
            // 
            precio.HeaderText = "precio";
            precio.MinimumWidth = 8;
            precio.Name = "precio";
            precio.Width = 150;
            // 
            // cantidad
            // 
            cantidad.HeaderText = "cantidad";
            cantidad.MinimumWidth = 8;
            cantidad.Name = "cantidad";
            cantidad.Width = 150;
            // 
            // images
            // 
            images.HeaderText = "images";
            images.MinimumWidth = 8;
            images.Name = "images";
            images.Width = 150;
            // 
            // btnLimpiar
            // 
            btnLimpiar.ImageIndex = 1;
            btnLimpiar.ImageList = imageList1;
            btnLimpiar.Location = new Point(627, 610);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(126, 52);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Black;
            imageList1.Images.SetKeyName(0, "snapchat.png");
            imageList1.Images.SetKeyName(1, "WhatsApp Image 2026-09-13 at 15.29.54.jpeg");
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(447, 629);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(116, 33);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(251, 629);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(116, 33);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(62, 629);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(116, 33);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(197, 240);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(262, 31);
            txtPrecio.TabIndex = 12;
            txtPrecio.TextChanged += txtPrecio_TextChanged;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(197, 289);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(262, 31);
            txtCantidad.TabIndex = 13;
            txtCantidad.TextChanged += txtCantidad_TextChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.snapchat;
            pictureBox2.Location = new Point(569, 107);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(343, 213);
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 674);
            Controls.Add(pictureBox2);
            Controls.Add(txtCantidad);
            Controls.Add(txtPrecio);
            Controls.Add(btnGuardar);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Controls.Add(dataGridView1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(txtFolio);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(v);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            v.ResumeLayout(false);
            v.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel v;
        private Label label1;
        private Panel panel2;
        private TextBox txtFolio;
        private TextBox txtNombre;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn folio;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn precio;
        private DataGridViewTextBoxColumn cantidad;
        private DataGridViewTextBoxColumn images;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnGuardar;
        private ImageList imageList1;
        private TextBox txtPrecio;
        private TextBox txtCantidad;
        private TextBox txtBusqueda;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button btnBuscar;
    }
}
