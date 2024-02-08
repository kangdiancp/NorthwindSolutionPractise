namespace NorthwindWebMvc.Basic.Repository
{
    public interface IRepositoryBase<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Save(TEntity entity);
    }
}
