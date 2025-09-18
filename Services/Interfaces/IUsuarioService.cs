namespace Casopractico.Services.Interfaces;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> GetAllAsync();
    Task<UsuarioDTO> GetByIdAsync(int id);
    Task AddAsync(UsuarioDTO dto);
    Task UpdateAsync(UsuarioDTO dto);
    Task DeleteAsync(int id);
}