using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockApp.CLASSES
{
    internal class Categoria
    {
        public Categoria(int IdCategory, string Name, string Description, DateTime CreationDate, DateTime ModifyDate, int? IDMarca)
        {
            this.IdCategory = IdCategory;
            // this.State = State;
            this.Name = Name;
            this.Description = Description;
            this.CreationDate = CreationDate;
            this.ModifyDate = ModifyDate;
            this.IDMarca = IDMarca;
        }

        public Categoria() { }

        public int Id;
        //public int State {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int? IDMarca { get; set; }

        //Set Id properties
        public int IdCategory
        {
            get { return Id; }
            set
            {
                if (value > 0) { 
                    Id = value;
                }
                else { Id = 0; }
            }
        }
    }
}
