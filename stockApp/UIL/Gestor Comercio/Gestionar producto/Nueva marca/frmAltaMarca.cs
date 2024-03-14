using stockApp.BLL;
using stockApp.CLASSES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stockApp.UIL
{
    public partial class frmAltaMarca : Form
    {
        private BussinessLogicalLayer _bussinessLogicalLayer;
        public frmAltaMarca()
        {
            InitializeComponent();

            _bussinessLogicalLayer = new BussinessLogicalLayer();
        }

        private void guardarMarca()
        {
            Marca marca = new Marca();

            marca.Name = txtNombre.Text;
            marca.Description = txtDescripcion.Text;

            _bussinessLogicalLayer.saveMarca(marca);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarMarca();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
