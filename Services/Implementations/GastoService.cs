using Casopractico.Models;
using Casopractico.Services.Interfaces;

public class GastoService : IGastoService
{
    private readonly IGastoRepository _repository;

    public GastoService(IGastoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GastoDTO>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        var dtos = new List<GastoDTO>();
        foreach (var entity in entities)
        {
            dtos.Add(new GastoDTO
            {
                GastoId = entity.GastoId,
                TareaId = entity.TareaId,
                Descripcion = entity.Descripcion,
                Monto = entity.Monto,
                FechaGasto = entity.FechaGasto,
            });
        }
        return dtos;
    }

    public async Task<GastoDTO> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return null;
        return new GastoDTO
        {
            GastoId = entity.GastoId,
            TareaId = entity.TareaId,
            Descripcion = entity.Descripcion,
            Monto = entity.Monto,
            FechaGasto = entity.FechaGasto
        };
    }

    public async Task AddAsync(GastoDTO dto)
    {
        var entity = new Gasto
        {
            TareaId = dto.TareaId,
            Descripcion = dto.Descripcion,
            Monto = dto.Monto,
            FechaGasto = dto.FechaGasto
        };
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(GastoDTO dto)
    {
        var entity = new Gasto
        {
            GastoId = dto.GastoId,
            TareaId = dto.TareaId,
            Descripcion = dto.Descripcion,
            Monto = dto.Monto,
            FechaGasto = dto.FechaGasto
        };
        _repository.Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity != null)
        {
            _repository.Remove(entity);
        }
    }
}