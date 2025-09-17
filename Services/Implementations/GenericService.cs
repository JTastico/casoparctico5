public class GenericService<T> : IGenericService<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public GenericService(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _repository.AddAsync(entity);
        // Supongamos que se guarda en la base de datos aquí si es necesario.
    }

    public async Task UpdateAsync(T entity)
    {
        _repository.Update(entity);
        // Supongamos que se guarda en la base de datos aquí si es necesario.
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity != null)
        {
            _repository.Remove(entity);
            // Supongamos que se guarda en la base de datos aquí si es necesario.
        }
    }
}