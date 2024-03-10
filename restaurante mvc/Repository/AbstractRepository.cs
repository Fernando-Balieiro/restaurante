namespace restaurante_mvc.Repository;

public interface IAbstractRepository<TEntity, TId>
{
    Task<List<TEntity>> GetAll();
    Task<TEntity?> GetById(TId id);
    Task<TEntity> Create(TEntity entity);
    Task<string> Delete(TId? id);
}