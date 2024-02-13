using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.RequestFeature
{
    public class EntityParameter : RequestParameters
    {
        public string? SearchBy { get; set; }   
    }
}
