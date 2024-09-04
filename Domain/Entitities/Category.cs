using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entitities
{
    public class Category
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public Product Product { get; set; }

    }
}
