using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockApp.CLASSES
{
    internal class Marca
    {
        public Marca(int IdMarca, string Name, string Description, DateTime CreationDate, DateTime ModifyDate)
        {
            this.IdMarca = IdMarca;
            this.Name = Name;
            this.Description = Description;
            this.CreationDate = CreationDate;
            this.ModifyDate = ModifyDate;
        }

        public Marca() { }

        public int Id;
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifyDate { get; set; }

        public int IdMarca {
            get {  return Id; }

            set { 
                    if (value > 0)
                        Id = value;
                    else Id = 0;
            }
        }

    }
}
