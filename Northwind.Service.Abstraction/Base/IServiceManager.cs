using Northwind.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Service.Abstraction.Base
{
    public interface IServiceManager
    {
        ICategoryService CategoryService { get; }
    }
}
