using Casopractico.Models;
using Casopractico.Services.Interfaces;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(ConsultoriaDbContext context) : base(context) { }
}