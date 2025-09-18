using Casopractico.Models;
using Casopractico.Services.Interfaces;
using Casopractico.UnitOfWork.Interfaces;

namespace Casopractico.UnitOfWork.Implementations;

public class UnitOfWork: IUnitOfWork
{
    private readonly ConsultoriaDbContext _context;
    
    public IGastoRepository GastoRepository { get; }
    public IInteraccionRepository InteraccionRepository { get; }
    public IPersonaRepository PersonaRepository { get; }
    public IProyectoRepository ProyectoRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public ITareaRepository TareaRepository { get; }
    public IUsuarioRepository UsuarioRepository { get; }
    
    public UnitOfWork(ConsultoriaDbContext context,
        IGastoRepository gastoRepository,
        IInteraccionRepository interaccionRepository,
        IPersonaRepository personaRepository,
        IProyectoRepository proyectoRepository,
        IRoleRepository roleRepository,
        ITareaRepository tareaRepository,
        IUsuarioRepository usuarioRepository)
    {
        _context = context;
        GastoRepository = gastoRepository;
        InteraccionRepository = interaccionRepository;
        PersonaRepository = personaRepository;
        ProyectoRepository = proyectoRepository;
        RoleRepository = roleRepository;
        TareaRepository = tareaRepository;
        UsuarioRepository = usuarioRepository;
    }
    
    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}