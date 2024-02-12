using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contract.Dto
{
    public class CategoryDetailDto
    {
        public int Id { get; set; }
        public string? ColorValue { get; set; }
        public string? ColorName { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
    }
}
