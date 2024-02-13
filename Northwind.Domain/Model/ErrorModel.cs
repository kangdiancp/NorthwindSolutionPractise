using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Model
{
    public class ErrorModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
    }
}
