namespace NorthwindWebMvc.Basic.Service
{
    public interface ICategoryService<TEntity>
    {
        IEnumerable<TEntity> GetAll();  

        TEntity Create(TEntity entity); 

    }
}
