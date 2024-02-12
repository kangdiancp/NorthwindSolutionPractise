using Northwind.Domain.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Domain.Entities.Master
{
    [Table("Customers", Schema = "sales")]
    public class Customer : IIdentityModel
    {
        [Key]
        [Column("CustomerId")]
        public int Id { get; set; }
        public string CustomerName { get; set; }    
    }
}
