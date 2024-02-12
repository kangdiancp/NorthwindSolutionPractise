using Northwind.Domain.Base;
using Northwind.Domain.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Domain.Entities.Master
{
    [Table("Products", Schema = "master")]
    public class Product : IIdentityModel
    {
        [Key]
        [Column("ProductID")]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Range(EntityConstantModel.MIN_PRICE, EntityConstantModel.MAX_PRICE)]
        public decimal Price { get; set; }  
        public int Stock { get; set; }

        [Column("CategoryId")]
        public int CategoryId { get; set; }

        //relasi one-to-many
        public virtual Category Category { get; set; }
    }
}
