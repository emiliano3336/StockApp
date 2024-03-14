using stockApp.CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stockApp.UIL;
using System.Windows;
using stockApp.BLL;
using stockApp.UIL.Gestor_Comercio.Gestionar_producto.Consulta_producto;

namespace stockApp.DAL
{
    internal class DataAccessLayer
    {

        //private frmConsultaProducto _consultaProducto;
        //private frmGestorProducto _gestorProducto;
        // _gestorProducto = new frmGestorProducto();
                
        public SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Dev_database;Data Source=EMARCHESE\\SQLEXPRESS");

        #region CRUD Producto
        public void insertProduct(Producto producto)
        {
            try
            {
                conn.Open();

                string query = @"
                 INSERT INTO productos (CODIGO, NOMBRE, DESCRIPCION, STOCK_QTY, PRECIO, FECHA_CREADO, ID_CATEGORIA, ID_MARCA)
                 VALUES (@code, @name, @description, @quantity, @price, @createdDate, @category, @brand);
                                ";

                SqlParameter name = new SqlParameter("@name", producto.Name);
                SqlParameter description = new SqlParameter("@description", producto.Description);
                SqlParameter code = new SqlParameter("@code", producto.Code);
                //SqlParameter brand = new SqlParameter("@brand", producto.Brand);
                SqlParameter brand = new SqlParameter("@brand", producto.Brand ?? (object)DBNull.Value);
                //SqlParameter category = new SqlParameter("@category", producto.Category);
                SqlParameter category = new SqlParameter("@category", producto.Category ?? (object)DBNull.Value);
                SqlParameter price = new SqlParameter("@price", producto.Price);
                SqlParameter quantity = new SqlParameter("@quantity", producto.Quantity);
                SqlParameter createdDate = new SqlParameter("@createdDate", DateTime.UtcNow);

                SqlCommand comando = new SqlCommand(query, conn);

                comando.Parameters.Add(name);
                comando.Parameters.Add(description);
                comando.Parameters.Add(code);
                comando.Parameters.Add(brand);
                comando.Parameters.Add(category);
                comando.Parameters.Add(price);
                comando.Parameters.Add(quantity);
                comando.Parameters.Add(createdDate);

                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        public void updateProduct(Producto producto) 
        {
            try
            {
                conn.Open();

                string query = @"
                                
                                ";

                SqlParameter id = new SqlParameter("@id", producto.IdProduct);
                SqlParameter name = new SqlParameter("@name", producto.Name);
                SqlParameter description = new SqlParameter("Description", producto.Description);
                SqlParameter brand = new SqlParameter("@brand", producto.Brand);
                SqlParameter category = new SqlParameter("@category", producto.Category);
                SqlParameter price = new SqlParameter("@price", producto.Price);
                SqlParameter quantity = new SqlParameter("@quantity", producto.Quantity);

                SqlCommand comando = new SqlCommand(query, conn);

                comando.Parameters.Add(id);
                comando.Parameters.Add(name);
                comando.Parameters.Add(description);
                comando.Parameters.Add(brand);
                comando.Parameters.Add(category);
                comando.Parameters.Add(price);
                comando.Parameters.Add(quantity);

                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        public void deleteProduct(int id) 
        {
            try
            {
                conn.Open();

                string query = @"
                                
                                ";

                //SqlParameter id = new SqlParameter("@id", producto.IdProduct);

                SqlCommand comando = new SqlCommand(query, conn);
                comando.Parameters.Add(new SqlParameter("id", id));

                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        public List<Producto> getProduct(int? marca)
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                conn.Open();

                string query = @"
                SELECT ID_PRODUCTO, CODIGO, NOMBRE, DESCRIPCION, STOCK_QTY, PRECIO, FECHA_CREADO, ID_CATEGORIA, ID_MARCA
                FROM productos WHERE ID_MARCA = @brand;
                                ";
                //SqlParameter nombre = new SqlParameter("name", producto.Name);
                //SqlParameter codigo = new SqlParameter("code", producto.Code);
                //SqlParameter marca = new SqlParameter("brand", producto.Brand);
                //SqlParameter marca = new SqlParameter("brand", producto.Brand ?? (object)DBNull.Value);
                //SqlParameter marca = new SqlParameter("brand", SqlDbType.Int).Value = producto.Brand ?? (object)DBNull.Value;
                SqlCommand comando = new SqlCommand(query, conn);

                //comando.Parameters.Add(nombre);
                //comando.Parameters.Add(codigo);
                comando.Parameters.Add(new SqlParameter("@brand", marca as int? ?? (object)DBNull.Value));

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                     
                    productos.Add(new Producto 
                    { 
                         IdProduct = (int)reader["ID_PRODUCTO"],
                         Name = reader["NOMBRE"].ToString(),
                         Code = reader["CODIGO"].ToString(),
                         Description = reader["DESCRIPCION"].ToString(),
                         Quantity = (int)reader["STOCK_QTY"],
                         Price = float.Parse(reader["PRECIO"].ToString()),
                         CreationDate = (DateTime)reader["FECHA_CREADO"],
                         Category = reader["ID_CATEGORIA"] as int?,
                         Brand =  reader["ID_MARCA"] as int?
                    });
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return productos;
        }

        /*
        public List<Producto> filterProductos(string nombre, string codigo, int? marca) 
        {
            _consultaProducto = new frmConsultaProducto();
            List<Producto> busqueda = new List<Producto>();

            conn.Open();

            try
            {
                string query = @"
            SELECT ID_PRODUCTO, CODIGO, NOMBRE, DESCRIPCION, STOCK_QTY, PRECIO, FECHA_CREADO, ID_CATEGORIA, ID_MARCA
            FROM productos ";
               
                switch (nombre)
                {
                    case "txtNombre.Text":
                        query += "WHERE NOMBRE LIKE '" + nombre + "%';";
                        break;
                    default:
                        //query += "WHERE NOMBRE LIKE ";
                        break;
                }

                switch (codigo)
                {
                    case "txtCodigo.Text":
                        query += "WHERE CODIGO LIKE '" + codigo + "%'";
                        break;
                    default:
                        //query += "WHERE CODIGO LIKE ";
                        break;
                }

                switch (marca)
                {
                    case 0:
                        query += "WHERE ID_MARCA =" + marca;
                        break;
                    default:
                        //query += "WHERE ID_MARCA =" + 0;
                        break;
                }

                SqlCommand comando = new SqlCommand(query, conn);

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
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return busqueda;

        }
        */

        #endregion

        #region CRUD Categoria

        public void insertCategory(Categoria categoria)
        {
            try
            {
                conn.Open();

                string query = @"
               INSERT INTO categoria (NOMBRE, DESCRIPCION, FECHA_CREACION, ID_MARCA) VALUES (@name, @description, @createdDate, @iDMarca);
                                ";

                //SqlParameter state = new SqlParameter("@state", categoria.State);
                SqlParameter name = new SqlParameter("@name", categoria.Name);
                SqlParameter description = new SqlParameter("@description", categoria.Description);
                SqlParameter createdDate = new SqlParameter("@createdDate", DateTime.UtcNow);
                SqlParameter idMarca = new SqlParameter("@iDMarca", categoria.IDMarca ?? (object)DBNull.Value);


                SqlCommand comando = new SqlCommand(query, conn);

                //comando.Parameters.Add(state);
                comando.Parameters.Add(name);
                comando.Parameters.Add(description);
                comando.Parameters.Add(createdDate);
                comando.Parameters.Add(idMarca);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw;
            }
            finally { conn.Close(); }

        }

        public void updateCategory(Categoria categoria)
        {
            try
            {
                conn.Open();

                string query = @"
                      UPDATE categoria SET NOMBRE = @name, DESCRIPCION = @description, FECHA_MODIFICACION = @modifiedDate WHERE ID_CATEGORIA = @id;           
                                ";

                SqlParameter id = new SqlParameter("@id", categoria.IdCategory);
                //SqlParameter state = new SqlParameter("@state", categoria.State);
                SqlParameter name  = new SqlParameter ("@name", categoria.Name);
                SqlParameter description = new SqlParameter("@description", categoria.Description);
                SqlParameter createdDate = new SqlParameter("@createdDate", categoria.CreationDate);
                SqlParameter modifiedDate = new SqlParameter("@modifiedDate", categoria.ModifyDate);

                SqlCommand comando = new SqlCommand( query, conn);

                comando.Parameters.Add(id);
                //comando.Parameters.Add(state);
                comando.Parameters.Add(name);
                comando.Parameters.Add(description);
                comando.Parameters.Add(createdDate);
                comando.Parameters.Add(modifiedDate);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        public void deleteCategory(int id)
        {
            try
            {
                conn.Open();

                string query = @"
                                DELETE categoria WHERE ID_CATEGORIA=@id;
                                ";
                //SqlParameter id = new SqlParameter("@id", Categoria.);

                SqlCommand comando = new SqlCommand(query, conn);

                comando.Parameters.Add(new SqlParameter("@id", id));

                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        public List<Categoria> obtenerCategoria()           
        {
            List<Categoria> categoria = new List<Categoria>();
            try
            {
                conn.Open();

                string query = @"
                             SELECT ID_CATEGORIA, NOMBRE, DESCRIPCION FROM categoria;
                                ";

                SqlCommand comando = new SqlCommand(query, conn);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read()){

                    //Categoria categorias = new Categoria();

                    categoria.Add(new Categoria
                    {
                        Id = (int)reader["ID_CATEGORIA"],
                        Name = reader["NOMBRE"].ToString(),
                        Description = reader["DESCRIPCION"].ToString()
                    }
                    );
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return categoria;
        }

        
        #endregion

        #region CRUD Marca

        public void insertMarca(Marca marca)
        {
            try
            {
                conn.Open();

                string query = @"
                       INSERT INTO marca (NOMBRE, DESCRIPCION, FECHA_CREACION) VALUES (@name, @description, @createdDate);
                                ";

                SqlParameter name = new SqlParameter("@name", marca.Name);
                SqlParameter description = new SqlParameter ("@description", marca.Description);
                SqlParameter createdDate = new SqlParameter("@createdDate", DateTime.UtcNow);

                SqlCommand comando = new SqlCommand(query, conn);

                comando.Parameters.Add (name);
                comando.Parameters.Add (description);
                comando.Parameters.Add(createdDate);

                comando.ExecuteNonQuery();


            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        public void updateMarca(Marca marca)
        {
            try
            {
                conn.Open();

                string query = @"
                                
                                ";

                SqlParameter id = new SqlParameter("@id", marca.IdMarca);
                SqlParameter name = new SqlParameter("@name", marca.Name);
                SqlParameter description = new SqlParameter("@description", marca.Description);
                SqlParameter createdDate = new SqlParameter("@createdDate", marca.CreationDate);

                SqlCommand comando = new SqlCommand( query, conn);
                comando.Parameters.Add (id);
                comando.Parameters.Add (name);
                comando.Parameters.Add (description);
                comando.Parameters.Add(createdDate);

                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        public void deleteMarca(int id)
        {
            try
            {
                conn.Open();

                string query = @"
                                
                                ";

                SqlCommand comando = new SqlCommand ( query, conn);

                comando.Parameters.Add(new SqlParameter("@id", id));

                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        public List<Marca> obtenerMara()
        {
            List<Marca> marcas = new List<Marca>();

            try
            {
                conn.Open ();

                string query = @"
                    SELECT ID_MARCA, NOMBRE, DESCRIPCION FROM marca;
                                ";
                SqlCommand comando = new SqlCommand (query, conn);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Marca marca = new Marca();

                    marcas.Add(new Marca
                    {
                        Id = (int)reader["ID_MARCA"],
                        Description = reader["Descripcion"].ToString(),
                        Name = reader["NOMBRE"].ToString()
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return marcas;
        }

        #endregion

        #region Funcion para obtener categorias x marca como lista(Des uso)

        public List<Categoria> getCategoryByBrand(int? id)
        {
            List<Categoria> categoria = new List<Categoria>();
            try
            {
                conn.Open();

                string query = @"
                    SELECT ID_CATEGORIA, DESCRIPCION FROM categoria WHERE ID_MARCA =@id;
                                ";


                // SqlParameter id = new SqlParameter("@id", marca.IdMarca);

                SqlCommand comando = new SqlCommand(query, conn);

                comando.Parameters.Add(new SqlParameter("@id", id));

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    categoria.Add(new Categoria
                    {
                        Description = reader["DESCRIPCION"].ToString(),
                        Id = int.Parse(reader["ID_CATEGORIA"].ToString())
                    });
                }

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return categoria;
        }

        #endregion
                
    }
}
