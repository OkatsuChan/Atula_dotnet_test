using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entitities
{
    public class Product
    {
        public Product()
        {
            this.Categories = new List<Category>();
        }
        public int Id { get; set; }

        public string? Sku { get; set; }

        public string? Name { get; set; }

        public List<Category> Categories { get; set; }

    }
}
