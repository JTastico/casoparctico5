using Casopractico.Models;
using Casopractico.Services.Interfaces;

public class ProyectoRepository : GenericRepository<Proyecto>, IProyectoRepository
{
    public ProyectoRepository(ConsultoriaDbContext context) : base(context) { }
}