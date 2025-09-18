using Casopractico.Models;
using Casopractico.Services.Interfaces;

public class InteraccionService : IInteraccionService
{
    private readonly IInteraccionRepository _repository;

    public InteraccionService(IInteraccionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<InteraccioneDTO>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        var dtos = new List<InteraccioneDTO>();
        foreach (var entity in entities)
        {
            dtos.Add(new InteraccioneDTO
            {
                InteraccionId = entity.InteraccionId,
                ProyectoId = entity.ProyectoId,
                Tipo = entity.Tipo,
                Resumen = entity.Resumen,
                Fecha = entity.Fecha,
                UsuarioId = entity.UsuarioId
            });
        }
        return dtos;
    }

    public async Task<InteraccioneDTO> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return null;
        return new InteraccioneDTO
        {
            InteraccionId = entity.InteraccionId,
            ProyectoId = entity.ProyectoId,
            Tipo = entity.Tipo,
            Resumen = entity.Resumen,
            Fecha = entity.Fecha,
            UsuarioId = entity.UsuarioId
        };
    }

    public async Task AddAsync(InteraccioneDTO dto)
    {
        var entity = new Interaccione
        {
            ProyectoId = dto.ProyectoId,
            Tipo = dto.Tipo,
            Resumen = dto.Resumen,
            Fecha = dto.Fecha,
            UsuarioId = dto.UsuarioId
        };
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(InteraccioneDTO dto)
    {
        var entity = new Interaccione
        {
            InteraccionId = dto.InteraccionId,
            ProyectoId = dto.ProyectoId,
            Tipo = dto.Tipo,
            Resumen = dto.Resumen,
            Fecha = dto.Fecha,
            UsuarioId = dto.UsuarioId
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
