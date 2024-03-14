using stockApp.CLASSES;
using stockApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockApp.BLL
{
    internal class BussinessLogicalLayer
    {
        private DataAccessLayer _dataAccessLayer;

        public BussinessLogicalLayer()
        {
            _dataAccessLayer = new DataAccessLayer();
        }

        #region BLL Producto
        public Producto saveProducto(Producto producto)
        {
            if (producto.IdProduct == 0)

                    _dataAccessLayer.insertProduct(producto);
            else
                    _dataAccessLayer.updateProduct(producto);

                   return producto;
        }

        public void borrarProducto(int id)
        {
            if(id != 0)
                _dataAccessLayer.deleteProduct(id);

        }

        public List<Producto> obtengoProducto(int? marca)
        {
            //Producto marcas = new Producto();

            //marca = marcas.Brand;
            return _dataAccessLayer.getProduct(marca);
        }

        /*
        public List<Producto> filtroProducto(string nombre, string codigo, int? marca) 
        {
            //Producto buscar = new Producto();

            //buscar.Name = nombre;
            //buscar.Code = codigo;

           // return _dataAccessLayer.filterProductos(nombre, codigo, marca);
        }
        */

        #endregion

        #region BLL Categoria

        public Categoria saveCategoria(Categoria categoria)
        {
            if(categoria.IdCategory == 0)
                    _dataAccessLayer.insertCategory(categoria);
            else
                    _dataAccessLayer.updateCategory(categoria);
                 return categoria;
        }

        public void borrarCategoria(int id)
        {
            if(id > 0)
                _dataAccessLayer.deleteCategory(id);
        }

        public List<Categoria> obtengoCategorias()
        {
            //List<Categoria> categorias = new List<Categoria>();

            return _dataAccessLayer.obtenerCategoria();

        }

        public List<Categoria> getCategoriaXMarca(int id)
        {
            int value; value = 0;

            if(id > 0)

               value = id;
            return _dataAccessLayer.getCategoryByBrand(value);
        }

        #endregion

        #region BLL Marca

        public Marca saveMarca(Marca marca)
        {
            if(marca.IdMarca == 0)
                _dataAccessLayer.insertMarca(marca);
            else
                _dataAccessLayer.updateMarca(marca);
            return marca;
        }

        public void deleteMarca(int id) { 
        
                if(id > 0)
                    _dataAccessLayer.deleteMarca(id);
        }

        public List<Marca> obtengoMarca()
        {
            //List<Marca> marcas = new List<Marca>();

            return _dataAccessLayer.obtenerMara();

            //return marcas;
        }
        #endregion

    }
}
