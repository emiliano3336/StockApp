using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using MaterialSkin;
using MaterialSkin.Controls;

namespace stockApp
{
    public partial class frmGestorComercio : Form
    {
        public frmGestorComercio()
        {
            InitializeComponent();

            /*
             var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
             */

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      

        private void Form1_Activated(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmGestorProducto ventana = new frmGestorProducto();
            ventana.ShowDialog();
        }
    }
}