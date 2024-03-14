using stockApp.BLL;
using stockApp.CLASSES;
using stockApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stockApp.UIL
{
    public partial class frmAltaCategoria : Form
    {
        private DataAccessLayer _dataAccessLayer;
        private BussinessLogicalLayer _bussinessLogicalLayer;
        public frmAltaCategoria()
        {
            InitializeComponent();

            _bussinessLogicalLayer = new BussinessLogicalLayer();
            _dataAccessLayer = new DataAccessLayer();
        }

        #region CRUD Categoria
        private void guardarCategoria()
        {
            Categoria categoria = new Categoria();

            categoria.Name = txtNombre.Text;
            categoria.Description = txtDescripcion.Text;
            categoria.IDMarca = cbxMarca.SelectedValue as int?;

            _bussinessLogicalLayer.saveCategoria(categoria);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarCategoria();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void frmAltaCategoria_Load(object sender, EventArgs e)
        {
            /*
            cbxMarca.DataSource = _bussinessLogicalLayer.obtengoMarca();
            cbxMarca.DisplayMember = "Name";
            cbxMarca.ValueMember = "IdMarca";
            */
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

                row["Nombre"] = "-Seleccione una marca";
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

    }
}