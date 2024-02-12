using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
           (
               new Category { Id = 1, CategoryName = "Laptop", Description = "Komputer, laptop,pc", Photo = string.Empty },
               new Category { Id = 2, CategoryName = "Handphone", Description = "Hp", Photo = string.Empty },
               new Category { Id = 3, CategoryName = "T-Shirt", Description = "T-Shirt man", Photo = string.Empty }
           );
        }
    }
}
