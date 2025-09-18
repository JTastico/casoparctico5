using System.Collections.Generic;
using System.Threading.Tasks;

public interface IGastoService
{
    Task<IEnumerable<GastoDTO>> GetAllAsync();
    Task<GastoDTO> GetByIdAsync(int id);
    Task AddAsync(GastoDTO dto);
    Task UpdateAsync(GastoDTO dto);
    Task DeleteAsync(int id);
}