namespace Casopractico.Services.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<RoleDTO>> GetAllAsync();
    Task<RoleDTO> GetByIdAsync(int id);
    Task AddAsync(RoleDTO dto);
    Task UpdateAsync(RoleDTO dto);
    Task DeleteAsync(int id);
}