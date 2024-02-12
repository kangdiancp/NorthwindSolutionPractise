using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contract.Dto
{
    internal class CategoryGroup
    {
        public CategoryDto Category { get; set; }
        public IEnumerable<ProductDto> Products{ get; set; }
    }
}
