using Casopractico.Models;
using Casopractico.Services.Interfaces;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ConsultoriaDbContext context) : base(context) { }
}