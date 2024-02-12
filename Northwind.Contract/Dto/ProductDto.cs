using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contract.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
    }
}
