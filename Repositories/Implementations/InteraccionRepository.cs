using Casopractico.Models;
using Casopractico.Services.Interfaces;

public class InteraccionRepository : GenericRepository<Interaccione>, IInteraccionRepository
{
    public InteraccionRepository(ConsultoriaDbContext context) : base(context) { }
}