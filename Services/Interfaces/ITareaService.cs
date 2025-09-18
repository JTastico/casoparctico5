namespace Casopractico.Services.Interfaces;

public interface ITareaService
{
    Task<IEnumerable<TareaDTO>> GetAllAsync();
    Task<TareaDTO> GetByIdAsync(int id);
    Task AddAsync(TareaDTO dto);
    Task UpdateAsync(TareaDTO dto);
    Task DeleteAsync(int id);
}