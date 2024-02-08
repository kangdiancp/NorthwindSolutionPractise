using NorthwindWebMvc.Basic.Models.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebMvc.Basic.Models
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
