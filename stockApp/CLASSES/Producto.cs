using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockApp
{
    internal class Producto
    {
        public Producto(int IdProduct, string Name, string Description, string Code, int? Brand, int? Category, float Price, int Quantity, DateTime CreationDate, DateTime ModifyDate) {  
            this.IdProduct = IdProduct;
            this.Name = Name;
            this.Description = Description;
            this.Code = Code;
            this.Brand = Brand;
            this.Category = Category;
            this.Price = Price;
            this.Quantity = Quantity;
            this.CreationDate = CreationDate;
            this.ModifyDate = ModifyDate;
        }

        public Producto() { }

        private int Id;           
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int? Brand { get; set; }
        public int? Category { get; set; }
        public float Price { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifyDate { get; set; }

        //Set Id properties
        public int IdProduct
        {
            get { return Id; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    Id = 0;
            }
        }


    }
}
