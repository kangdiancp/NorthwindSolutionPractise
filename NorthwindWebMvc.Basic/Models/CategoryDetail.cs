using NorthwindWebMvc.Basic.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebMvc.Basic.Models
{
    //relasi oneToOne between Category & CategoryDetail
    [Table("CategoryDetail", Schema = "master")]
    public class CategoryDetail : EntityAuditModel
    {
        [Key, ForeignKey("Category")]
        [Required]
        [Column("CategoryID")]
        public override int Id { get => base.Id; set => base.Id = value; }

        public string? ColorValue { get; set; }
        public string? ColorName { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }

        public virtual Category Category { get; set; }


    }
}
