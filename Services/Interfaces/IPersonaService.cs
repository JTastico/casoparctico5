namespace Casopractico.Services.Interfaces;

public interface IPersonaService
{
    Task<IEnumerable<PersonaDTO>> GetAllAsync();
    Task<PersonaDTO> GetByIdAsync(int id);
    Task AddAsync(PersonaDTO dto);
    Task UpdateAsync(PersonaDTO dto);
    Task DeleteAsync(int id);
}