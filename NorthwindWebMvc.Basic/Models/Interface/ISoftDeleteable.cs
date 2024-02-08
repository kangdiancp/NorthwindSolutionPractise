namespace NorthwindWebMvc.Basic.Models.Interface
{
    public interface ISoftDeleteable
    {
        public bool IsDeleted { get; set; }
    }
}
