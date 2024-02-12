namespace Northwind.Domain.Interface
{
    public interface ISoftDeleteable
    {
        public bool IsDeleted { get; set; }
    }
}
