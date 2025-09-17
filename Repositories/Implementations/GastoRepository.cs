using Casopractico.Models;
using Casopractico.Services.Interfaces;

public class GastoRepository : GenericRepository<Gasto>, IGastoRepository
{
    public GastoRepository(ConsultoriaDbContext context) : base(context) { }
}