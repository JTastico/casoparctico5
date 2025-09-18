namespace Casopractico.Services.Interfaces;

public interface IInteraccionService
{
    Task<IEnumerable<InteraccioneDTO>> GetAllAsync();
    Task<InteraccioneDTO> GetByIdAsync(int id);
    Task AddAsync(InteraccioneDTO dto);
    Task UpdateAsync(InteraccioneDTO dto);
    Task DeleteAsync(int id);
}