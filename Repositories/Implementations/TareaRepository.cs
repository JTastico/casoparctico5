using Casopractico.Models;
using Casopractico.Services.Interfaces;

public class TareaRepository : GenericRepository<Tarea>, ITareaRepository
{
    public TareaRepository(ConsultoriaDbContext context) : base(context) { }
}