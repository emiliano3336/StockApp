using stockApp.BLL;
using stockApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stockApp.UIL.Gestor_Comercio.Gestionar_producto.Consulta_producto
{
    public partial class frmConsultaProducto : Form
    {
        private BussinessLogicalLayer _bussinessLogicalLayer;
        private DataAccessLayer _dataAccessLayer;
        public frmConsultaProducto()
        {
            InitializeComponent();

            _bussinessLogicalLayer = new BussinessLogicalLayer();
            _dataAccessLayer = new DataAccessLayer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultaProducto_Load(object sender, EventArgs e)
        {
            dependentCombox();            
        }

        #region Funcion combobox dependiente

        public void dependentCombox()
        {
            try
            {
                _dataAccessLayer.conn.Open();

                string query = @"
                        SELECT ID_MARCA, NOMBRE FROM marca;
                                "
                ;

                SqlCommand comando = new SqlCommand(query, _dataAccessLayer.conn);

                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                _dataAccessLayer.conn.Close();

                DataRow row = dataTable.NewRow();

                row["Nombre"] = "-Selecciones una marca";
                dataTable.Rows.InsertAt(row, 0);

                cbxMarca.DataSource = dataTable;
                cbxMarca.DisplayMember = "NOMBRE";
                cbxMarca.ValueMember = "ID_MARCA";

            }
            catch (Exception)
            {

                throw;
            }
            finally { _dataAccessLayer.conn.Close(); }
        }


        #endregion

        public void btnConsultarProducto_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();
            dataGridView1.DataSource = null;
            //dataGridView1.DataBindings.Clear();
            if (txtNombre != null)
            {
                string nombre = txtNombre.Text;
                string codigo = txtCodigo.Text;
                int? marca = cbxMarca.SelectedValue as int?;
                dataGridView1.DataSource = searchProduct(nombre, codigo, marca);
            }
                
            else
            {
                if (txtCodigo != null)
                {
                    string codigo = txtCodigo.Text;
                    string nombre = txtCodigo.Text;
                    int? marca = cbxMarca.SelectedValue as int?;
                    dataGridView1.DataSource = searchProduct(nombre, codigo, marca);
                }
                    
                else
                {
                    if (cbxMarca.SelectedValue != null)
                    {
                        string codigo = txtCodigo.Text;
                        string nombre = txtCodigo.Text;
                        int? marca = cbxMarca.SelectedValue as int?;
                        dataGridView1.DataSource = searchProduct(nombre, codigo, marca);
                    }

                }

            }

        }

        private List<Producto> consultaProducto(int? marca)
        {
            //Producto marcas = new Producto();

            //marca = marcas.Brand;// = (cbxMarca.SelectedValue) as int?;
                        
            return _bussinessLogicalLayer.obtengoProducto(marca);
        }

        
        private List<Producto> searchProduct(string nombre, string codigo, int? marca)
        {
            //Producto producto = new Producto();

             //producto.Name = txtNombre.Text;
             //producto.Code = txtCodigo.Text;
            //dataGridView1.Columns.Clear();

            return filterProductos(nombre, codigo, marca);
        }
        

        #region Filtro consulta producto

        private List<Producto> filterProductos(string nombre, string codigo, int? marca)
        {
            //_consultaProducto = new frmConsultaProducto();

            List<Producto> busqueda = new List<Producto>();

            _dataAccessLayer.conn.Open();

            try
            {
                string query = @"
                SELECT ID_PRODUCTO, CODIGO, NOMBRE, DESCRIPCION, STOCK_QTY, PRECIO, FECHA_CREADO, ID_CATEGORIA, ID_MARCA
                FROM productos ";

                /*
                switch (nombre)
                {
                    case "txtNombre":
                        query += "WHERE NOMBRE LIKE '" + nombre + "%';";
                        break;
                    default:
                        //query += "WHERE NOMBRE LIKE ";
                        break;
                }

                switch (codigo)
                {
                    case "txtCodigo":
                        query += "WHERE CODIGO LIKE '" + codigo + "%'";
                        break;
                    default:
                        //query += "WHERE CODIGO LIKE ";
                        break;
                }

                switch (marca)
                {
                    case  -1:
                        query += "WHERE ID_MARCA =" + marca;
                        break;
                    default:
                        //query += "WHERE ID_MARCA =" + 0;
                        break;
                }
                */
                if (marca != null)

                    query += "WHERE ID_MARCA = " + marca;
                else
                {
                        if (nombre != null)

                        query += "WHERE NOMBRE LIKE '" + nombre + "%'";
                    else
                    
                        if (codigo != null)
                        
                            query += "WHERE CODIGO LIKE '" + codigo + "%'";
                    
                }
           
                /*
                  
                 */

                SqlCommand comando = new SqlCommand(query, _dataAccessLayer.conn);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    busqueda.Add(new Producto
                    {
                        IdProduct = (int)reader["ID_PRODUCTO"],
                        Name = reader["NOMBRE"].ToString(),
                        Code = reader["CODIGO"].ToString(),
                        Description = reader["DESCRIPCION"].ToString(),
                        Quantity = (int)reader["STOCK_QTY"],
                        Price = float.Parse(reader["PRECIO"].ToString()),
                        CreationDate = (DateTime)reader["FECHA_CREADO"],
                        Category = reader["ID_CATEGORIA"] as int?,
                        Brand = reader["ID_MARCA"] as int?
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { _dataAccessLayer.conn.Close(); }
            return busqueda;

        }

        #endregion
    }
}
