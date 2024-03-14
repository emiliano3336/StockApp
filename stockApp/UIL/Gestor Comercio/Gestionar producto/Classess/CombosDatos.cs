using stockApp.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockApp.UIL.Gestor_Comercio.Gestionar_producto.Classess
{
    internal class CombosDatos
    {
        public List<marca> marcaCombox()
        {
             using(dbDev_databaseEntities db = new dbDev_databaseEntities())
            {
                return db.marca.ToList();
            }
        }

        public List<categoria> categoriaCombox(int? iD)
        {
             using(dbDev_databaseEntities db = new dbDev_databaseEntities()) 
            {
                return db.categoria.Where(c => c.ID_MARCA == iD).ToList();
            }
        }
    }
}
