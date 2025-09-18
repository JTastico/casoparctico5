namespace Casopractico.Services.Interfaces;

public interface IProyectoService
{
    Task<IEnumerable<ProyectoDTO>> GetAllAsync();
    Task<ProyectoDTO> GetByIdAsync(int id);
    Task AddAsync(ProyectoDTO dto);
    Task UpdateAsync(ProyectoDTO dto);
    Task DeleteAsync(int id);
}