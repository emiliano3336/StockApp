using stockApp.BLL;
using stockApp.CLASSES;
using stockApp.DAL;
using stockApp.UIL;
using stockApp.UIL.Gestor_Comercio.Gestionar_producto;
using stockApp.UIL.Gestor_Comercio.Gestionar_producto.Classess;
using stockApp.UIL.Gestor_Comercio.Gestionar_producto.Consulta_producto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;

namespace stockApp
{
    public partial class frmGestorProducto : Form
    {
        private DataAccessLayer _dataAccessLayer;
        private BussinessLogicalLayer _bussinessLogicalLayer;
        private CombosDatos _comboboxDatos;
        public frmGestorProducto()
        {
            InitializeComponent();

            _bussinessLogicalLayer = new BussinessLogicalLayer();
            _dataAccessLayer = new DataAccessLayer();
            _comboboxDatos = new CombosDatos();
        }

        #region CRUD Producto
        private void guardarProducto()
        {
            Producto producto = new Producto();

            producto.Name = txtNombre.Text;
            producto.Description = txtDescripcion.Text;
            producto.Code = txtCodigo.Text;
            producto.Price = float.Parse(txtPrecio.Text);
            producto.Brand = cbxMarca.SelectedValue as int?;
            producto.Category = cbxCategoria.SelectedValue as int?;
            producto.Quantity = numericUpDown1.Value;

              _bussinessLogicalLayer.saveProducto(producto);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarProducto();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Boton Nueva categoria
        private void button1_Click(object sender, EventArgs e)
        {
            frmAltaCategoria altaCategoria = new frmAltaCategoria();

            altaCategoria.ShowDialog();
        }
        #endregion

        #region Boton Nueva Marca
        private void btnNvaMarca_Click(object sender, EventArgs e)
        {
            frmAltaMarca altaMarca = new frmAltaMarca();
            altaMarca.ShowDialog();
        }


        #endregion

        #region Carga combox's
        private void frmGestorProducto_Load(object sender, EventArgs e)
        {
            marcaaCombox();
            #region Carga combobox por Datasource
            /*
            int id;
            //id = 0;

            cbxMarca.DataSource = _bussinessLogicalLayer.obtengoMarca();
            cbxMarca.DisplayMember = "Name";
            cbxMarca.ValueMember = "IdMarca";
            cbxMarca.SelectedIndex = 0;
            //

            //
            cbxCategoria.DataSource = _bussinessLogicalLayer.getCategoriaXMarca();
            cbxCategoria.DisplayMember = ("Description");
            cbxCategoria.ValueMember = "Id";
            */
            #endregion
        }

        private void cbxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if((int?)cbxMarca.SelectedIndex != -1)
                
                categoriaaCombox();
        }

        #endregion

        #region Funcion combobox dependiente

        private void marcaaCombox()
        {
            var lst = _comboboxDatos.marcaCombox();

            if(lst.Count > 0) {

            cbxMarca.DataSource = lst;
            //cbxMarca.Items.Add("Seleccione una marca");
            cbxMarca.DisplayMember = "Nombre";
            cbxMarca.ValueMember = ("ID_MARCA");
            }
            #region Carga combobox x DataTable
            /*
            try
            {
                _dataAccessLayer.conn.Open();

                //Carga combo Marca
                string query = @"
                        SELECT ID_MARCA, NOMBRE FROM marca;
                                ";

                SqlCommand comando = new SqlCommand(query, _dataAccessLayer.conn);

                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                _dataAccessLayer.conn.Close();

                DataRow row = dataTable.NewRow();

                row["Nombre"] = "-Seleccione una marca";
                dataTable.Rows.InsertAt(row, 0);

                cbxMarca.DataSource = dataTable;
                cbxMarca.DisplayMember = "NOMBRE";
                cbxMarca.ValueMember= "ID_MARCA";

                //Carga combo Categoria

            }
            catch (Exception)
            {

                throw;
            }
            finally { _dataAccessLayer.conn.Close();}
            */

            #endregion
        }

        private void categoriaaCombox()
        {
            //var idMarca = Convert.ToInt32(cbxMarca.SelectedValue.Equals((cbxMarca.ValueMember)));
            //var idMarca = (int)cbxMarca.SelectedValue;
            try
            {
                int? idMarca = (cbxMarca.SelectedValue) as int?;
                var list = _comboboxDatos.categoriaCombox(idMarca);

                if (list.Count > 0)
                {
                    cbxCategoria.DataSource = list;
                    cbxCategoria.SelectedItem = 0;
                    cbxCategoria.DisplayMember = "Descripcion";
                    cbxCategoria.ValueMember = "ID_CATEGORIA";
                }
            }
            catch (Exception)
            {

                throw;
            }
             
        }

        #endregion

        #region Validaciones campos

        ErrorProvider errorProvider = new ErrorProvider();
       
        private void txtNombre_Leave(object sender, EventArgs e)
        {
            //bool textBox = Validaciones.isEmpty(txtNombre);

            if (Validaciones.isEmpty(txtNombre))
            {
                errorProvider.SetError(txtNombre, "Nombre no puede quedar vacio");
                //txtNombre.Focus();
            }

            else
                errorProvider.Clear();
        }

        private void txtPrecio_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            /*
            */
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            
            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;    
            }
           
        }

        private void cbxMarca_DropDownClosed_1(object sender, EventArgs e)
        {
            /*
            if (Validaciones.isVacio(cbxMarca))
            {
                errorProvider.SetError(cbxMarca, "Debe seleccionar una Marca");
                //cbxMarca.Focus();
            }
            else
                errorProvider.Clear();
            */
        }
                
        #endregion

        private void btnConsultarProducto_Click(object sender, EventArgs e)
        {
            frmConsultaProducto nuevaCOnsulta = new frmConsultaProducto();

            nuevaCOnsulta.ShowDialog();
        }
                
    }
}
