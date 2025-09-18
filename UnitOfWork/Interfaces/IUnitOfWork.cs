using Casopractico.Services.Interfaces;

namespace Casopractico.UnitOfWork.Interfaces;

public interface IUnitOfWork: IDisposable
{
    IGastoRepository GastoRepository { get; }
    IInteraccionRepository InteraccionRepository { get; }
    IPersonaRepository PersonaRepository { get; }
    IProyectoRepository ProyectoRepository { get; }
    IRoleRepository RoleRepository { get; }
    ITareaRepository TareaRepository { get; }
    IUsuarioRepository UsuarioRepository { get; }
    
    int SaveChanges();
}